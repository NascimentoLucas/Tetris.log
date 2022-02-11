using System;
using GazeusGamesEtapaTeste.Pieces.Types;

namespace GazeusGamesEtapaTeste.Pieces
{
    public static class PieceFactory
    {

        static int count = -1;

        public static Piece GetNewPiece()
        {
            count++;
            switch (count)
            {
                case 0:
                    return new LinePiece(Screen.row / 2, 2);
                case 1:
                    return new LLeftPiece(Screen.row / 2, 2);
                case 2:
                    return new LRightPiece(Screen.row / 2, 2);
                case 3:
                    return new SnakePiece(Screen.row / 2, 2);
                case 4:
                    return new SquarePiece(Screen.row / 2, 2);
                case 5:
                    return new StandingSnakePiece(Screen.row / 2, 2);
            }
            count = 0;
            return new TPiece(Screen.row / 2, 2);
        }

    }
}
