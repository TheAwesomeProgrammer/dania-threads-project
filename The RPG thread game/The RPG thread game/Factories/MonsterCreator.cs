using System;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Factories;

namespace The_RPG_thread_game.GameObjectClasses.Factories
{
    public class MonsterCreator : Creator
    {
        public Team Team { get; private set; }
        public Vector2 EndPosition { get; private set; }

        public MonsterCreator(Enum anEnum, Factory factory,Vector2 startPosition,Vector2 endPosition,Team team) : 
            base(anEnum,factory,startPosition)
        {
            EndPosition = endPosition;
            Team = team;
        }
    }
}