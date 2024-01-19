namespace Rounds
{
    public class Battle
    {
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
    }
}
