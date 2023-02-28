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
                Console.WriteLine("El archivo no existe.");
                Console.ReadKey();
            }
        }
    }
}