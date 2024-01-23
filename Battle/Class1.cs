

using System;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

            return luckyCritic == random;
        }

        public static bool IsDodged ()
        {
            int luckyDodge = 3;
            Random rnd = new Random();
            int random = rnd.Next(1, 21);

            return luckyDodge == random;
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

        public static void ShowHps (float archerHp, float barbarHp, float mageHp, float druidHp, float monsterHp, string[] names)
        {
            const string Dead = "MUERTO";
            Console.WriteLine(Monster + monsterHp);
            if (archerHp < 1) { Console.WriteLine(names[0] + " " + Dead); }
            else { Console.WriteLine(names[0] + " " + archerHp); }
            if (barbarHp < 1) { Console.WriteLine(names[1] + " " + Dead); }
            else { Console.WriteLine(names[1] + " " + barbarHp); }
            if (mageHp < 1) { Console.WriteLine(names[2] + " " + Dead); }
            else { Console.WriteLine(names[2] + " " + mageHp); }
            if (druidHp < 1) { Console.WriteLine(names[3] + " " + Dead); }
            else { Console.WriteLine(names[3] + " " + druidHp); }

            Console.WriteLine();
        }

        public static bool CheckCharacAlive (float actualHP)
        {

            return actualHP > 0;
        }

        public static float[] FillHps(float archerHp, float barbarHp, float mageHp, float druidHp, float[] Hps)
        {
            Hps[0] = archerHp; Hps[1] = barbarHp; Hps[2] = mageHp; Hps[3] = druidHp;
            return Hps;
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

        public static int RandOrder(int cantCharacters)
        {
            int lastNumber = -1;

            if (lastNumber == -1)
            {
                lastNumber = new Random().Next(cantCharacters);
                return lastNumber;
            }

            int randomNumber;
            Random rnd = new Random();

            do
            {
                randomNumber = rnd.Next(cantCharacters);
            } while (randomNumber == lastNumber);

            lastNumber = randomNumber;
            return randomNumber;
        }

        public static float Attack(string name, float attackValue, float monsterDef, float monsterHP, ref bool characterDone, bool critic, bool dodge)
        {
            const string Attacks = " ataca a ";
            const string Doing = "inflgiendo ";
            const string Dmg = " de daño";
            const string CriticText = "Criticooooo";
            const string DodgeText = "El enemigo esquiva tu ataque";
            float lowerAttack = attackValue * monsterDef / Hundred;

            if (critic == true)
            {
                Console.WriteLine(CriticText);
                lowerAttack = (attackValue * monsterDef / Hundred) - attackValue;
                return monsterHP + (lowerAttack * 2);
            }
            if (dodge == true)
            {
                attackValue = 0;
                Console.WriteLine(DodgeText);
            }
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

        public static float OverHeal(string nameDruid, string nameCharac, float actualHp, float originalHp)
        {
            const string Heals = " cura a su compañero ";
            const string Life = " de vida ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nameDruid);
            Console.ResetColor();
            Console.Write(Heals);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nameCharac);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" + ");
            Console.Write(originalHp - actualHp);
            Console.Write(Life);
            Console.ResetColor();
            Console.WriteLine();
            return actualHp = originalHp;
        }

        public static float NormalHeal (string nameDruid, string nameCharac, float actualHp, int heal)
        {
            const string Heals = " cura a su compañero ";
            const string Life = " de vida ";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nameDruid);
            Console.ResetColor();
            Console.Write(Heals);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nameCharac);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Life);
            Console.ResetColor();
            return actualHp += heal;
        }

        public static bool Stunned (ref int stunRounds, ref bool CharacterDone)
        {
            const string StunEfect = "está atontado y no puede golpear!";

            if (stunRounds > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Monster);
                Console.ResetColor();
                Console.WriteLine(StunEfect);
                Console.WriteLine();
                stunRounds--;
                CharacterDone = true;
                return true;
            }
            return false;
        }

        public static void MonsterAttackText(string archerNm, string barbarNm, string mageNm, string druidNm, float dmg)
        {
            const string MonsterAttacks = "Ataca a los presentes";

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Monster);
            Console.ResetColor();
            Console.WriteLine(MonsterAttacks);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(archerNm);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" - ");
            Console.WriteLine(dmg);
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(barbarNm);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" - ");
            Console.WriteLine(dmg);
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(mageNm);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" - ");
            Console.WriteLine(dmg);
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(druidNm);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" - ");
            Console.WriteLine(dmg);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static bool MonsterAttack(ref float archerHp, float archerDef, ref float barbarHp, float barbarDef, ref float mageHp, float mageDef, ref float druidHp, float druidDef, float dmg, ref int characters)
        {
            mageHp = mageHp + ((dmg * mageDef / Hundred) - dmg);
            if (mageHp < 1)
            {
                characters = 3;
            }
            archerHp = archerHp + ((dmg * archerDef / Hundred) - dmg);
            if (archerHp < 1)
            {
                characters = 2;
            }
            druidHp = druidHp + ((dmg * druidDef / Hundred) - dmg);
            if (druidHp < 1)
            {
                characters = 1;
            }
            barbarHp = barbarHp + ((dmg * barbarDef / Hundred) - dmg);
            if (barbarHp < 1)
            {
                characters = 0;
            }
            return true;
        }

        public static void ShowEnding (bool MonsterDead)
        {
            const string Victory = "VICTORIA! ";
            const string VictoryText = "Enorabuena has vencido al monstruo!";
            const string Defeat = "DERROTA ";
            const string DefeatText = "el montruo a derrotado a todo tu escuadrón";

            if (MonsterDead == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Victory);
                Console.ResetColor();
                Console.WriteLine(VictoryText);
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Defeat);
                Console.ResetColor();
                Console.WriteLine(DefeatText);
                Console.WriteLine();
            }
        }
    }
}









