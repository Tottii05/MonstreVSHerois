using Characters;
using Control;
using Rounds;
using System.Threading;
namespace GameProject
{
    class VicenteTomasCode
    {
        static void Main(string[] args)
        {
            /* Constantes para los menús de inicio */
            const string Menu = "Que querés hacer? | 0 - Salir  1 - Jugar |";
            const string Bye = "Hasta pronto! :D ";
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
            

            /* Constantes para las rondas */
            const string triesAdvert = " te quedan estos intentos: ";

            const string BattleStart = "Empieza la ";
            const string Battle = "BATALLA";

            const string NextRound = "Pulsa cualquier tecla para jugar la siguiente ronda:";
            const string CharacterUseM = "Estás usando al ";
            const string CharacterUseF = "Estás usando a la ";
            const string RoundsChoiceText = "| 1 - Atacar | 2 - Defenderse | 3 - Habilidad especial |";

            const string MonsterAttack = "Ataca a los presentes";

            const string ArcherSpecialMove = "atontando y dejando inutilizado al enemigo durante 2 turnos";
            const string BarbarSpecialMove = "ahora es inmune al daño durante 3 turnos";
            const string MageSpecialMove = "triplica su daño en este turno infligiendo: ";
            const string DruidSpecialMove = "se concentra y usa su magia curativa, ";

            const string StunEfect = "está atontado y no puede golpear!";
            const string CDText = "La habilidad esta en enfriamiento, debes esperar esta cantidad de rondas: ";
            const string Victory = "VICTORIA! ";
            const string VictoryText = "Enorabuena has vencido al monstruo!";
            const string Defeat = "DERROTA ";
            const string DefeatText = "el montruo a derrotado a todo tu escuadrón";


            /* Constantes para valores de personajes */


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
            int menuChoice, menuTries = 3, difficultyChoice; ;
            bool leaveMenu = false, leaveNames = false;
            string inputNames = "";
            string[] names = new string[4];

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
            bool MonsterDead = false, characterDone = false;

            /* Variables para los turnos*/
            int battletries = 3, characters = 4, round = 1, roundsChoice, stunRounds = 0, stunCD = 0, heavyArmorRounds = 0, heavyArmorCD = 0, MageCD = 0, DruidCD = 0;
            int order = 0;
            bool characAlive = true, specialReady = true;
            float[] Hps = new float[5]; 

            const string NamesInput = "Introduce los nombres de los personajes separados por comas, el orden es (1. arquera, 2. bárbaro, 3. maga, 4. druida)";
            

            ///////////             MENÚ INICIAL              ///////////
            do
            {
                Console.WriteLine(Menu);
                menuChoice = Convert.ToInt32(Console.ReadLine());
                leaveMenu = Check.MenuChoiceInput(menuChoice, ref menuTries);
                if (menuTries == 0) { leaveMenu = Check.MenuNoTries(); }
            } while (!leaveMenu);
            if (menuChoice == 1)
            {
                Console.WriteLine(NamesInput);
                do
                {
                    inputNames = Console.ReadLine();
                    leaveNames = Check.NamesInput(inputNames);
                } while (!leaveNames);
                string[] splitedNames = inputNames.Split(',');
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = splitedNames[i];
                }
                Console.WriteLine(Difficulty);
                difficultyChoice = Convert.ToInt32(Console.ReadLine());
                switch (difficultyChoice)
                {
                    case 0:
                        Console.WriteLine(EasyMode);
                        // Arquera con todo al máximo //
                        ArcherHP = ArcherHpMax;
                        ArcherAtk = ArcherAtkMax;
                        ArcherDef = ArcherDefMax;
                        // // 
                        BarbarHP = BarbarHpMax;
                        BarbarAtk = ArcherAtkMax;
                        BarbarDef = ArcherDefMax;
                        // //
                        MageHP = MageHpMax;
                        MageAtk = MageAtkMax;
                        MageDef = MageDefMax;
                        // //
                        DruidHP = DruidHpMax;
                        DruidAtk = DruidAtkMax;
                        DruidDef = DruidDefMax;
                        // //
                        MonsterHP = MonsterHpMin;
                        MonsterAtk = DruidAtkMin;
                        MonsterDef = DruidDefMin;
                        break;
                    case 1:
                        Console.WriteLine(HardMode);
                        ArcherHP = ArcherHpMin;
                        ArcherAtk = ArcherAtkMin;
                        ArcherDef = ArcherDefMin;
                        // // 
                        BarbarHP = BarbarHpMin;
                        BarbarAtk = ArcherAtkMin;
                        BarbarDef = ArcherDefMin;
                        // //
                        MageHP = MageHpMin;
                        MageAtk = MageAtkMin;
                        MageDef = MageDefMin;
                        // //
                        DruidHP = DruidHpMin;
                        DruidAtk = DruidAtkMin;
                        DruidDef = DruidDefMin;
                        // //
                        MonsterHP = MonsterHpMax;
                        MonsterAtk = MonsterAtkMax;
                        MonsterDef = MonsterDefMax;
                        break;
                    case 2:
                        Console.WriteLine(CustomMode);
                        // CREACION ARQUERA //
                        do
                        {
                            Console.WriteLine(HpStat, ArcherHpMin, ArcherHpMax);
                            ArcherHP = Convert.ToInt32(Console.ReadLine());
                            ArcherHP = Create.Stat(ref tries, ref statCreated, ArcherHP, ArcherHpMin, ArcherHpMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref ArcherHP, ArcherHpMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(AtkStat, ArcherAtkMin, ArcherAtkMax);
                            ArcherAtk = Convert.ToInt32(Console.ReadLine());
                            ArcherAtk = Create.Stat(ref tries, ref statCreated, ArcherAtk, ArcherAtkMin, ArcherAtkMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref ArcherAtk, ArcherAtkMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(DefStat, ArcherDefMin, ArcherDefMax);
                            ArcherDef = Convert.ToInt32(Console.ReadLine());
                            ArcherDef = Create.Stat(ref tries, ref statCreated, ArcherDef, ArcherDefMin, ArcherDefMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref ArcherDef, ArcherDefMin);
                        } while (!statCreated);
                        // CREACION BARBARO //
                        do
                        {
                            Console.WriteLine(HpStat, BarbarHpMin, BarbarHpMax);
                            BarbarHP = Convert.ToInt32(Console.ReadLine());
                            BarbarHP = Create.Stat(ref tries, ref statCreated, BarbarHP, BarbarHpMin, BarbarHpMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref BarbarHP, BarbarHpMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(AtkStat, BarbarAtkMin, BarbarAtkMax);
                            BarbarAtk = Convert.ToInt32(Console.ReadLine());
                            BarbarAtk = Create.Stat(ref tries, ref statCreated, BarbarAtk, BarbarAtkMin, BarbarAtkMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref BarbarAtk, BarbarAtkMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(DefStat, MageDefMin, MageDefMax);
                            BarbarDef = Convert.ToInt32(Console.ReadLine());
                            BarbarDef = Create.Stat(ref tries, ref statCreated, BarbarDef, BarbarDefMin, BarbarDefMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref BarbarDef, BarbarDefMin);
                        } while (!statCreated);
                        // CREACION MAGA //
                        do
                        {
                            Console.WriteLine(HpStat, DruidHpMin, DruidHpMax);
                            MageHP = Convert.ToInt32(Console.ReadLine());
                            MageHP = Create.Stat(ref tries, ref statCreated, MageHP, MageHpMin, MageHpMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MageHP, MageHpMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(AtkStat, MageAtkMin, MageAtkMax);
                            MageAtk = Convert.ToInt32(Console.ReadLine());
                            MageAtk = Create.Stat(ref tries, ref statCreated, MageAtk, MageAtkMin, MageAtkMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MageAtk, MageAtkMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(DefStat, MageDefMin, MageDefMax);
                            MageDef = Convert.ToInt32(Console.ReadLine());
                            MageDef = Create.Stat(ref tries, ref statCreated, MageDef, MageDefMin, MageDefMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MageDef, MageDefMin);
                        } while (!statCreated);
                        // CREACION DRUIDA //
                        do
                        {
                            Console.WriteLine(HpStat, ArcherHpMin, ArcherHpMax);
                            DruidHP = Convert.ToInt32(Console.ReadLine());
                            DruidHP = Create.Stat(ref tries, ref statCreated, DruidHP, DruidHpMin, DruidHpMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref DruidHP, DruidHpMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(AtkStat, DruidAtkMin, DruidAtkMax);
                            DruidAtk = Convert.ToInt32(Console.ReadLine());
                            DruidAtk = Create.Stat(ref tries, ref statCreated, DruidAtk, DruidAtkMin, DruidAtkMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref DruidAtk, DruidAtkMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(DefStat, DruidDefMin, DruidDefMax);
                            DruidDef = Convert.ToInt32(Console.ReadLine());
                            DruidDef = Create.Stat(ref tries, ref statCreated, DruidDef, DruidDefMin, DruidDefMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref DruidDef, DruidDefMin);
                        } while (!statCreated);
                        // CREACION MONSTRUO //
                        do
                        {
                            Console.WriteLine(HpStat, ArcherHpMin, ArcherHpMax);
                            MonsterHP = Convert.ToInt32(Console.ReadLine());
                            MonsterHP = Create.Stat(ref tries, ref statCreated, MonsterHP, MonsterHpMin, MonsterHpMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MonsterHP, MonsterHpMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(AtkStat, MonsterAtkMin, MonsterAtkMax);
                            MonsterAtk = Convert.ToInt32(Console.ReadLine());
                            MonsterAtk = Create.Stat(ref tries, ref statCreated, MonsterAtk, MonsterAtkMin, MonsterAtkMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MonsterAtk, MonsterAtkMin);
                        } while (!statCreated);
                        do
                        {
                            Console.WriteLine(DefStat, MonsterDefMin, MonsterDefMax);
                            MonsterDef = Convert.ToInt32(Console.ReadLine());
                            MonsterDef = Create.Stat(ref tries, ref statCreated, MonsterDef, MonsterDefMin, MonsterDefMax);
                            Check.CreateNoTries(ref tries, ref statCreated, ref MonsterDef, MonsterDefMin);
                        } while (!statCreated);
                        break;
                    case 3:
                        Console.WriteLine(RandomMode);
                        // //
                        ArcherHP = Create.RandStat(ArcherHpMin, ArcherHpMax);
                        ArcherAtk = Create.RandStat(ArcherAtkMin, ArcherAtkMax);
                        ArcherDef = Create.RandStat(ArcherDefMin, ArcherDefMax);
                        // // 
                        BarbarHP = Create.RandStat(BarbarHpMin, BarbarHpMax);
                        BarbarAtk = Create.RandStat(BarbarAtkMin, BarbarAtkMax);
                        BarbarDef = Create.RandStat(BarbarDefMin, BarbarDefMax);
                        // //
                        MageHP = Create.RandStat(MageHpMin, MageHpMax);
                        MageAtk = Create.RandStat(MageAtkMin, MageAtkMax);
                        MageDef = Create.RandStat(MageDefMin, MageDefMax);
                        // //
                        DruidHP = Create.RandStat(DruidHpMin, DruidHpMax);
                        DruidAtk = Create.RandStat(DruidAtkMin, DruidAtkMax);
                        DruidDef = Create.RandStat(DruidDefMin, DruidDefMax);
                        // //
                        MonsterHP = Create.RandStat(MonsterHpMin, MonsterHpMax);
                        MonsterAtk = Create.RandStat(MonsterAtkMin, MonsterAtkMax);
                        MonsterDef = Create.RandStat(MonsterDefMin, MonsterDefMax);
                        break;
                }
                Thread.Sleep(900);
                Console.Clear();
                /* Se asignan los valores de vida en una array */
                Hps[0] = MonsterHP; Hps[1] = ArcherHP; Hps[2] = BarbarHP; Hps[3] = MageHP; Hps[4] = DruidHP;
                /* Se guardan los valores de vida originales para controlar la cura del druida */
                OriginalArcherHP = ArcherHP;
                OriginalBarbarHP = BarbarHP;
                OriginalMageHP = MageHP;
                OriginalDruidHP = DruidHP;

                /* Se asignan los valores de enfriamiento de las habilidades especiales */
                do
                {
                    characterDone = false;
                    /* Se ordena la array de vidas de manera descendente y se muestra*/
                    Hps = Fight.DescHps(Hps);
                    Fight.ShowHps(Hps, names);
                    /* Se almacena el valor de la vida original en caso de que quiera curar el druida no se pase del valor original */
                    ArcherDef = OriginalArcherDef;
                    BarbarDef = OriginalBarbarDef;
                    MageDef = OriginalMageDef;
                    DruidDef = OriginalDruidDef;

                    /* Restar turnos a la cantidad de turnos de enfriamiento de habilidades especiales */
                    stunCD--;
                    heavyArmorRounds--;
                    heavyArmorCD--;
                    MageCD--;
                    DruidCD--;
                    if (!MonsterDead && Fight.CheckCharacAlive(ArcherHP))
                    {
                        do
                        {
                            order = Fight.RandOrder(characters);
                            Console.WriteLine("turno de: " + names[order]);
                            Console.WriteLine(RoundsChoiceText);
                            roundsChoice = Convert.ToInt32(Console.ReadLine());
                            switch (order)
                            {
                                case 0:
                                    switch (roundsChoice)
                                    {
                                        case 1:
                                            Hps[4] = Fight.Attack(names[0], ArcherAtk, MonsterDef, MonsterHP, ref characterDone);
                                            break;
                                        case 2:
                                            ArcherDef = Fight.Deffense(names[0], ArcherDef, ref characterDone);
                                            break;
                                        case 3:
                                            if (stunCD > 0)
                                            {
                                                Console.WriteLine(CDText + stunRounds);
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                stunRounds = 2;
                                                stunCD = 5;
                                                characterDone = Fight.SpecialAttack(names[0]);
                                                Console.WriteLine(ArcherSpecialMove);
                                            }
                                            break;
                                        default:
                                            Console.WriteLine(WrongNum);
                                            battletries--;
                                            Console.WriteLine(triesAdvert, battletries);
                                            Check.FightNoTries(ref battletries, ref characterDone);
                                            break;
                                    }
                                break;
                                case 1:
                                    switch (roundsChoice)
                                    {
                                        case 1:
                                            Hps[4] = Fight.Attack(names[1], BarbarAtk, MonsterDef, MonsterHP, ref characterDone);
                                            break;
                                        case 2:
                                            ArcherDef = Fight.Deffense(names[1], BarbarDef, ref characterDone);
                                            break;
                                        case 3:
                                            if (stunCD > 0)
                                            {
                                                Console.WriteLine(CDText + stunRounds);
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                stunRounds = 2;
                                                stunCD = 5;
                                                characterDone = Fight.SpecialAttack(names[1]);

                                            }
                                            break;
                                        default:
                                            Console.WriteLine(WrongNum);
                                            battletries--;
                                            Console.WriteLine(triesAdvert, battletries);
                                            Check.FightNoTries(ref battletries, ref characterDone);
                                            break;
                                    }
                                break;
                            }
                        } while (!characterDone);
                    }
                } while (!MonsterDead || characters == 0);
            }
        }
    }
}