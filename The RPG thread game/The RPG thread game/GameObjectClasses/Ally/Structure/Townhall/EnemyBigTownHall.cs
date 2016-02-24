using System;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game
{
    public class EnemyBigTownHall : Structure
    {
        public EnemyBigTownHall(Vector2 startPos) :
                base(startPos,Team.Enemy)
        {
            ScaleFactor = 0.75f;
            HealthLimit.SetMaxLimit(100);
            Health = 100;
            StructureType = StructureType.Townhall;
        }

        public override void Die()
        {
            new WinOrLoseGame("You win " + Environment.NewLine + " Press any key to continue");
        }
    }
}