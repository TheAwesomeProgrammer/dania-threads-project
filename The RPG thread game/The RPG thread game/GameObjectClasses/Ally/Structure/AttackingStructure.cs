using System.Drawing;
using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class AttackingStructure : Structure
    {
        public float AttackSpeed = 1;

        protected MonsterType MonsterType = MonsterType.Warrior;
        
        protected Vector2 EndPosition;
        

        protected float NextTimeToAttack;

        private Time Time;
        protected MonsterCreator MonsterCreator;

        public AttackingStructure(Vector2 startPos) : 
            base(startPos)
        {
            
        }

        protected override void Init()
        {
            base.Init();
            Time = Time.Instance;
            EndPosition = new Vector2(0 - SizeF.Width, Center.Y);
            MonsterCreator = new MonsterCreator(MonsterType, new MonsterObjectCreator(), Center, EndPosition, Team);
        }


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ShouldSpawnMonster();
        }

        protected virtual void ShouldSpawnMonster()
        {
            if (NextTimeToAttack <= Time.TimeSinceStart)
            {
                NextTimeToAttack = (float)Time.TimeSinceStart + AttackSpeed;
                SpawnMonster();
            }
        }

        protected virtual void SpawnMonster()
        {
            GameObject MonsterObject = MonsterCreator.CreateObject();
            GameWorld.AddObjectInNextCycle(MonsterObject);
        }
    }
}