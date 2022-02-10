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
        public char gridChar;

        public Pixel(ConsoleColor color, char image)
        {
            this.color = color;
            this.gridChar = image;
        }
    }
}
