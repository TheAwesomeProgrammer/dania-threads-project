using The_RPG_thread_game.Factories;
using The_RPG_thread_game.GameObjectClasses.Ally.Unit.Monster;
using The_RPG_thread_game.GameObjectClasses.Factories;

namespace The_RPG_thread_game.Factories
{
    public class MonsterObjectCreator : Factory
    {
        public GameObject CrateObject(Creator creator)
        {
            MonsterType MonsterType = (MonsterType)creator.AnEnum;
            MonsterCreator MonsterCreator = (MonsterCreator)creator;

            switch (MonsterType)
            {
                case MonsterType.Warrior:
                    return new MonsterWarrior(MonsterCreator.StartPosition,MonsterCreator.EndPosition, MonsterCreator.Team);


                default:
                    return new NoMonster();
            }
        }
    }
}