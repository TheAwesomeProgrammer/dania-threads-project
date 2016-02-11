using System.Collections.Generic;

namespace The_RPG_thread_game.Interfaces
{
    public interface Collideable
    {
        void OnCollision(List<CollideableSprite> spritesCollidingWith);
    }
}