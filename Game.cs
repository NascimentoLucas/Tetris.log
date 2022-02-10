using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    public class Game
    {
        Screen screen;
        List<Piece> pieces;
        Piece currentPiece;

        public Game(Screen screen)
        {
            this.screen = screen;

            pieces = new List<Piece>();
            currentPiece = GetNewPiece();

            Dictionary<string, Input.Input> inputs = InputManager.GetInputs();

            bool running = true;
            string input;

            while (running)
            {
                foreach (Piece p in pieces)
                {
                    p.Draw();
                }
                currentPiece.Draw();
                screen.Draw();

                Console.WriteLine("Para jogar aperte: ");

                foreach (KeyValuePair<string, Input.Input> entry in inputs)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value.Description}.");
                }

                input = Console.ReadLine();
                if (inputs.ContainsKey(input))
                    currentPiece.Move(inputs[input]);
                CheckCurrentPiece();

                Thread.Sleep(500);
            }
        }

        private void CheckCurrentPiece()
        {
            if (currentPiece.IsAtLimit())
            {
                pieces.Add(currentPiece);
                currentPiece = GetNewPiece();
                return;
            }

            currentPiece.Move(InputManager.down);
            bool colision = Colision(currentPiece);
            currentPiece.RevertMovement(InputManager.down);

            if (colision)
            {
                pieces.Add(currentPiece);
                currentPiece = GetNewPiece();
            }
        }

        private bool Colision(Piece currentPiece)
        {

            foreach (Piece piece in pieces)
            {
                if (piece.Colision(currentPiece))
                {
                    Console.WriteLine(piece.Id);
                    Console.WriteLine(currentPiece.Id);
                    return true;
                }
            }

            return false;
        }

        private Piece GetNewPiece()
        {
            return new Piece(screen, 3, 15, pieces.Count + 1);
        }
    }
}
