using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace The_RPG_thread_game.Utillity
{
    public static class Extensions
    {
        public static void AddAll<T>(this List<T> list, Func<T, bool> predicate)
        {
            foreach (var Item in list)
            {
                if (predicate(Item))
                {
                    list.Add(Item);
                }
            }
        }

        public static void DoActionOnItems<T>(this List<T> list,Action<T> action )
        {
            foreach (var Item in list)
            {
                action(Item);
            }
        }

        public static void StartAndRunInFront(this Thread thread)
        {
            thread.Start();
            thread.IsBackground = false;
        }

        public static void DoActionOnItemsMatchingPredicate<T>(this List<T> list, Func<T, bool> predicate, Action<T> action)
        {
            foreach (var Item in list)
            {
                if (predicate(Item))
                {
                    action(Item);
                }
            }
        }

        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X,point.Y);
        }

        public static Vector2 ToVector2(this SizeF sizeF)
        {
            return new Vector2(sizeF.Width, sizeF.Height);
        }

  
    }
}