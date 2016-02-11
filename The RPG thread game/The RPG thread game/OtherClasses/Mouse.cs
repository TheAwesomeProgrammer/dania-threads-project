using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal static class Mouse
    {
        public static Vector2 Position = new Vector2(0,0);

        public static bool IsMouseDown { get; set; }
    }
}