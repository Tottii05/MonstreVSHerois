using Characters;
using Control;
namespace GameProject
{
    class VicenteTomasCode
    {
        static void Main(string[] args)
        {
            /* Constantes para los menús de inicio */
            const string Menu = "Que querés hacer? | 0 - Salir  1 - Jugar |";
            const string Difficulty = "Elige la dificultad del juego | 0 - Fácil 1 - Difícil - 2 - Custom - 3 - Random|";
            const string EasyMode = "Has elegido la dificultad fácil, tienes las máximas stats posibles";
            const string HardMode = "Has elegido la dificultad difícil, tienes las mínimas stats posibles";
            const string CustomMode = "Has elegido la dificultad custom, puedes elegir las stats";
            const string RandomMode = "Has elegido la dificultad random, stats randooom!!";

            /* Constantes para la creación de personajes */
            const string HpStat = "Introduce el valor de la vida [ {0} - {1} ]";
            const string AtkStat = "Introduce el valor del ataque [ {0} - {1} ]";
            const string DefStat = "Introduce el valor de la defensa [ {0} - {1} ]";
            const string WrongNum = "Has puesto un valor fuera del rango, ";
            const string TryAgain = "prueba otra vez:";
            const string StatConfirmation = "La stat ha sido creada ";
            const string Correctly = "CORRECTAMENTE";
            const string triesIndicator = "Te quedan estos intentos para crear la stat: ";
            const string CharacterConfirmation = "El personaje ha sido creado correctamente";
            const string CharacterFail = "Te has quedado sin intentos para crear el personaje";
            const string CharacterIntroductionM = "Estás creando al ";
            const string CharacterIntroductionF = "Estás creando a la ";
            const string Archer = "ARQUERA ";
            const string Barbar = "BÁRBARO ";
            const string Mage = "MAGA ";
            const string Druid = "DRUIDA ";
            const string Monster = "MONSTRUO ";

            /* Constantes para las rondas */
            const string triesAdvert = " te quedan estos intentos: ";
            const string BattleFail = "Te quedaste sin intentos para hacer la batalla, a crearlo todo otra vez.";
            const string BattleStart = "Empieza la ";
            const string Battle = "BATALLA";
            const string Rounds = "Ronda: ";
            const string NextRound = "Pulsa cualquier tecla para jugar la siguiente ronda:";
            const string CharacterUseM = "Estás usando al ";
            const string CharacterUseF = "Estás usando a la ";
            const string RoundsChoiceText = "| 1 - Atacar | 2 - Defenderse | 3 - Habilidad especial |";
            const string Attack = "Ataca a ";
            const string MonsterAttack = "Ataca a los presentes";
            const string Doing = "inflgiendo ";
            const string Dmg = " de daño";
            const string LifeText = "ahora tiene esta cantidad ";
            const string Life = "de vida: ";
            const string DuplicateDefense = "ahora duplica su defensa siendo ahora: ";
            const string ArcherSpecialMove = "atonta y deja inutilizado durante 2 turnos a: ";
            const string BarbarSpecialMove = "ahora es inmune al daño durante 3 turnos";
            const string MageSpecialMove = "triplica su daño en este turno infligiendo: ";
            const string DruidSpecialMove = "se concentra y usa su magia curativa, ";
            const string StunEfect = "está atontado y no puede golpear!";
            const string CDText = "La habilidad esta en enfriamiento, debes esperar esta cantidad de rondas: ";
            const string Victory = "VICTORIA! ";
            const string VictoryText = "Enorabuena has vencido al monstruo!";
            const string Defeat = "DERROTA ";
            const string DefeatText = "el montruo a derrotado a todo tu escuadrón";
            const string DeadF = " MUERTA";
            const string DeadM = " MUERTO";

            /* Constantes para valores de personajes */
            const int Hundred = 100;

            // Constantes para la arquera //
            const int ArcherHpMin = 1500, ArcherHpMax = 2000, ArcherAtkMin = 180, ArcherAtkMax = 300, ArcherDefMin = 25, ArcherDefMax = 40;

            // Constantes para el bárbaro //
            const int BarbarHpMin = 3000, BarbarHpMax = 3750, BarbarAtkMin = 150, BarbarAtkMax = 250, BarbarDefMin = 35, BarbarDefMax = 45;

            // Constantes para la maga //
            const int MageHpMin = 1000, MageHpMax = 1500, MageAtkMin = 300, MageAtkMax = 350, MageDefMin = 20, MageDefMax = 35;

            // Constantes para el druida //
            const int DruidHpMin = 2000, DruidHpMax = 2500, DruidAtkMin = 70, DruidAtkMax = 120, DruidDefMin = 25, DruidDefMax = 40, DruidHeal = 500;

            // Constantes para el montruo //
            const int MonsterHpMin = 9000, MonsterHpMax = 12000, MonsterAtkMin = 250, MonsterAtkMax = 400, MonsterDefMin = 20, MonsterDefMax = 30;

            /* Variables para la creación de personaje y estadísticas */
            int tries = 3, globalTries;
            bool statCreated = false, characterCreated = false, allCharacterCreated = false;

            /* Variables para los menús */
            int menuChoice, menuTries = 3;
            int difficultyChoice;
            bool leaveMenu = false;

            /* Variables sobre las estadísticcas del personaje */
            // Estadísticas de la arquera //
            float ArcherHP = 0, OriginalArcherHP = 0, ArcherAtk = 0, ArcherDef = 0, OriginalArcherDef = 0;

            // Estadísticas del bárbaro //
            float BarbarHP = 0, OriginalBarbarHP = 0, BarbarAtk = 0, BarbarDef = 0, OriginalBarbarDef = 0;

            // Estadísticas de la maga //
            float MageHP = 0, OriginalMageHP = 0, MageAtk = 0, MageDef = 0, OriginalMageDef = 0;

            // Estadísticas del druida //
            float DruidHP = 0, OriginalDruidHP = 0, DruidAtk = 0, DruidDef = 0, OriginalDruidDef = 0;

            // Estadísticas del monstruo //
            float MonsterHP = 0, MonsterAtk = 0, MonsterDef = 0;
            bool MonsterDead = false, CharacterDone = false;

            /* Variables para los turnos*/
            int battletries = 3, CharactersAlive = 4, round = 1, roundsChoice, stunRounds = 0, stunCD = 0, heavyArmorRounds = 0, heavyArmorCD = 0, MageCD = 0, DruidCD = 0;

            const string RangeValues = "Para crear la stat elige un valor entre {0} y {1}";

            const int MaxCharac = 4;
            const int MaxStats = 3;
            const string NamesInput = "Introduce los nombres de los personajes separados por comas:";
            float[,] characters = new float[MaxCharac, MaxStats];

            int[,] statValues = new int[,]
            {
                { ArcherHpMin, BarbarHpMin, MageHpMin, DruidHpMin },
                { ArcherHpMax, BarbarHpMax, MageHpMax, DruidHpMax },
                { ArcherAtkMin, BarbarAtkMin, MageAtkMin, DruidAtkMin },
                { ArcherAtkMax, BarbarAtkMax, MageAtkMax, DruidAtkMax },
                { ArcherDefMin, BarbarDefMin, MageDefMin, DruidDefMin },
                { ArcherDefMax, BarbarDefMax, MageDefMax, DruidDefMax }
            };

            float stat = 0;

            ///////////             MENÚ INICIAL              ///////////
            do
            {
                Console.WriteLine(Menu);
                menuChoice = Convert.ToInt32(Console.ReadLine());
                leaveMenu = Check.MenuChoiceInput(menuChoice, ref menuTries);
                if (leaveMenu == false) { leaveMenu = Check.MenuNoTries(); }
            } while (!leaveMenu);
            if (menuChoice == 1)
            {
                Console.WriteLine(NamesInput);
                string inputNames = Console.ReadLine();
                string[] names = inputNames.Split(',');
                Console.WriteLine(Difficulty);
                difficultyChoice = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < characters.GetLength(0)-1; i++)
                {
                    for (int j = 0; j < characters.GetLength(1)-1; j++)
                    {
                        switch (difficultyChoice)
                        {
                            case 0:
                                Console.WriteLine(EasyMode);
                                characters[i, j] = Create.MinStat(statValues, i, j);
                                break;
                            case 1:
                                Console.WriteLine(HardMode);
                                characters[i, j+1] = Create.MaxStat(statValues, i, j);
                                break;
                            case 2:
                                Console.WriteLine(CustomMode);
                                do
                                {
                                    Console.WriteLine(RangeValues, statValues[i,j], statValues[i,j+1]);
                                    stat = Convert.ToSingle(Console.ReadLine());
                                    characters[i,j] = Create.CustomStats(ref tries, ref statCreated, stat, statValues, i, j);
                                    Check.CreateNoTries(tries, ref statCreated, ref characters, i , j);
                                } while (!statCreated);
                                break;
                            case 3:
                                Console.WriteLine(RandomMode);
                                characters[i, j+2] = Create.RandStat(statValues, i, j);
                                break;
                        }
                    }
                }
            }
        }
    }
}