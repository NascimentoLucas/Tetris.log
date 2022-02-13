using System;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.Scene;

namespace GazeusGamesEtapaTeste.GameCore
{
    public class FeedbackNextPiece
    {
        MiniScreen miniScreen;
        Piece nextPiece;
        DateTime lastTime;

        public FeedbackNextPiece()
        {
            miniScreen = new MiniScreen();
        }


        public void SetupFeedbackNextPiece()
        {
            nextPiece = PieceFactory.GetNextNewPiece();
            nextPiece.MoveTo(MiniScreen.col / 2, MiniScreen.row / 2);
            lastTime = DateTime.Now;
        }

        public void Draw()
        {
            if ((DateTime.Now - lastTime).TotalMilliseconds >= 500)
            {
                nextPiece.Move(Input.InputManager.rotLeft);
                lastTime = DateTime.Now;
            }
            Screen.WriteLine($"{SceneManager.tapString}Próxima peça: ");
            nextPiece.DrawInMiniScreen(miniScreen);
            miniScreen.Draw();
        }
    }
}
