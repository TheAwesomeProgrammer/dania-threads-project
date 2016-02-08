namespace The_RPG_thread_game
{
    public abstract class AliveGameObject : GameObject
    {
        protected int Health;

        protected AliveGameObject(Vector2 startPos,int health) : 
            base(startPos)
        {
            Health = health;
            StartPos = startPos;
        }

    }
}