namespace Ej02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int nLineas;
            // Nos aseguramos que el archivo existe
            if (Ficheros.ArchivoExiste())
            {
                // Pedimos el número de líneas a mostrar
                nLineas = Funciones.LeerEntero("\n\tIntroduzca el número de líneas a mostrar: ", borrarLuego:true,limInf: 1);
                Ficheros.EscribirLineas(nLineas);
            }
            else
                Console.WriteLine($"\n\tEl archivo no existe");
            Console.ReadKey();
        }
    }
}