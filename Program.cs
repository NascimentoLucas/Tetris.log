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

            //Game game = new Game();
            //SceneManager.Singleton.ChangeScene(game);
            //SceneManager.Singleton.SetUpdate(game);
        }
    }
}
