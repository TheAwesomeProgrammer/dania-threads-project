using System;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Factories;

namespace The_RPG_thread_game.Factories
{
    public class DropCreator : Creator
    {

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