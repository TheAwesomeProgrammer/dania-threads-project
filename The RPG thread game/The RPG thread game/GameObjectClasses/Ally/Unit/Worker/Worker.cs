using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class Worker : ThreadUnit
    {
        public float Speed = 100;
        public Action GiveResourceAction;
        
        private Structure StartStructure;
        private Structure EndStructure;
        private WaypointFollow WaypointFollow;
        private Structure CurrentTarget;
        private bool JustEnteredStructure;
        private bool HasResource;

        public Worker(Vector2 startPos,Structure startStructure,Structure endStructure) : 
            base(startPos,Team.Ally)
        {
            WaypointFollow = new WaypointFollow(Speed);
            StartStructure = startStructure;
            EndStructure = endStructure;
            CurrentTarget = EndStructure;
            WaypointFollow.MoveToPoint(Position, CurrentTarget.Center);
        }        

        public override void Update(double deltaTime)
        {
            if (JustEnteredStructure)
            {
                deltaTime = 0;
                JustEnteredStructure = false;
            }
            base.Update(deltaTime);
            Move(deltaTime);
            ShouldChangeTarget();
        }

        private void Move(double deltaTime)
        {
            Position = WaypointFollow.GetCurrentPoint(Position,deltaTime);
           
        }

        private void ShouldChangeTarget()
        {
            if (WaypointFollow.HasReachedTarget(Position))
            {
                CurrentTarget.Enter(this);
                SwitchTarget();
                JustEnteredStructure = true;
            }
        }

        private void SwitchTarget()
        {
            if (EndStructure == null || EndStructure.IsDead)
            {
                Die();
            }
            CurrentTarget = CurrentTarget == EndStructure ? StartStructure : EndStructure;
            WaypointFollow.MoveToPoint(Position,CurrentTarget.Center);
        }
    }
}