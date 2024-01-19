namespace Characters
{
    public class Create
    {
        public const string WrongNum = "Has puesto un valor fuera del rango, ";
        public const string TryAgain = "prueba otra vez:";
        public const string StatConfirmation = "La stat ha sido creada ";
        const string Correctly = "CORRECTAMENTE";
        public const string triesIndicator = "Te quedan estos intentos para crear la stat: ";
        public static float Stat(ref int tries, ref bool statCreated, float valueStat, int MinStat, int MaxStat)
        {
            statCreated = false;

            if (valueStat >= MinStat && valueStat <= MaxStat)
            {
                Console.ResetColor();
                Console.Write(StatConfirmation);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Correctly);
                Console.ResetColor();
                Console.WriteLine();
                statCreated = true;
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
                return 0;
            }
        }

        
        public static int RandStat(int minStat, int maxStat)
        {
            Random random = new Random();
            return random.Next(minStat, maxStat + 1);
        }
    }
}