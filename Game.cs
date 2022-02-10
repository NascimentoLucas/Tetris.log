using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    public class Game
    {
        const string KeyForward = "f";
        private const ConsoleColor BlockedPiecesColor = ConsoleColor.Blue;
        private const ConsoleColor FreePiecesColor = ConsoleColor.Green;
        Screen screen;
        List<Piece> pieces;
        Piece currentPiece;
        int score = 0;
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
                Console.WriteLine($"Score: {score}.");
                foreach (Piece p in pieces)
                {
                    p.Draw();
                }
                currentPiece.Draw(FreePiecesColor);
                screen.Draw();

                Console.WriteLine($"{Screen.tapString}Para jogar aperte: ");

                foreach (KeyValuePair<string, Input.Input> entry in inputs)
                {
                    Console.WriteLine($"{Screen.tapString}{entry.Key}: {entry.Value.Description}.");
                }
                Console.WriteLine($"{Screen.tapString}{KeyForward}: descer até o final.");


                input = Console.ReadLine();
                if (inputs.ContainsKey(input))
                    currentPiece.Move(inputs[input]);
                CheckCurrentPiece();

                if (input.Equals(KeyForward))
                    Foward();


                Thread.Sleep(500);
            }
        }

        private void Foward()
        {
            while (!currentPiece.IsAtLimit() && !Colision(currentPiece))
                currentPiece.Move(InputManager.down);

            if (Colision(currentPiece))
                currentPiece.RevertMovement(InputManager.down);

            NextPiece();
        }

        private void CheckCurrentPiece()
        {
            if (currentPiece.IsAtLimit())
            {
                NextPiece();
                return;
            }

            currentPiece.Move(InputManager.down);
            bool colision = Colision(currentPiece);
            currentPiece.RevertMovement(InputManager.down);

            if (colision)
            {
                NextPiece();
            }
        }

        private void NextPiece()
        {
            pieces.Add(currentPiece);
            currentPiece = GetNewPiece();

            if (CheckForPoint())
            {

            }
        }

        private bool CheckForPoint()
        {
            int count = 0;
            foreach (Piece piece in pieces)
            {
                piece.GetVerticesAtLimit(ref count);
            }

            Console.WriteLine($"Count {count} at {Screen.col - 1}");
            if (count >= Screen.row)
            {
                foreach (Piece piece in pieces)
                {
                    piece.RemoveVerticesAtLimit();
                    piece.Move(InputManager.down);
                }
                score++;
                return true;
            }

            return false;
        }

        private bool Colision(Piece currentPiece)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Colision(currentPiece))
                {
                    return true;
                }
            }

            return false;
        }

        private Piece GetNewPiece()
        {
            return new Piece(screen, Screen.row / 2, 2, pieces.Count + 1);
        }
    }
}
