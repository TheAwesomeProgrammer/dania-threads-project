using The_RPG_thread_game.DragNDrop;
using The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public class EnemyBarrack : AttackingStructure
    {
        public EnemyBarrack(Vector2 startPos) :
            base(startPos)
        {
            AttackSpeed = 5;
            ScaleFactor = 0.5f;
            ImagePath = @"Resources\Structures\Barrack.png";
        }

        protected override void Init()
        {
            base.Init();
            EndPosition = new Vector2(Display.Instance.GetSize().Width, Center.Y);
            Team = Team.Enemy;
            MonsterCreator = new MonsterCreator(MonsterType, new MonsterObjectCreator(), Center, EndPosition, Team);

        }
    }
}