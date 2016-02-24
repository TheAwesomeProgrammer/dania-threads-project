using System.Drawing;

namespace The_RPG_thread_game
{
    public class WinOrLoseGame : NonCollidingSprite
    {
        private StopGame StopGame;
        private string WhatToWrite;

        public WinOrLoseGame(string whatToWrite) :
            base(new Vector2(0, 0))
        {
            WhatToWrite = whatToWrite;
            StopGame = new StopGame();
            StopGame.Stop();
            GameWorld.AddObjectInNextCycle(this);
        }

   

        public override void Draw(Graphics graphics)
        {
            graphics.DrawString(WhatToWrite, new Font(FontFamily.GenericSerif, 32),new SolidBrush(Color.Black), new PointF(400,250) );
        }
    }
}