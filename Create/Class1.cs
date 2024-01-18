namespace Characters
{
    public class Create
    {
        public const string WrongNum = "Has puesto un valor fuera del rango, ";
        public const string TryAgain = "prueba otra vez:";
        public const string StatConfirmation = "La stat ha sido creada ";
        const string Correctly = "CORRECTAMENTE";
        public const string triesIndicator = "Te quedan estos intentos para crear la stat: ";
        public static float CustomStats(ref int tries, ref bool statCreated ,float valueStat, int[,] values, int xindex, int yindex)
        {
            statCreated = false;
            if ((valueStat >= values[xindex,0]) && (valueStat <= values[yindex,1]))
            {
                Console.ResetColor();
                Console.Write(StatConfirmation);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Correctly);
                Console.ResetColor();
                Console.WriteLine();
                return valueStat;
            }
            else
            {
                Console.Write(WrongNum);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(TryAgain);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine();
                tries--;
                Console.Write(triesIndicator);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(tries);
                Console.ResetColor();
                return valueStat = 0;
            }
        }
        public static float MinStat(int[,] values, int xindex, int yindex)
        {
            return values [xindex, yindex];
        }

        public static float MaxStat(int[,] values, int xindex, int yindex)
        {
            return values[xindex, yindex];
        }
        public static int RandStat(int[,] values, int xindex, int yindex)
        {
            Random random = new Random();
            return random.Next(values[xindex, 0], values[yindex, 1] + 1);
        }
    }
}