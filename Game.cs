using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.Table;

namespace GazeusGamesEtapaTeste
{
    public class Game
    {
        const string KeyForward = "f";
        private const ConsoleColor BlockedPiecesColor = ConsoleColor.Blue;
        private const ConsoleColor FreePiecesColor = ConsoleColor.Green;

        Screen screen;
        Piece currentPiece;
        LineManager lineManager;
        Dictionary<string, Input.Input> inputs;

        int score;
        bool running;

        public Game(Screen screen)
        {
            this.screen = screen;

            currentPiece = PieceFactory.GetNewPiece();
            lineManager = new LineManager();

            inputs = InputManager.GetInputs();
            score = 0;
            running = true;
            GameLoop();
        }

        private void GameLoop()
        {
            string input;
            while (running)
            {
                Screen.WriteLine($"Score: {score}.");
                lineManager.DrawLines(screen, BlockedPiecesColor);
                currentPiece.Draw(screen, FreePiecesColor);
                screen.Draw();

                Screen.WriteLine($"{Screen.tapString}Para jogar aperte: ");

                foreach (KeyValuePair<string, Input.Input> entry in inputs)
                {
                    Screen.WriteLine($"{Screen.tapString}{entry.Key}: {entry.Value.Description}.");
                }
                Screen.WriteLine($"{Screen.tapString}{KeyForward}: descer até o final.");


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
            lineManager.GetVertexFromPiece(currentPiece);
            CheckForPoint();
            currentPiece = PieceFactory.GetNewPiece();
        }

        private void CheckForPoint()
        {
            //throw new NotImplementedException();
        }

        private bool Colision(Piece currentPiece)
        {
            return false;
        }
    }
}
