using System;
using System.Threading;

namespace GazeusGamesEtapaTeste.Scene
{
    public class SceneManager
    {
        const int frameTime = 500;
        public const string tapStringStandard = "                    ";
        public static readonly string tapString = $"{tapStringStandard}{tapStringStandard}{tapStringStandard}";

        public static SceneManager Singleton;

        IScene currentScene;

        bool running;

        public SceneManager(IScene currentScene)
        {
            Singleton = this;

            running = true;
            this.currentScene = currentScene;
            Thread threadInput = new Thread(Input);
            threadInput.Start();

            Thread threadDraw = new Thread(Draw);
            threadDraw.Start();
        }

        void Input()
        {
            ConsoleKey key;
            while (running)
            {
                key = Console.ReadKey().Key;
                currentScene.Input(key);
                Draw();
            }
        }

        void Draw()
        {
            while (running)
            {
                currentScene.Draw();
                Thread.Sleep(frameTime);
            }
        }

        public void ChangeScene(IScene nextScene)
        {
            currentScene = nextScene;
        }
    }
}
