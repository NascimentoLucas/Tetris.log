using System;
using System.Collections.Generic;
using System.Threading;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.Table;
using GazeusGamesEtapaTeste.Scene;

namespace GazeusGamesEtapaTeste.GameCore
{
    public class Game : IScene, IUpdate
    {
        private const ConsoleColor BlockedPiecesColor = ConsoleColor.Blue;
        private const int TimeToAutoMove = 1;

        Screen screen;
        Piece currentPiece;
        FeedbackNextPiece feedbackNextPiece;
        LineManager lineManager;
        Dictionary<ConsoleKey, Input.Input> inputs;
        DateTime lastTime;

        int score;

        public Game()
        {
            lastTime = DateTime.Now;
            screen = new Screen();
            PieceFactory.Reset();
            currentPiece = PieceFactory.GetNewPiece();
            feedbackNextPiece = new FeedbackNextPiece();
            feedbackNextPiece.SetupFeedbackNextPiece();
            lineManager = new LineManager();

            inputs = InputManager.GetInputs();
            score = 0;
        }

        public void AutoPieceMovement()
        {
            currentPiece.Move(InputManager.down);
            CheckCurrentPiece();
        }

        public void Update()
        {
            if ((DateTime.Now - lastTime).TotalSeconds >= TimeToAutoMove)
            {
                AutoPieceMovement();
                lastTime = DateTime.Now;
                Draw();
            }
        }

        public void Input(ConsoleKey key)
        {
            if (inputs.ContainsKey(key))
                currentPiece.Move(inputs[key]);

            if (key.Equals(InputManager.KeyForward))
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
        }

        public void Draw()
        {
            lineManager.DrawLines(screen, BlockedPiecesColor);
            currentPiece.Draw(screen);
            screen.Draw();

            Screen.WriteLine($"{SceneManager.tapString}Score: {score}.");
            feedbackNextPiece.Draw();
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
            {
                currentPiece.Move(InputManager.down);
            }

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
            try
            {
                lineManager.SetVerticesFromPiece(currentPiece);
            }
            catch (VertexAlreadyAddedException)
            {
                EndGame();
            }

            CheckForPoint();
            currentPiece = PieceFactory.GetNewPiece();

            bool keepGame = !lineManager.Colision(currentPiece);
            if (!keepGame)
            {
                EndGame();
            }
            else
            {
                feedbackNextPiece.SetupFeedbackNextPiece();
            }
        }

        private void EndGame()
        {
            SceneManager.Singleton.ChangeScene(new EndGame(score));
            SceneManager.Singleton.SetUpdate(null);
        }

        private void CheckForPoint()
        {
            int scoreInRound = lineManager.GetScore();
            score += scoreInRound;

            if(scoreInRound > 0)
            {
                while (lineManager.MoveLinesDown())
                {

                }
            }
        }
    }
}
