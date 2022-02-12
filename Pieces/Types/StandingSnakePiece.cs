using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste.Pieces.Types
{
    public class StandingSnakePiece : Piece
    {
        public StandingSnakePiece(int x, int y) : base(x, y)
        {
        }

        protected override List<Vertex> GenerateVertex()
        {
            return new List<Vertex>()
            {
                new Vertex(0, 1, ConsoleColor.Green),
                new Vertex(0, 0, ConsoleColor.Green),
                new Vertex(-1, 0, ConsoleColor.Green),
                new Vertex(-1,-1, ConsoleColor.Green),
            };
        }
    }
}
