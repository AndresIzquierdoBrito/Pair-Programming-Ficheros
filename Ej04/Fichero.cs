using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    internal class Fichero
    {
        const string NOMBREFICH = "Datos notas.csv", FICHSALIDA = "salida.txt";
        static readonly double[] porcNotas = { 0.2, 0.3, 0.5 };
        static List<string> lineas;
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
            CrearFichero(FICHSALIDA, true);
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
                Console.WriteLine("No se pudo crear/escribir el fichero.");
                return false;
            }
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
