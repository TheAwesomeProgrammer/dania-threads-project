namespace The_RPG_thread_game
{
    public interface Attackable
    {
        Team Team { get; set; }

        bool IsEnemy(Unit unit);
    }
}