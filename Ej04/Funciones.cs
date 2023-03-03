namespace Ej04
{
    internal class Funciones
    {
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
                Thread.Sleep(500);
                Console.Write(".");
            }
            Thread.Sleep(700);
            Console.Write(msgSalida);
            if (parada)
                Continuar("");
            else
                Thread.Sleep(1000);
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
