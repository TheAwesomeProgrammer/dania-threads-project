﻿using The_RPG_thread_game.GameObjectClasses.Ally.Structure;

namespace The_RPG_thread_game.DragNDrop
{
    public class StructureObjectCreator : Factory
    {
        public GameObject CrateObject(Creator creator)
        {
            StructureType StructureType = (StructureType)creator.AnEnum;
            DropCreator DropCreator = (DropCreator) creator;

            switch (StructureType)
            {
                case StructureType.Farm:
                    return new Farm(DropCreator.StartPosition);
                case StructureType.Barrack:
                    return new Barracks(DropCreator.StartPosition);
                case StructureType.EnemyBarrack:
                    return new EnemyBarrack(DropCreator.StartPosition);


                default:
                    return new EmptyStructure();
            }
        }
    }
}