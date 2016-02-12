namespace The_RPG_thread_game
{
    public class EmptyWorker : Worker
    {
        public EmptyWorker() :
            base(new Vector2(0, 0), new EmptyStructure(), new EmptyStructure())
        {
            
        }
    }
}