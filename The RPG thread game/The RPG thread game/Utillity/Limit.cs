namespace The_RPG_thread_game.Utillity
{
    public class Limit
    {
        private float MaxLimit;
        private float MinLimit;

        public Limit(float maxLimit)
        {
            MaxLimit = maxLimit;
        }

        public Limit(float maxLimit, float minLimit)
        {
            MaxLimit = maxLimit;
            MinLimit = minLimit;
        }

        public bool IsWithinLimit(float value)
        {
            return value <= MaxLimit && value >= MinLimit;
        }
    }
}