namespace Ej02
{
    internal class Funciones
    {
        public static int LeerEntero(string msg = "", bool borrarPrevio = false, bool borrarLuego = false, int? limInf = null, int? limSup = null)
        {
            bool inicio = false;
            int? num = null;
            do
            {
                if (borrarPrevio)
                    Console.Clear();
                if (inicio)
                {
                    if (num is not null)
                        if (limInf is not null && num < limInf)
                            Console.Write($"\tEl número no puede ser menor a {limInf}\n");
                        else if (limSup is not null && num > limSup)
                            Console.Write($"\tEl número no puede ser mayor a {limSup}\n");
                }
                else
                    inicio = true;
                if (msg != "")
                    Console.Write(msg);
                num = IntTryParseNullable(Console.ReadLine() ?? "");
            } while (num is null || (limInf is not null && num < limInf) || (limSup is not null && num > limSup));
            if (borrarLuego)
                Console.Clear();
            return (int)num;
        }

        public static int? IntTryParseNullable(string val) => int.TryParse(val, out int outValue) ? (int?)outValue : null;

    }
}
