using System;
using The_RPG_thread_game.Factories;

namespace The_RPG_thread_game.Factories
{
    public interface Factory
    {
        GameObject CrateObject(Creator creator);

    }
}