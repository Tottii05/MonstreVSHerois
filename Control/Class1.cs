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

            if (menuChoice == 0)
            {
                Console.WriteLine(Bye);
                return true;
            }
            else if (menuChoice == 1)
            {
                Console.WriteLine(Play);
                return true;
            }
            else
            {
                Console.WriteLine(MenuWrongChoice, menuTries - 1);
                menuTries--;
                return menuTries > 0;
            }
        }
        public static bool MenuNoTries()
        {
            const string MenuOutOftries = "Te quedaste sin intentos en un menú, madre mía...";

            Console.WriteLine(MenuOutOftries);

            return true;
        }
        public static void CreateNoTries(int tries, ref bool statCreated, ref float[,] values, int xindex, int yindex)
        {
            if (values[xindex, yindex] > 0)
            {
                statCreated = true;
            }
            if (tries == 0)
            {
                Console.WriteLine(StatsFail);
                values[xindex, yindex] = values[xindex,yindex+1];
                statCreated = true;
            }
        }
    }
}