using System;
using System.Collections.Generic;
using System.Threading;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.Table;

namespace GazeusGamesEtapaTeste
{
    public class Game
    {
        const ConsoleKey KeyForward = ConsoleKey.Spacebar;
        private const ConsoleColor BlockedPiecesColor = ConsoleColor.Blue;
        private const ConsoleColor FreePiecesColor = ConsoleColor.Green;

        Screen screen;
        Piece currentPiece;
        LineManager lineManager;
        Dictionary<ConsoleKey, Input.Input> inputs;

        int score;
        bool running;
        bool updateScreen;
        volatile bool blockNextInput;

        public Game(Screen screen)
        {
            this.screen = screen;

            currentPiece = PieceFactory.GetNewPiece();
            lineManager = new LineManager();

            inputs = InputManager.GetInputs();
            score = 0;
            running = true;

            Thread threadInput = new Thread(PlayerInput);
            threadInput.Start();

            Thread threadAutoMovement = new Thread(AutoPieceMovement);
            threadAutoMovement.Start();

            GameLoop();
        }

        private void GameLoop()
        {
            Draw();
            while (running)
            {
                if (updateScreen)
                {
                    updateScreen = false;
                }
                else
                {
                    continue;
                }
                Draw();
            }
        }

        private void AutoPieceMovement()
        {
            while (running)
            {
                Thread.Sleep(1000);
                blockNextInput = true;

                currentPiece.Move(InputManager.down);

                CheckCurrentPiece();

                blockNextInput = false;
                updateScreen = true;
            }
        }

        private void PlayerInput()
        {
            ConsoleKey key;
            while (running)
            {
                if (!lineManager.MoveLinesDown())
                {
                    key = Console.ReadKey().Key;
                    if (blockNextInput)
                        continue;

                    if (inputs.ContainsKey(key))
                        currentPiece.Move(inputs[key]);

                    if (key.Equals(KeyForward))
                        Foward();
                    else
                    {
                        if (!IsTheMovementValid())
                        {
                            currentPiece.RevertMovement(inputs[key]);
                        }
                        else
                        {
                            CheckCurrentPiece();
                        }
                    }
                    updateScreen = true;

                }
            }

        }

        private void Draw()
        {
            lineManager.DrawLines(screen, BlockedPiecesColor);
            currentPiece.Draw(screen, FreePiecesColor);
            screen.Draw();

            Screen.WriteLine($"{Screen.tapString}Score: {score}.");
            Screen.WriteLine($"{Screen.tapString}Para jogar aperte: ");

            foreach (KeyValuePair<ConsoleKey, Input.Input> entry in inputs)
            {
                Screen.WriteLine($"{Screen.tapString}{entry.Key}: {entry.Value.Description}.");
            }
            Screen.WriteLine($"{Screen.tapString}{KeyForward}: descer até o final.");
        }

        private bool IsTheMovementValid()
        {
            return !currentPiece.IsAtWidthLimit(Screen.col) 
                && !lineManager.Colision(currentPiece);
        }

        private void Foward()
        {
            while (!currentPiece.IsAtHightLimit(Screen.row - 1) 
                && !lineManager.Colision(currentPiece))
                currentPiece.Move(InputManager.down);

            if (lineManager.Colision(currentPiece))
                currentPiece.RevertMovement(InputManager.down);

            NextPiece();
        }

        private void CheckCurrentPiece()
        {
            if (currentPiece.IsAtHightLimit(Screen.row - 1))
            {
                NextPiece();
                return;
            }

            currentPiece.Move(InputManager.down);
            bool colision = lineManager.Colision(currentPiece);
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

            running = !lineManager.Colision(currentPiece);
            if (!running)
            {
                Console.WriteLine("OI");
            }
        }

        private void CheckForPoint()
        {
            int roundScore = lineManager.GetScore();
            score += roundScore;
        }
    }
}
