using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste
{
    public class Screen
    {
        public const int col = 20;
        public const int row = 20;

        char[] grid = new char[row * col];

        public Screen()
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    grid[index] = '-';
                }
            }
        }

        internal void Draw()
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    Console.Write(grid[index]);
                }
                Console.WriteLine("");
            }
        }

        internal void DrawAt(int index, char v)
        {
            if (index < 0 || index > grid.Length - 1)
                return;

            grid[index] = v;
        }
    }
}
