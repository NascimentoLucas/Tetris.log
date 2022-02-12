using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste.Pieces.Types
{
    public class LinePiece : Piece
    {
        public LinePiece(int x, int y) : base(x, y)
        {
        }

        protected override List<Vertex> GenerateVertex()
        {
            return new List<Vertex>()
            {
                new Vertex(0, 0, ConsoleColor.Cyan),
                new Vertex(-1, 0, ConsoleColor.Cyan),
                new Vertex(1, 0, ConsoleColor.Cyan),
                new Vertex(2, 0, ConsoleColor.Cyan),
            };
        }

    }
}
