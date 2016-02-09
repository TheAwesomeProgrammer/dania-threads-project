using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class Worker : Unit
    {
        public float Speed = 10;
        
        private Structure StartStructure;
        private Structure EndStructure;
        private WaypointFollow WaypointFollow;
        private Structure CurrentTarget;

        public Worker(Vector2 startPos, string imagePath, float scaleFactor,Structure startStructure,Structure endStructure) : 
            base(startPos,imagePath,scaleFactor)
        {
            WaypointFollow = new WaypointFollow(Speed);
            StartStructure = startStructure;
            EndStructure = endStructure;
            CurrentTarget = EndStructure;
            WaypointFollow.MoveToPoint(Position, CurrentTarget.Position);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            ShouldChangeTarget();
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            Position = WaypointFollow.GetCurrentPoint(deltaTime);
        }

        private void ShouldChangeTarget()
        {
            if (WaypointFollow.HasReachedTarget(Position))
            {
                CurrentTarget.HasEntered = true;
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            CurrentTarget = CurrentTarget == EndStructure ? StartStructure : EndStructure;
        }
    }
}