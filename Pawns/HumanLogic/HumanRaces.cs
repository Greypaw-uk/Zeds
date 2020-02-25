using System;
using System.Collections.Generic;

namespace Zeds.Pawns.HumanLogic
{
    class HumanRaces
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        private static List<string> raceList = new List<string>();

        public static void PopulateRaceList()
        {
            raceList.Add("WhiteEnglish");
        }

        public static int PickARace()
        {
            return random.Next(0, raceList.Count);
        }
    }
}
