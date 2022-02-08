using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste
{
    public class Vertex
    {
        int x;
        int y;
        char image = '.';

        public int X { get => x; }
        public int Y { get => y; }
        public char Image { get => image; }

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
