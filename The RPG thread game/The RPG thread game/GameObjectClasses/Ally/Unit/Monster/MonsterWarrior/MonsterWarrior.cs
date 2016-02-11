using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class MonsterWarrior : Monster
    {
        public MonsterWarrior(Vector2 startPos,Vector2 endPosition,Team team) :
            base(startPos,endPosition,team)
        {
           
        }

        protected override void Init()
        {
            ImagePath = @"Resources\Monsters\Warrior.png";
            base.Init();
        }
    }
}