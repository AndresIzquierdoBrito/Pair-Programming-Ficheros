using System.Diagnostics;

namespace Ej04
{
    internal class Fichero
    {
        const string NOMBREFICH = "Datos notas.csv", FICHSALIDA = "salida.txt";
        static readonly double[] porcNotas = { 0.2, 0.3, 0.5 };
        static List<string> lineas = new();


        public static bool ArchivoExiste() => File.Exists(NOMBREFICH);

        public static bool LeerFichero()
        {
            try
            {
                lineas = File.ReadAllLines(NOMBREFICH).ToList();
                int limite = lineas.Count % 2 == 0 ? lineas.Count / 2 : (lineas.Count / 2) + 1;
                for (int i = 1; i < limite; i++)
                    lineas.Remove(lineas[i]);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool RellenarFichero()
        {
            Funciones.CrearFichero(FICHSALIDA, true);
            try
            {
                StreamWriter sw = new(FICHSALIDA);
                int NUMNOTAS = lineas[0].Split(';').ToArray().Length - 1;
                double notaFinal, nota30, nota20, nota50;
                sw.WriteLine("ALUMNO\t\tNOTA FINAL");
                for (int i = 0; i < lineas.Count; i++)
                {
                    nota30 = Convert.ToInt32(lineas[i].Split(';')[1]) + Convert.ToInt32(lineas[i].Split(";")[2]) + Convert.ToInt32(lineas[i].Split(";")[3]);
                    nota30 = (nota30 / 3) * porcNotas[1];
                    nota20 = Convert.ToInt32(lineas[i].Split(';')[4]) + Convert.ToInt32(lineas[i].Split(";")[5]) + Convert.ToInt32(lineas[i].Split(";")[6]);
                    nota20 = (nota20 / 3) * porcNotas[0];
                    nota50 = Convert.ToInt32(lineas[i].Split(';')[7]) + Convert.ToInt32(lineas[i].Split(";")[8]);
                    nota50 = (nota50 / 2) * porcNotas[2];
                    notaFinal = Math.Truncate(nota30 + nota20 + nota50);
                    sw.WriteLine($" {lineas[i].Split(';')[0]};{notaFinal}");
                }
                sw.Close();
                Process.Start("notepad.exe", FICHSALIDA);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"escribir el fichero.\n\n\t{ex}");
                Console.ReadKey();
                return false;
            }
        }
    }
}
