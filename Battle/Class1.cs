

namespace Rounds
{
    public class Fight
    {
         const string Monster = "MONSTRUO ";

        public const int Hundred = 100;
        public static bool IsCritic ()
        {
            int luckyCritic = 7;
            Random rnd = new Random();
            int random = rnd.Next(1, 11);

            return luckyCritic == random ? true: false;
        }

        public static bool IsDodged ()
        {
            int luckyDodge = 3;
            Random rnd = new Random();
            int random = rnd.Next(1, 21);

            return luckyDodge == random ? true : false;
        }

        public static void ShowRounds(int round)
        {
            const string Rounds = "Ronda: ";

            Console.Write(Rounds);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(round);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowHps (float[] Hps, string[] names)
        {
            for (int i = 0; i < Hps.Length - 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Monstruo " + Hps[i]);
                }
                else
                {
                    Console.WriteLine(names[i] + " " + Hps[i]);
                }
            }
            Console.WriteLine();
        }

        public static bool CheckCharacAlive (float actualHP)
        {

            return actualHP > 0;
        }

        public static float[] DescHps(float[] Hps)
        {
            for (int i = 0; i < Hps.Length - 1; i++)
            {
                for (int j = i + 1; j < Hps.Length; j++)
                {
                    if (Hps[j] > Hps[i])
                    {
                        float aux = Hps[i];
                        Hps[i] = Hps[j];
                        Hps[j] = aux;
                    }
                }
            }
            return Hps;
        }

        public static int RandOrder (int cantCharacters)
        {
            Random rnd = new Random();
            return rnd.Next (cantCharacters);
        }

        public static float Attack(string name, float attackValue, float monsterDef, float monsterHP, ref bool characterDone)
        {
             const string Attacks = " ataca a ";
             const string Doing = "inflgiendo ";
             const string Dmg = " de daño";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.Write(Attacks);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Monster);
            Console.ResetColor();
            Console.Write(Doing);
            Console.Write(attackValue - monsterDef);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Dmg);
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(Monster);
            Console.WriteLine();
            characterDone = true;
            return monsterHP + ((attackValue * monsterDef / Hundred) - attackValue);
        }
       
        public static float Deffense (string name, float defValue, ref bool characterDone)
        {
            const string DuplicateDefense = " ahora duplica su defensa";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.Write(DuplicateDefense);
            Console.WriteLine();
            characterDone = true;
            return defValue * 2;
        }

        public static bool SpecialAttack (string name)
        {
            const string SpecialMoveText = " usa su habilidad especial contra el ";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.Write(SpecialMoveText);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Monster);
            Console.ResetColor();
            Console.WriteLine();
            return true;
        } 
    }
}












