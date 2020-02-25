using System;

namespace Zeds.Pawns.HumanLogic
{
    public class HumanAttributes
    {
        public static bool IsPawnMale()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(0, 1) != 0;
        }

        public static int GetHumansAge()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
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