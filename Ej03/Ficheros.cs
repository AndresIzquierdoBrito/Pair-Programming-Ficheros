using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;

namespace Ej03
{
    internal class Ficheros
    {
        const string NOMBREFICH = "paro.csv", FICHSALIDA = "SALIDA.txt";
        static readonly string[] MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubbre", "Noviembre", "Diciembre" };
        static List<string> lineas;
        public static bool ArchivoExiste() => File.Exists(NOMBREFICH);

        public static bool LeerFichero()
        {
            try
            {
                lineas = File.ReadAllLines(NOMBREFICH).ToList();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static void GestionLineas()
        {
            CrearFichero(FICHSALIDA, true);
            StreamWriter sw = new StreamWriter(FICHSALIDA);
            sw.WriteLine("LINEA\tAÑO\tMES\tMUNICIPIO\tDATO");
            for (int i = 1; i < lineas.Count; i++)
            {
                string[] lineaDatos = lineas[i].Split(',');
                if (i == 80)
                {
                    sw.Close();
                    sw = new StreamWriter(FICHSALIDA, true);
                }
                for (int j = 6, anio = 2008, mes = 0; j < 132; j++, anio = (j - 6) % 12 == 0 ? anio + 1 : anio, mes = (j - 6) % 12 == 0 ? 0 : mes + 1)    
                    sw.WriteLine($"LINEA: {i} - {j - 5 + (126 * (i - 1))}: {anio};{MESES[mes]};{lineaDatos[5]};{lineaDatos[j]}");
            }
            sw.Close();
            Process.Start("notepad.exe", FICHSALIDA);
        }

        public static bool CrearFichero(string path, bool sobreescribir = false)
        {
            try
            {
                bool crear = false;
                if (File.Exists(path))
                {
                    if (sobreescribir)
                    {
                        Console.Write("\n\n\tEl archivo ya existe. \n\t\t¿Desea sobrescribirlo? S/N");
                        if (Console.ReadKey().Key == ConsoleKey.S)
                            crear = true;
                    }
                }
                else
                    crear = true;

                if (crear)
                {
                    File.Create(path).Close();
                    Cargar("\n\tCreando su fichero", "\n\n\t\t¡Archivo creado correctamente! :D", false, true);
                }
                return true;
            }
            catch (Exception ex)
            {
                Continuar($"Fallo durante la creación del archivo\n\n\n{ex}");
                return false;
            }
        }

        public static void Cargar(string msg, string msgSalida = "", bool parada = true, bool limpiarPrevio = false)
        {
            if (limpiarPrevio)
                Console.Clear();
            Console.Write(msg);
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
            Thread.Sleep(10);
            Console.Write(msgSalida);
            if (parada)
                Continuar("");
            else
                Thread.Sleep(10);
        }

        public static void Continuar(string msg, bool parada = true, bool limpiarPrevio = false)
        {
            if (limpiarPrevio)
                Console.Clear();
            Console.Write(msg);
            if (parada)
            {
                Console.Write("\n\n\tPulse una tecla para continuar... ");
                Console.ReadKey();
            }
        }
    }
}
