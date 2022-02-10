using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen();

            Piece piece = new Piece(3, 2);

            Dictionary<string, Input.Input> inputs = InputManager.GetInputs();
            
            bool running = true;
            string input;

            while (running)
            {
                piece.Draw(screen);
                screen.Draw();

                Console.WriteLine("Para jogar aperte: ");

                foreach (KeyValuePair<string, Input.Input> entry in inputs)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value.Description}.");
                }

                input = Console.ReadLine();
                if (inputs.ContainsKey(input))
                    piece.Move(inputs[input]);

                Thread.Sleep(500);
            }

        }
    }
}
