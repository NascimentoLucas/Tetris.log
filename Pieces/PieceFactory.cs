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
            int middle = Screen.col / 2;
            switch (count)
            {
                case 0:
                    return new LinePiece(middle, 2);
                case 1:
                    return new LLeftPiece(middle, 2);
                case 2:
                    return new LRightPiece(middle, 2);
                case 3:
                    return new SnakePiece(middle, 2);
                case 4:
                    return new SquarePiece(middle, 2);
                case 5:
                    return new StandingSnakePiece(middle, 2);
            }
            count = 0;
            return new TPiece(middle, 2);
        }

    }
}
