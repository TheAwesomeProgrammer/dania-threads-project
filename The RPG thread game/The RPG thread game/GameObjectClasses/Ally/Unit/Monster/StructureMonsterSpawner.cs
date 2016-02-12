using System;
using System.Drawing;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.Factories;
using The_RPG_thread_game.GameObjectClasses.Ally.Structure;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster
{
    public class StructureMonsterSpawner : GameObject
    {
        private float SpawnSpeed = 20;
        private int SpeedIncreaseInterval = 10;
        private int SpeedIncrease = 1;
        private int BottomOffset = 100;

        private float NextTimeToIncreaseSpeed = 10;
        private float NextTimeToSpawn;

        private Time Time;
        private Size DisplaySize;

        public StructureMonsterSpawner() :
            base(new Vector2(0,0))
        {
            Time = Time.Instance;
            DisplaySize = Display.Instance.GetSize();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ShouldSpawn();
            ShouldIncreaseSpeed();
        }

        private void ShouldSpawn()
        {
            if (NextTimeToSpawn < Time.TimeSinceStart)
            {
                Spawn();
                NextTimeToSpawn = (float)Time.TimeSinceStart + SpawnSpeed;
            }
        }

        private void Spawn()
        {
            Vector2 SpawnPosition = new Vector2(50,new Random().Next(0,DisplaySize.Height - BottomOffset));
            DropCreator DropCreator = new DropCreator(StructureType.EnemyBarrack,new StructureObjectCreator(),SpawnPosition);
            GameWorld.AddObjectInNextCycle(DropCreator.CreateObject());
        }

        private void ShouldIncreaseSpeed()
        {
            if (NextTimeToIncreaseSpeed < Time.TimeSinceStart)
            {
                IncreaseSpeed();
                NextTimeToIncreaseSpeed = (float)Time.TimeSinceStart + SpeedIncreaseInterval;
            }
        }

        private void IncreaseSpeed()
        {
            SpawnSpeed -= SpeedIncrease;
        }
    }
}