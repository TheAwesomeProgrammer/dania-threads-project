﻿using System;

namespace The_RPG_thread_game.DragNDrop
{
    public class Creator
    {
        public Enum AnEnum { get; protected set; }
        public Vector2 StartPosition { get; protected set; }

        protected Factory Factory;


        public Creator(Enum anEnum, Factory factory,Vector2 startPosition)
        {
            AnEnum = anEnum;
            Factory = factory;
            StartPosition = startPosition;
        }

        public GameObject CreateObject()
        {
            return Factory.CrateObject(this);
        }
    }
}