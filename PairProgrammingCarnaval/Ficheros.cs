namespace Ej01
{
    internal class Ficheros
    {
        const string UNO = "1.txt", DOS = "2.txt";
        static List<string> Lineas1 = new(), Lineas2 = new(), diferencias = new();

        public static bool ArchivoExiste() => File.Exists(UNO) && File.Exists(DOS);

        public static bool LeerFichero()
        {
            try
            {
                Lineas1 = File.ReadAllText(UNO).Split("\r\n").ToList();
                Lineas2 = File.ReadAllText(DOS).Split("\r\n").ToList();
                return Lineas1.Count > 0 && Lineas2.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool BuscarDiferencias()
        {
            int limite = Lineas1.Count > Lineas2.Count ? Lineas1.Count : Lineas2.Count;
            for (int i = 0; i < limite; i++)
            {
                if (i < Lineas1.Count && i < Lineas2.Count && (Lineas1[i] != Lineas2[i]))
                    diferencias.Add($"{i};{Lineas1[i]};{Lineas2[i]}");
                else if (i < Lineas1.Count && i >= Lineas2.Count)
                    diferencias.Add($"{i};{Lineas1[i]};");
                else if (i >= Lineas1.Count && i < Lineas2.Count)
                    diferencias.Add($"{i};;{Lineas2[i]}");
            }
            return diferencias.Count > 0;
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
                Thread.Sleep(500);
                Console.Write(".");
            }
            Thread.Sleep(800);
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

        public static bool EscribirFichero(string path)
        {
            try
            {
                StreamWriter sw = new(path);
                diferencias.ForEach(s => sw.WriteLine(s));
                sw.Close();
                return true;
            }
            catch { return false; }
        }
    }
}
