using System;
using System.Collections.Generic;

namespace Zeds.Pawns.HumanLogic
{
    class HumanOccupations
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        private static readonly List<string> occupationList = new List<string>();

        public static string GetOccupation(int age)
        {
            occupationList.Clear();

            if (age >= 18 && age <= 22)
                Get18To22Jobs();
            else if (age >= 23 && age <= 50)
                Get23To50Jobs();
            else if (age >= 51 && age <= 65)
                Get51To65Jobs();
            else
            {
                Get23To50Jobs();
                return "Retired " + occupationList[random.Next(0, occupationList.Count)];
            }

            return occupationList[random.Next(0, occupationList.Count)];
        }

        private static void Get18To22Jobs()
        {
            occupationList.Add("Student");
            occupationList.Add("Unemployed");
            occupationList.Add("Waiter");
            occupationList.Add("Retail Worker");
            occupationList.Add("Customer Service Assistant");
            occupationList.Add("Bar Tender");
            occupationList.Add("Influencer");
            occupationList.Add("Mechanic");
            occupationList.Add("Salesperson");
            occupationList.Add("Admin Assistant");
            occupationList.Add("Care Worker");

            occupationList.Add("Soldier");
            occupationList.Add("IT Assistant");
        }

        private static void Get23To50Jobs()
        {
            occupationList.Add("Teacher");
            occupationList.Add("Accountant");
            occupationList.Add("Consultant");
            occupationList.Add("Administrator");
            occupationList.Add("Solicitor");
            occupationList.Add("Account Manager");
            occupationList.Add("P.A.");
            occupationList.Add("Sanitation Worker");
            occupationList.Add("Analyst");

            occupationList.Add("Engineer");
            occupationList.Add("Sales Manager");
            occupationList.Add("Doctor");
            occupationList.Add("Nurse");
            occupationList.Add("Salesperson");
            occupationList.Add("Designer");
            occupationList.Add("IT Technician");
            occupationList.Add("Electrician");
            occupationList.Add("Plumber");
            occupationList.Add("Construction Worker");

            occupationList.Add("Pharmacist");
            occupationList.Add("Care Worker");
            occupationList.Add("Driver");
            occupationList.Add("Delivery Person");
            occupationList.Add("Business Owner");
            occupationList.Add("Developer");
            occupationList.Add("Personal Trainer");
            occupationList.Add("Unemployed");
            occupationList.Add("Writer");
            occupationList.Add("Artist");

            occupationList.Add("Mechanic");
            occupationList.Add("Police Officer");
            occupationList.Add("Soldier");
            occupationList.Add("Paramedic");
            occupationList.Add("Customer Service Assistant");
            occupationList.Add("Bar Tender");
        }

        private static void Get51To65Jobs()
        {
            occupationList.Add("Manager");
            occupationList.Add("Teacher");
            occupationList.Add("Accountant");
            occupationList.Add("Consultant");
            occupationList.Add("Administrator");
            occupationList.Add("Solicitor");
            occupationList.Add("Account Manager");
            occupationList.Add("P.A.");
            occupationList.Add("Sanitation Worker");
            occupationList.Add("Analyst");

            occupationList.Add("Engineer");
            occupationList.Add("Sales Manager");
            occupationList.Add("Doctor");
            occupationList.Add("Nurse");
            occupationList.Add("Salesperson");
            occupationList.Add("Designer");
            occupationList.Add("IT Technician");
            occupationList.Add("Electrician");
            occupationList.Add("Plumber");

            occupationList.Add("Pharmacist");
            occupationList.Add("Care Worker");
            occupationList.Add("Driver");
            occupationList.Add("Delivery Person");
            occupationList.Add("Business Owner");
            occupationList.Add("Developer");
            occupationList.Add("Unemployed");
            occupationList.Add("Writer");
            occupationList.Add("Artist");

            occupationList.Add("Professor");
            occupationList.Add("Architect");
        }
    }

}
