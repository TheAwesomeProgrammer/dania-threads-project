namespace The_RPG_thread_game
{
    public interface Factionable
    {
        Team Team { get; set; }

        bool IsEnemy(Faction unit);
    }
}