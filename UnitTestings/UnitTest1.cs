using Characters;
using Control;
using Rounds;
using System.Xml.Linq;

namespace UnitTestings
{
    [TestClass]
    public class TESTINGS
    {
        // UNIT TESTINGS DE LA CLASE CHECK //

        [TestMethod]
        public void GoodMenuInput()
        {
            int menuChoice = 1, menuTries = 3;
            bool expected = true;

            bool result = Check.MenuChoiceInput(menuChoice, ref menuTries);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BadMenuInput()
        {
            int menuChoice = 3, menuTries = 3;
            bool expected = false;

            bool result = Check.MenuChoiceInput(menuChoice, ref menuTries);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GoodNamesInput()
        {
            string names = "arquera,barbaro,maga,druida";
            bool expected = true;

            bool result = Check.NamesInput(names);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BadNamesInput()
        {
            string names = "ta mal";
            bool expected = false;

            bool result = Check.NamesInput(names);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OutOfTriesFight()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            int battleTries = 0;
            bool characterDone = false;


            Check.FightNoTries(ref battleTries, ref characterDone);
            string expected = "Te quedaste sin intentos y perdiste el turno con este personaje";

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void OutOfTriesCreate()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            int tries = 0, minStat = 1;
            bool statCreated = false;
            float stat = 1;

            Check.CreateNoTries(ref tries, ref statCreated, ref stat, minStat);
            string expected = "Has fallado 3 veces creando la stat y se te ha asignado los valores mínimos de la stat";

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void OnCD()
        {
            int cds = 1;
            bool expected = false;

            bool result = Check.CDs(cds);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotOnCD()
        {
            int cds = -1;
            bool expected = true;

            bool result = Check.CDs(cds);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TrueOverHeal()
        {
            float originalHp = 1500, actualHp = 1000;
            int heal = 500;
            bool expected = false;

            bool result = Check.OverHeal(originalHp, actualHp, heal);

            Assert.AreEqual(expected, result);
        }

        // UNIT TESTINGS DE LA CLASE CREATE //

        [TestMethod]
        public void GoodCustomStat()
        {
            int tries = 3;
            bool statCreated = false;
            float valueStat = 1000;
            int MinStat = 1000, MaxStat = 1500;
            float expected = valueStat;

            float result = Create.Stat(ref tries, ref statCreated, valueStat, MinStat, MaxStat);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BadCustomStat()
        {
            int tries = 3;
            bool statCreated = false;
            float valueStat = 1;
            int MinStat = 1000, MaxStat = 1500;
            float expected = 0;

            float result = Create.Stat(ref tries, ref statCreated, valueStat, MinStat, MaxStat);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RandStat()
        {
            int minStat = 1000, maxStat = 1500;

            float result = Create.RandStat(minStat, maxStat);

            Assert.IsTrue(result >= minStat && result <= maxStat);
        }

        // UNIT TESTINGS DE LA CLASE FIGHT //
        [TestMethod]
        public void ShowRoundsVoid()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            int rounds = 7;
            string expected = "Ronda: " + rounds;


            Fight.ShowRounds(rounds);

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void AllCharacAlive()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            float archerHp = 1500, barbarHp = 3000, mageHp = 2000, druidHp = 2100, monsterHp = 9000;
            string[] names = { "arquera", "barbaro", "maga", "druida" };

            Fight.ShowHps(archerHp, barbarHp, mageHp, druidHp, monsterHp, names);
            string expected = "MONSTRUO 9000\r\narquera 1500\r\nbarbaro 3000\r\nmaga 2000\r\ndruida 2100";

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void SomeCharacDead()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            float archerHp = 0, barbarHp = 3000, mageHp = 2000, druidHp = 2100, monsterHp = 9000;
            string[] names = { "arquera", "barbaro", "maga", "druida" };

            Fight.ShowHps(archerHp, barbarHp, mageHp, druidHp, monsterHp, names);
            string expected = "MONSTRUO 9000\r\narquera MUERTO\r\nbarbaro 3000\r\nmaga 2000\r\ndruida 2100";

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void CharacAlive()
        {
            float actualHp = 1000;
            bool expected = true;

            bool result = Fight.CheckCharacAlive(actualHp);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CharacDead()
        {
            float actualHp = 0;
            bool expected = false;

            bool result = Fight.CheckCharacAlive(actualHp);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FilledHps()
        {
            float archerHp = 1000, barbarHp = 3000, mageHp = 2000, druidHp = 2100;
            float[] Hps = new float[4];

            float[] expected = { 1000, 3000, 2000, 2100};

            float[] result = Fight.FillHps(archerHp, barbarHp, mageHp, druidHp, Hps);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OrganizedHps()
        {
            float archerHp = 1000, barbarHp = 3000, mageHp = 2000, druidHp = 2100;
            float[] Hps = new float[4];

            float[] expected = { 1000, 3000, 2000, 2100 };

            float[] result = Fight.FillHps(archerHp, barbarHp, mageHp, druidHp, Hps);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NormalAttack()
        {
            string name = "Arquera";
            float attackValue = 300, monsterHP = 9000, monsterDef = 30;
            bool characterDone = false, critic = false, dodge = false;
            float expected = 8790;

            float result = Fight.Attack(name, attackValue, monsterDef, monsterHP, ref characterDone, critic, dodge);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CriticAttack()
        {
            string name = "Arquera";
            float attackValue = 300, monsterHP = 9000, monsterDef = 30;
            bool characterDone = false, critic = true, dodge = false;
            float expected = 8580;

            float result = Fight.Attack(name, attackValue, monsterDef, monsterHP, ref characterDone, critic, dodge);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DodgeAttack()
        {
            string name = "Arquera";
            float attackValue = 300, monsterHP = 9000, monsterDef = 30;
            bool characterDone = false, critic = false, dodge = true;
            float expected = 9000;

            float result = Fight.Attack(name, attackValue, monsterDef, monsterHP, ref characterDone, critic, dodge);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Deffense()
        {
            string name = "Arquera";
            float defValue = 40;
            bool characterDone = false;
            float expected = 80;

            float result = Fight.Deffense(name, defValue, ref characterDone);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SpecialAttackCheck()
        {
            string name = "Arquera";
            bool expected = true;

            bool result = Fight.SpecialAttack(name);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OverHeal()
        {
            string nameCharac = "Arquera", nameDruid = "Druida";
            float actualHp = 800, originalHp = 1000;
            float expected = originalHp;

            float result = Fight.OverHeal(nameDruid, nameCharac, actualHp, originalHp);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NormalHeal()
        {
            string nameCharac = "Arquera", nameDruid = "Druida";
            float actualHp = 800;
            int heal = 500;
            float expected = 1300;

            float result = Fight.NormalHeal(nameDruid, nameCharac, actualHp, heal);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Stunned()
        {
            int stunRounds = 2;
            bool CharacterDone = false, expected = true;

            bool result = Fight.Stunned(ref stunRounds, ref CharacterDone);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotStunned()
        {
            int stunRounds = 0;
            bool CharacterDone = false, expected = false;

            bool result = Fight.Stunned(ref stunRounds, ref CharacterDone);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MonsterAttackVoid()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            string archerNm = "arquera", barbarNm = "barbaro", mageNm = "maga", druidNm = "druida";
            float dmg = 70;

            Fight.MonsterAttackText(archerNm, barbarNm, mageNm, druidNm, dmg);
            string expected = "MONSTRUO Ataca a los presentes\r\n\r\narquera - 70\r\n\r\nbarbaro - 70\r\n\r\nmaga - 70\r\n\r\ndruida - 70";

            Assert.AreEqual(expected, sw.ToString().Trim());
        }

        [TestMethod]
        public void MonsterAttack()
        {
            float archerHp = 2000, barbarHp = 3750, mageHp = 1500, druidHp = 2500;
            float archerDef = 40, barbarDef = 45, mageDef = 35, druidDef = 40, dmg = 250;
            int characters = 4;
            bool expected = true;

            bool result = Fight.MonsterAttack(ref archerHp, archerDef, ref barbarHp, barbarDef, ref mageHp, mageDef, ref druidHp, druidHp, dmg, ref characters);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShowEndingWin()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            bool MonsterDead = true;
            string expected = "VICTORIA! " + "Enorabuena has vencido al monstruo!";

            Fight.ShowEnding(MonsterDead);

            Assert.AreEqual(sw.ToString().Trim(), expected);    
        }

        [TestMethod]
        public void ShowEndingLose()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            bool MonsterDead = false;
            string expected = "DERROTA " + "el montruo a derrotado a todo tu escuadrón";

            Fight.ShowEnding(MonsterDead);

            Assert.AreEqual(sw.ToString().Trim(), expected);
        }
    }
}