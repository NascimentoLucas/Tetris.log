using System;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen();

            Piece piece = new Piece(3, 2);


            bool running = true;
            Random r = new Random();
            int count = 0;
            while (running)
            {
                piece.Draw(screen);
                screen.Draw();
                Console.ReadLine();
                count += r.Next(0, 3);

                piece.Move(r.Next(0, 2), r.Next(0, 2));

                running = count < 1000;
            }

        }
    }
}
