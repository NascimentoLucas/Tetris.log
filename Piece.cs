using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste
{
    public class Piece
    {
        int x;
        int y;
        List<Vertex> vertices;

        public Piece(int x, int y)
        {
            this.x = x;
            this.y = y;
            vertices = new List<Vertex>()
            {
                new Vertex(0,0),
                new Vertex(0,1),
                new Vertex(-1,0),
                new Vertex(1,0),
            };
        }

        internal void Draw(Screen screen)
        {
            foreach (Vertex v in vertices)
            {
                int vX = x + v.X;
                int vY = y - v.Y;
                int index = vX + (vY * Screen.col);
                screen.DrawAt(index, v.Image);
            }
        }
    }
}
