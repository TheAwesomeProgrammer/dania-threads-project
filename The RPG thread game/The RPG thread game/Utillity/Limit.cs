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

        public float GetWithinLimit(float value)
        {
            if (value > MaxLimit)
            {
                return MaxLimit;
            }
            if (value < MinLimit)
            {
                return MinLimit;
            }
            return value;
        }

        public void SetMaxLimit(float maxLimit)
        {
            MaxLimit = maxLimit;
        }
    }
}