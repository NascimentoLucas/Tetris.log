using System;
using GazeusGamesEtapaTeste.Pieces.Types;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Pieces
{
    public static class PieceFactory
    {
        const int middle = Screen.col / 2;
        private const int MaxPieces = 5;
        static int count = 0;

        static Piece GetPiece(int count)
        {
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

            return new TPiece(middle, 2);
        }

        internal static void Reset()
        {
            count = -1;
        }

        public static Piece GetNewPiece()
        {
            count++;
            if (count > MaxPieces)
                count = -1;
            return GetPiece(count);
        }

        public static Piece GetNextNewPiece()
        {
            return GetPiece(count + 1);
        }

    }
}
