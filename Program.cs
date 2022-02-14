using System;
using GazeusGamesEtapaTeste.Scene;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager(new Menu());
        }
    }
}
