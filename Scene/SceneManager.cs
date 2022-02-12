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
        bool canDraw;

        public SceneManager(IScene currentScene)
        {
            Singleton = this;

            canDraw = true;
            running = true;
            this.currentScene = currentScene;

            Thread threadInput = new Thread(Input);
            threadInput.Start();

            Thread threadDraw = new Thread(Update);
            threadDraw.Start();

        }

        void Input()
        {
            ConsoleKey key;
            while (running)
            {
                key = Console.ReadKey().Key;
                currentScene.Input(key);
                canDraw = true;
            }
        }

        void Update()
        {
            while (running)
            {
                currentScene.Update();
                if (canDraw)
                {
                    currentScene.Draw();
                    canDraw = false;
                }
            }
        }

        public void ChangeScene(IScene nextScene)
        {
            currentScene = nextScene;
        }
    }
}
