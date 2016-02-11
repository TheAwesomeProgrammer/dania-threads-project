using System;

namespace The_RPG_thread_game.DragNDrop
{
    public interface Factory
    {
        GameObject CrateObject(Creator creator);

    }
}