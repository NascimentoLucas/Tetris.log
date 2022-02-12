using System;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.GameCore;



namespace GazeusGamesEtapaTeste.Scene
{
    public class Menu : IScene
    {
        Dictionary<ConsoleKey, Input.Input> inputs;
        Dictionary<ConsoleKey, string> menuInputs;

        string joke;

        public Menu()
        {
            inputs = InputManager.GetInputs();

            menuInputs = new Dictionary<ConsoleKey, string>()
            {
                [ConsoleKey.D] = "hummm.",
                [ConsoleKey.A] = "Parece uma boa estratégia.",                
                [ConsoleKey.Q] = "Seno de que ?",
                [ConsoleKey.E] = "A pessoa ta como ? só no preparo",
                [ConsoleKey.S] = "Isso não é automático ?",
                [InputManager.KeyForward] = "Por sua conta e risco.",
            };

            joke = "";
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine($"{SceneManager.tapString}Bem vindo ao Tetris");
            Console.WriteLine($"{SceneManager.tapString}");
            Console.WriteLine($"{SceneManager.tapString}Para jogar use: ");

            foreach (KeyValuePair<ConsoleKey, Input.Input> entry in inputs)
            {
                Console.WriteLine($"{SceneManager.tapString}{entry.Key}: {entry.Value.Description}.");
            }
            Console.WriteLine($"{SceneManager.tapString}{InputManager.KeyForward}: Descer até o final.");

            Console.WriteLine($"{SceneManager.tapString}Pronto(a) ? aperte {InputManager.StartButton} para começar.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(joke);
        }

        public void Input(ConsoleKey key)
        {
            if (menuInputs.ContainsKey(key))
            {
                joke = menuInputs[key];
                return;
            }

            if (key == InputManager.StartButton)
            {
                Game game = new Game();
                SceneManager.Singleton.ChangeScene(game);
                SceneManager.Singleton.SetUpdate(game);
            }

            joke = "";
            
        }
    }
}
