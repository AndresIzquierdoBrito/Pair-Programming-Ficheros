namespace Ej04
{

    internal class Program
    {
        private static void Main()
        {
            if (Fichero.ArchivoExiste())
            {
                Fichero.LeerFichero();
                Fichero.RellenarFichero();
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
    }
}