using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Pieces;

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
            currentPiece = PieceFactory.GetNewPiece();

            Dictionary<string, Input.Input> inputs = InputManager.GetInputs();

            bool running = true;
            string input;

            while (running)
            {
                Console.WriteLine($"Score: {score}.");
                foreach (Piece p in pieces)
                {
                    p.Draw(screen, BlockedPiecesColor);
                }
                currentPiece.Draw(screen, FreePiecesColor);
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
            while (!currentPiece.IsAtLimit(Screen.row - 1) && !Colision(currentPiece))
                currentPiece.Move(InputManager.down);

            if (Colision(currentPiece))
                currentPiece.RevertMovement(InputManager.down);

            NextPiece();
        }

        private void CheckCurrentPiece()
        {
            if (currentPiece.IsAtLimit(Screen.row - 1))
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
            currentPiece = PieceFactory.GetNewPiece(); 
            CheckForPoint();
        }

        private bool CheckForPoint()
        {
            int count = 0;
            int start = Screen.row - 1;

            for (int i = start; i >= 1; i--)
            {
                foreach (Piece piece in pieces)
                {
                    piece.GetVerticesAtLimit(ref count, i);
                }

                if(count != 0)
                Console.WriteLine($"Count {count} at {i}");
                if (count >= Screen.col)
                {
                    foreach (Piece piece in pieces)
                    {
                        piece.RemoveVerticesAtLimit(i);
                        piece.Move(InputManager.down);
                    }
                    score++;
                    return true;
                }
                count = 0;
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
    }
}
