using System;

namespace The_RPG_thread_game.DragNDrop
{
    public class DropCreator : Creator
    {

        public DropCreator(Enum anEnum,Factory factory) : 
            base(anEnum,factory)
        {
            AnEnum = anEnum;
            Factory = factory;
        }

        public DropCreator(Enum anEnum, Factory factory,Vector2 startPosition) :
            base(anEnum, factory,startPosition)
        {

        }

        public void SetDropStats(Vector2 position)
        {
            StartPosition = position;
        }

       
    }
}