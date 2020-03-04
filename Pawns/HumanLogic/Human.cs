using Microsoft.Xna.Framework.Graphics;
using Zeds.Items.Weapons;

namespace Zeds.Pawns.HumanLogic
{
    public class Human : Creature
    {
        public string Name;
        public int Age;
        public string Occupation;
        public bool IsMale;
        public int Race;
        public bool IsArmed;
        public Weapon EquippedWeapon;
        public bool IsSelected;
    }
}