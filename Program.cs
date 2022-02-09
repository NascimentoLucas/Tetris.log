using System;
using System.Collections.Generic;
using System.Drawing;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen();

            Piece piece = new Piece(3, 2);

            Dictionary<string, Point> inputs = InputManager.GetInputs();
            
            bool running = true;
            string input;
            piece.Test();
            input = Console.ReadLine();

            while (running)
            {
                break;
                piece.Draw(screen);
                screen.Draw();
                input = Console.ReadLine();

                if (inputs.ContainsKey(input))
                    piece.Move(inputs[input]);
                else
                    piece.Move(InputManager.down);
            }

        }
    }
}
