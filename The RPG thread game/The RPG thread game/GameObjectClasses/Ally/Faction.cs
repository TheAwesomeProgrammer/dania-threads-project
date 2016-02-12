

namespace The_RPG_thread_game
{
    public class Faction : CollideableSprite, Factionable
    {
        public Team Team { get; set; }

        public Faction(Vector2 startPos, Team team) :
            base(startPos)
        {
            Team = team;
        }

        public bool IsEnemy(Faction faction)
        {
            return Team == Team.Enemy && faction.Team == Team.Ally ||
            Team == Team.Ally && faction.Team == Team.Enemy;
        }
    }
}