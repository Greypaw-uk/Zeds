using System;

namespace Zeds.Pawns.HumanLogic
{
    public class HumanAttributes
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static bool IsPawnMale()
        {
            if (random.Next(100) < 49)
                return true;
            else
                return false;
        }

        public static int GetHumansAge()
        {
            var x = random.Next(100);

            if (x <= 25)
                return random.Next(18, 23);
            if (x >= 26 && x <= 75)
                return random.Next(24, 55); 
            if (x >= 76 && x <= 85)
                return random.Next(55, 60);

            return random.Next(61, 75);
        }
    }
}