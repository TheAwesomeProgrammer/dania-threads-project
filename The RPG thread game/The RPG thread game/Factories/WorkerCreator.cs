using System;
using The_RPG_thread_game.DragNDrop;

namespace The_RPG_thread_game.Factories
{
    public class WorkerCreator : Creator
    {
        public Structure StartStructure;
        public Structure EndStructure;

        public WorkerCreator(Enum anEnum, Factory factory, Vector2 startPosition,
            Structure startStructure, Structure endStructure) :
                base(anEnum, factory, startPosition)
        {
            StartStructure = startStructure;
            EndStructure = endStructure;
        }
    }
}