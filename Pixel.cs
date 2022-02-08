using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste
{
    public struct Pixel
    {
        public ConsoleColor color;
        public char image;

        public Pixel(ConsoleColor color, char image)
        {
            this.color = color;
            this.image = image;
        }
    }
}
