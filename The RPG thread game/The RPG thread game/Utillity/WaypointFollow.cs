using The_RPG_thread_game;

namespace The_RPG_thread_game.Utillity
{
    public class WaypointFollow
    {
        private DateTimeTimer Timer = DateTimeTimer.Instance;
        private float ReachedTargetThreeshold = 5;

        private float PixelsPerSecound;
        private Vector2 TargetPoint;
        private Vector2 StartPoint;

        public WaypointFollow(float pixelsPerSecound)
        {
            PixelsPerSecound = pixelsPerSecound;
        }

        public void MoveToPoint(Vector2 startPoint, Vector2 point)
        {
            StartPoint = startPoint;
            Timer.StartTimer(GetHashCode());
            TargetPoint = point;
        }

        public Vector2 GetCurrentPoint(float deltaTime)
        {
            float TimeGoneInMilliSecounds = (float)(Timer.GetTimeGone(GetHashCode()).TotalMilliseconds / 1000);
            return StartPoint + (GetDiretionToTarget() * PixelsPerSecound * TimeGoneInMilliSecounds);
        }

        public bool HasReachedTarget(Vector2 currentPosition)
        {
            return currentPosition.DistanceToVector(TargetPoint) < ReachedTargetThreeshold;
        }

        private Vector2 GetDiretionToTarget()
        {
            return (StartPoint.Substract(TargetPoint)).Normalized;
        }




    }
}