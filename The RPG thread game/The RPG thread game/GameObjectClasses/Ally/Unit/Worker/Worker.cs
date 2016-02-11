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
        
        private Structure StartStructure;
        private Structure EndStructure;
        private WaypointFollow WaypointFollow;
        private Structure CurrentTarget;
        private Counter Counter;

        public Worker(Vector2 startPos,Structure startStructure,Structure endStructure) : 
            base(startPos,Team.Ally)
        {
            WaypointFollow = new WaypointFollow(Speed);
            StartStructure = startStructure;
            EndStructure = endStructure;
            CurrentTarget = EndStructure;
            WaypointFollow.MoveToPoint(Position, CurrentTarget.Position);
            ThreadLifeObject.Health = 3;
        }

        

        public override void Update(double deltaTime)
        {
            Counter.GetTimeGone(GetHashCode());

            Counter.StartCounter(GetHashCode());
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
                CurrentTarget.Enter();
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            CurrentTarget = CurrentTarget == EndStructure ? StartStructure : EndStructure;
            WaypointFollow.MoveToPoint(Position,CurrentTarget.Position);
        }
    }
}