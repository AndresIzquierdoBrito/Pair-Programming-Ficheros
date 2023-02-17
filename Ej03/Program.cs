using System.Diagnostics;

namespace Ej03
{
    internal class Program
    {
        private static void Main()
        {
            if (Ficheros.ArchivoExiste())
            {
                Ficheros.LeerFichero();
                Ficheros.GestionLineas();

            }
            else
            {
                Console.WriteLine("pito");
            }

        }
    }
}