namespace Ej02
{
    internal class Ficheros
    {
        const string NOMBREFICH = "doc.txt";
        public static bool ArchivoExiste() => File.Exists(NOMBREFICH);

        public static void EscribirLineas(int nLineas)
        {
            try
            {
                List<string> lineas = File.ReadAllLines(NOMBREFICH).ToList();

                if (nLineas < lineas.Count)
                    for (int i = 0; i < nLineas; i++)
                        Console.WriteLine($"\t{lineas[lineas.Count - nLineas + i]}");
                else
                    lineas.ForEach(line => Console.WriteLine($"\t{line}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, no se pudo leer el archivo\n\n{ex}");
            }
        }
    }
}
