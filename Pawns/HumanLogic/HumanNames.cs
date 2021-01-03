using System;
using System.Collections.Generic;

namespace Zeds.Pawns.HumanLogic
{
    class HumanNames
    {
        private static List<string> maleNamesUk = new List<string>();
        private static List<string> femaleNamesUk = new List<string>();
        private static List<string> surnamesUk = new List<string>();


        private static Random random = new Random();

        public static void PopulateNamesLists()
        {
            GenerateUKMaleNames();
            GenerateUKFemaleNames();
            GenerateUKSurnames();
        }

        public static string GetHumanFullName(bool isMale)
        {
            if (isMale)
                return GetUKMaleNames() + " " + GetUKSurnames();
            else
                return GetUKFemaleNames() + " " + GetUKSurnames();
        }
        

        private static string GetUKMaleNames()
        {
            return maleNamesUk[random.Next(0, maleNamesUk.Count)];
        }

        private static string GetUKFemaleNames()
        {
            return femaleNamesUk[random.Next(0, femaleNamesUk.Count)];
        }

        private static string GetUKSurnames()
        {
            return surnamesUk[random.Next(0, surnamesUk.Count)];
        }

        private static void GenerateUKMaleNames()
        {
            maleNamesUk.Add("John");
            maleNamesUk.Add("Paul");
            maleNamesUk.Add("Andrew");
            maleNamesUk.Add("Mark");
            maleNamesUk.Add("Steve");
            maleNamesUk.Add("Peter");
            maleNamesUk.Add("Ian");
            maleNamesUk.Add("Chris");
            maleNamesUk.Add("Richard");
            maleNamesUk.Add("Andy");

            maleNamesUk.Add("Michael");
            maleNamesUk.Add("Martin");
            maleNamesUk.Add("Brian");
            maleNamesUk.Add("Tony");
            maleNamesUk.Add("Stephen");
            maleNamesUk.Add("Nick");
            maleNamesUk.Add("Kevin");
            maleNamesUk.Add("Dave");
            maleNamesUk.Add("Jonathon");
            maleNamesUk.Add("Gary");
        }

        private static void GenerateUKFemaleNames()
        {
            femaleNamesUk.Add("Karen");
            femaleNamesUk.Add("Julie");
            femaleNamesUk.Add("Claire");
            femaleNamesUk.Add("Alison");
            femaleNamesUk.Add("Sue");
            femaleNamesUk.Add("Louise");
            femaleNamesUk.Add("Jane");
            femaleNamesUk.Add("Emma");
            femaleNamesUk.Add("Lisa");
            femaleNamesUk.Add("Angela");

            femaleNamesUk.Add("Debbie");
            femaleNamesUk.Add("Anne");
            femaleNamesUk.Add("Fiona");
            femaleNamesUk.Add("Caroline");
            femaleNamesUk.Add("Rachel");
            femaleNamesUk.Add("Kate");
            femaleNamesUk.Add("Nicola");
            femaleNamesUk.Add("Linda");
            femaleNamesUk.Add("Joanne");
            femaleNamesUk.Add("Christine");
        }

        private static void GenerateUKSurnames()
        {
            surnamesUk.Add("Smith");
            surnamesUk.Add("Jones");
            surnamesUk.Add("Williams");
            surnamesUk.Add("Taylor");
            surnamesUk.Add("Davies");
            surnamesUk.Add("Brown");
            surnamesUk.Add("Wilson");
            surnamesUk.Add("Evans");
            surnamesUk.Add("Thomas");
            surnamesUk.Add("Johnson");

            surnamesUk.Add("Roberts");
            surnamesUk.Add("Walker");
            surnamesUk.Add("Wright");
            surnamesUk.Add("Robinson");
            surnamesUk.Add("Thompson");
            surnamesUk.Add("White");
            surnamesUk.Add("Hughes");
            surnamesUk.Add("Edwards");
            surnamesUk.Add("Green");
            surnamesUk.Add("Lewis");
        }
    }
}
