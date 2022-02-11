using System;
using GazeusGamesEtapaTeste.Pieces.Types;

namespace GazeusGamesEtapaTeste.Pieces
{
    public static class PieceFactory
    {
        static readonly Piece[] list = new Piece[]
        {
            //new LinePiece(Screen.row / 2, 2),

            //new LLeftPiece(Screen.row / 2, 2),
            //new LRightPiece(Screen.row / 2, 2),

            //new SnakePiece(Screen.row / 2, 2),
            //new SquarePiece(Screen.row / 2, 2),

            //new StandingSnakePiece(Screen.row / 2, 2),
            new TPiece(Screen.row / 2, 2),
        };


        static int count = 0;
        public static Piece GetNewPiece()
        {
            return list[count % list.Length];
        }
    }
}
