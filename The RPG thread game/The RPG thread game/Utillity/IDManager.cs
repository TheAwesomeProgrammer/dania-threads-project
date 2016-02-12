namespace The_RPG_thread_game.Utillity
{
    public class IDManager
    {
        private static IDManager MyInstance;
        private int Id;

        public static IDManager Instance
        {
            get
            {
                if (MyInstance == null)
                {
                    MyInstance = new IDManager();
                }
                return MyInstance;
            }
        }

        private IDManager() { }

        public int GetID()
        {
            return Id++;
        }

    }
}