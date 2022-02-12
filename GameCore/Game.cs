using System;
using System.Collections.Generic;
using System.Globalization;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.Table;
using GazeusGamesEtapaTeste.Scene;

namespace GazeusGamesEtapaTeste.GameCore
{
    public class Game : IScene
    {
        const ConsoleKey KeyForward = ConsoleKey.Spacebar;
        private const ConsoleColor BlockedPiecesColor = ConsoleColor.Blue;
        private const ConsoleColor FreePiecesColor = ConsoleColor.Green;

        Screen screen;
        Piece currentPiece;
        LineManager lineManager;
        Dictionary<ConsoleKey, Input.Input> inputs;
        DateTime lastTime;

        int score;
        bool updateScreen;


        public Game()
        {
            lastTime = DateTime.Now;
            screen = new Screen();

            currentPiece = PieceFactory.GetNewPiece();
            lineManager = new LineManager();

            inputs = InputManager.GetInputs();
            score = 0;

            GameLoop();
        }

        private void GameLoop()
        {
            if (updateScreen)
            {
                updateScreen = false;
            }
            else
            {
                return;
            }
            Draw();
        }

        public void AutoPieceMovement()
        {
            currentPiece.Move(InputManager.down);
            CheckCurrentPiece();
            updateScreen = true;
        }

        public void Input(ConsoleKey key)
        {
            if (!lineManager.MoveLinesDown())
            {
                if ((DateTime.Now - lastTime).TotalSeconds >= 1)
                {
                    //AutoPieceMovement();
                    //lastTime = DateTime.Now;
                    //return;
                }

                Console.WriteLine(key);

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

        public void Draw()
        {
            lineManager.DrawLines(screen, BlockedPiecesColor);
            currentPiece.Draw(screen, FreePiecesColor);
            screen.Draw();

            Screen.WriteLine($"{SceneManager.tapString}Score: {score}.");
            Screen.WriteLine($"{SceneManager.tapString}Para jogar aperte: ");

            foreach (KeyValuePair<ConsoleKey, Input.Input> entry in inputs)
            {
                Screen.WriteLine($"{SceneManager.tapString}{entry.Key}: {entry.Value.Description}.");
            }
            Screen.WriteLine($"{SceneManager.tapString}{KeyForward}: descer até o final.");
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

            bool running = !lineManager.Colision(currentPiece);
            if (!running)
            {
                SceneManager.Singleton.ChangeScene(new Menu());
            }
        }

        private void CheckForPoint()
        {
            int roundScore = lineManager.GetScore();
            score += roundScore;
        }
    }
}
