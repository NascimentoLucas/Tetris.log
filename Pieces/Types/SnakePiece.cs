using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste.Pieces.Types
{
    public class SnakePiece : Piece
    {
        public SnakePiece(int x, int y) : base(x, y)
        {
        }

        protected override List<Vertex> GenerateVertex()
        {
            return new List<Vertex>()
            {
                new Vertex(0,0, ConsoleColor.Red),
                new Vertex(1,0, ConsoleColor.Red),
                new Vertex(1,1, ConsoleColor.Red),
                new Vertex(2,1, ConsoleColor.Red),
            };
        }
    }
}
