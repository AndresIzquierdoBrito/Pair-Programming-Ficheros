using System.Diagnostics;

namespace Ej01
{
    internal class Program
    {

        private static void Main()
        {

            if (Ficheros.ArchivoExiste() && Ficheros.LeerFichero() && Ficheros.BuscarDiferencias())
            {
                Ficheros.CrearFichero("diferencias.txt", true);
                if (Ficheros.EscribirFichero("diferencias.txt"))
                    Process.Start("notepad.exe", "diferencias.txt");
            }
            else
                Console.Write("No existen los ficheros necesarios.");
            Console.ReadKey();
        }
    }
}