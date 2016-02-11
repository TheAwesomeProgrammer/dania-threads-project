using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    public abstract class Unit : CollideableSprite, Attackable
    {
        public Team Team { get; set; }

        protected LifeObject LifeObject;

        public int Health
        {
            get { return LifeObject.Health; }
            set { LifeObject.Health = value; }
        }

        public Unit(Vector2 startPos, Team team) :
            base(startPos)
        {
            Team = team;
            LifeObject = new LifeObject(this);
            
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            LifeObject.Update(deltaTime);
        }

        public bool IsEnemy(Unit unit)
        {
            return Team == Team.Enemy && unit.Team == Team.Ally ||
                   Team == Team.Ally && unit.Team == Team.Enemy;
        }

    }
}