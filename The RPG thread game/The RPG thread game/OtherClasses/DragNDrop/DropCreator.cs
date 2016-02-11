using System;

namespace The_RPG_thread_game.DragNDrop
{
    public class DropCreator : Creator
    {

        public string ImagePath;

        public DropCreator(Enum anEnum, Factory factory) :
            base(anEnum, factory,new Vector2(0,0))
        {
        }

        public DropCreator(Enum anEnum, Factory factory,Vector2 startPos) :
           base(anEnum, factory, startPos)
        {
        }

        public void SetDropStats(Vector2 position)
        {
            StartPosition = position;
        }

       
    }
}