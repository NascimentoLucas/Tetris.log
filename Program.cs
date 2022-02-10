using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static Screen screen;
        static void Main(string[] args)
        {
            screen = new Screen();
            Game game = new Game(screen);

        }

        
    }
}
