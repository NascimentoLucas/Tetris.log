using GazeusGamesEtapaTeste.GameCore;
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
        IUpdate currentUpdate;

        bool running;
        bool canDraw;

        public SceneManager(IScene currentScene)
        {
            if (currentScene == null)
                throw new ArgumentNullException();

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
                currentUpdate?.Update();
                if (canDraw)
                {
                    currentScene.Draw();
                    canDraw = false;
                }
            }
        }

        public void ChangeScene(IScene nextScene)
        {
            if (nextScene == null)
                throw new ArgumentNullException();

            currentScene = nextScene;
            canDraw = true;
        }

        internal void SetUpdate(IUpdate update)
        {
            currentUpdate = update;
        }
    }
}
