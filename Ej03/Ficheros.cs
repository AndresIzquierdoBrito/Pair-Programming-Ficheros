using System.Diagnostics;

namespace Ej03
{
    internal abstract class Ficheros
    {
        const string NOMBREFICH = "paro.csv", FICHSALIDA = "SALIDA.txt";
        static readonly string[] MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubbre", "Noviembre", "Diciembre" };
        static List<string> lineas = new();

        public static bool ArchivoExiste() => File.Exists(NOMBREFICH);

        public static bool LeerFichero()
        {
            try
            {
                lineas = File.ReadAllLines(NOMBREFICH).ToList();
                if (lineas is not null && lineas.Count > 0)
                    return true;
            }
            catch (Exception ex) { Console.WriteLine($"\n\n\t{ex.Message}"); }
            return false;
        }

        public static void GestionLineas()
        {
            Funciones.CrearFichero(FICHSALIDA, true);
            StreamWriter sw = new(FICHSALIDA);
            sw.WriteLine("LINEA\t\t\tAÑO\tMES\t\tMUNICIPIO\tDATO");
            for (int i = 1; i < lineas.Count; i++)
            {
                string[] lineaDatos = lineas[i].Split(',');
                if (i == 80)
                {
                    sw.Close();
                    sw = new StreamWriter(FICHSALIDA, true);
                }
                for (int j = 6, anio = 2008, mes = 0; j < lineaDatos.Length - 1;
                    j++, anio = (j - 6) % 12 == 0 ? anio + 1 : anio,
                    mes = (j - 6) % 12 == 0 ? 0 : mes + 1)
                    if (int.TryParse(lineaDatos[j], out int valor))
                        sw.WriteLine($"LINEA: {i} - {j - 5 + (126 * (i - 1))}:\t{anio};\t{(MESES[mes].Length == 4 ? MESES[mes] + "; " : (MESES[mes]) + ';')}\t{lineaDatos[5]};\t{valor}");
            }
            sw.Close();
            Process.Start("notepad.exe", FICHSALIDA);
        }
    }
}