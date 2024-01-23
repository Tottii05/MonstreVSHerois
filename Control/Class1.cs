using System;

namespace Control
{
    public class Check
    {
        public const string StatsFail = "Has fallado 3 veces creando la stat y se te ha asignado los valores mínimos de la stat";
        public static bool MenuChoiceInput(int menuChoice, ref int menuTries)
        {
            const string MenuWrongChoice = "Elegiste un valor no permitido prueba otra vez, te quedan estos intentos: {0} ";
            const string Bye = "Hasta pronto! :D ";
            const string Play = "Perfecto, vamos a jugar!";

            switch (menuChoice)
            {
                case 0:
                    Console.WriteLine(Bye);
                    return true;
                case 1:
                    Console.WriteLine(Play);
                    return true;
                default:
                    Console.WriteLine(MenuWrongChoice, menuTries - 1);
                    menuTries--;
                    return false;
            }
        }

        public static bool NamesInput (string names)
        {
            const string CommasWrong = "Ahi no hay 4 nombres separados por comas";
            const string LengthWrong = "Venga hombre, ahí no caben 4 nombres";
            const int MinLength = 12, MinCommas = 3;
            int commas = 0;

            foreach (char c in names)
            {
                if (c ==  ',')
                {
                    commas++;
                }
            }

            if (commas < MinCommas)
            {
                Console.WriteLine(CommasWrong);
                return false;
            }
            if (names.Length < MinLength)
            {
                Console.WriteLine(LengthWrong);
                return false;
            }
            return true;
        }

        public static bool MenuNoTries()
        {
            const string MenuOutOftries = "Te quedaste sin intentos en un menú, madre mía...";

            Console.WriteLine(MenuOutOftries);

            return true;
        }
        public static void CreateNoTries(ref int tries, ref bool statCreated, ref float stat, int MinStat)
        {
            if (tries == 0)
            {
                Console.WriteLine(StatsFail);
                stat = MinStat;
                tries = 3;
                statCreated = true;
            }
        }
        public static void FightNoTries(ref int battletries, ref bool characterDone)
        {
            const string BattleFail = "Te quedaste sin intentos y perdiste el turno con este personaje";

            if (battletries == 0)
            {
                Console.WriteLine(BattleFail);
                Console.WriteLine();
                battletries = 3;
                characterDone = true;
            }
        }

        public static bool CDs (int cdSecs)
        {
            const string CDText = "La habilidad esta en enfriamiento";

            if (cdSecs > 0)
            {
                Console.WriteLine(CDText);
                Console.WriteLine();
                return false;
            }
            return true;
        }

        public static bool OverHeal (float originalHp, float actualHp, int heal)
        {
            if (actualHp + heal > originalHp)
            {
                return true;
            }
            return false;
        }
    }
}