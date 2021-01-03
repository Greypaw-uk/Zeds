using Zeds.Engine;

namespace Zeds.Pawns.ZedLogic
{
    class ZedHumanCollision
    {
        public static void CheckZedHumanCollision(Zed zed)
        {
            foreach (var human in EntityLists.HumanList)
                if (zed.BRec.Intersects(human.BRec))
                {
                    if (zed.NextAttack <= 0)
                    {
                        human.CurrentHealth -= zed.AttackPower;

                        zed.NextAttack = zed.AttackSpeed;
                    }
                    else
                    {
                        zed.NextAttack--;
                    }

                    if (human.NextAttack <= 0)
                    {
                        zed.CurrentHealth -= human.AttackPower;

                        human.NextAttack = human.AttackSpeed;
                    }
                    else
                    {
                        human.NextAttack--;
                    }

                    if (zed.Position.X >= human.Position.X)
                        zed.Position.X += 1;
                    if (zed.Position.X <= human.Position.X)
                        zed.Position.X -= 1;
                    else if (zed.Position.Y >= human.Position.Y)
                        zed.Position.Y += 1;
                    if (zed.Position.Y <= human.Position.Y)
                        zed.Position.Y -= 1;
                }
        }
    }
}
