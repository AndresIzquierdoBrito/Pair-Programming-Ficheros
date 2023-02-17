using System.Diagnostics;

namespace Ej01
{
    internal class Program
    {

        private static void Main()
        {
            //Revisamos que los archivos existen, Luego los leemos y guardamos, por último guardamos las diferencias.
            if (Ficheros.ArchivoExiste() && Ficheros.LeerFichero() && Ficheros.BuscarDiferencias())
            {
                //Si existen, se leen y tienen diferencias entramos al if
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