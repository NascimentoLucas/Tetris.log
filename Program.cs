using System;

namespace GazeusGamesEtapaTeste
{
    class Program
    {
        public const int col = 5;
        public const int row = 5;

        static void Main(string[] args)
        {

            string[] grid = new string[row * col];

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    grid[i] = "-";
                }
            }

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    grid[index] = index.ToString("00");
                    grid[index] = $"{i}({index}){j};";
                    grid[index] = $"-";
                }
            }

            Piece piece = new Piece(3, 2);
            piece.Draw(grid);

            for (int i = 0; i < col; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    Console.Write(grid[index]);
                }
            }

            Console.ReadLine();
        }
    }
}
