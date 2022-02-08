using System;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen();
            
            Piece piece = new Piece(3, 2);
            piece.Draw(screen);

            screen.Draw();

            Console.ReadLine();
        }
    }
}
