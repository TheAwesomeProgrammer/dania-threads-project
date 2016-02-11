using System.Drawing;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game.Bar
{
    public class HealthBar : NonCollidingSprite
    {
        private float HealthBarValue;
        private SizeF StartSize;
        private Limit HealthBarLimit;
        private GameObject MyGameObject;
        private Vector2 Offset;

        public HealthBar(GameObject gameObject, SizeF sizeF,Vector2 offset) :
            base(gameObject.Position, sizeF)
        {
            Offset = offset;
            MyGameObject = gameObject;
            StartSize = sizeF;
            HealthBarLimit = new Limit(1);
        }

        public void SetHealthBarValue(float value)
        {
            HealthBarValue = HealthBarLimit.GetWithinLimit(value);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            SizeF = new SizeF(StartSize.Width * HealthBarValue, StartSize.Height);
            Position = MyGameObject.Position + Offset;
        }
    }
}