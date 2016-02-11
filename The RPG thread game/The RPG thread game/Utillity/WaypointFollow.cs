using System;
using System.Collections.Generic;
using System.Diagnostics;
using The_RPG_thread_game;

namespace The_RPG_thread_game.Utillity
{
    public class WaypointFollow
    {
        private Counter Counter = Counter.Instance;
        private float ReachedTargetThreeshold = 1f;

        private float Speed;
        private Vector2 TargetPoint;
        private Vector2 StartPoint;

        private List<Vector2> Positions = new List<Vector2>();

        public WaypointFollow(float speed)
        {
            Speed = speed;
        }

        public void MoveToPoint(Vector2 startPoint, Vector2 endPoint)
        {
            StartPoint = startPoint;
            Counter.StartCounter(GetHashCode());
            TargetPoint = endPoint;
            Positions.Clear();
        }

        public Vector2 GetCurrentPoint(Vector2 currentPosition,double deltaTime)
        {
            return currentPosition +(GetDiretionToTarget() * (float)deltaTime * Speed);
        }

     

        private Vector2 GetDiretionToTarget()
        {
            return (StartPoint.Substract(TargetPoint)).Normalized;
        }

        public bool HasReachedTarget(Vector2 currentPosition)
        {
            return currentPosition.DistanceToVector(TargetPoint) <= ReachedTargetThreeshold;
        }

        

     

        

       




    }
}