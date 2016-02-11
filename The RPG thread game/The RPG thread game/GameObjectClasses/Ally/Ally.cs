using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Interfaces;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class Ally : CollideableSprite
    {
        public Team Team { get; set; }

        public Ally(Vector2 startPos) :
            base(startPos)
        {
            
        }

        public bool IsEnemy(AttackingUnit attackingUnit)
        {
            return Team == Team.Enemy && attackingUnit.Team == Team.Ally ||
                   Team == Team.Ally && attackingUnit.Team == Team.Enemy;
        }

    }
}