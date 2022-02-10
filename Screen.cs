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
        const char emptySpace = '-';

        const ConsoleColor pieceColor = ConsoleColor.Green;
        const ConsoleColor standardColor = ConsoleColor.White;

        Pixel[] grid = new Pixel[row * col];

        public Screen()
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    grid[index] = new Pixel(standardColor, emptySpace);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }

        internal void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = standardColor;
            for (int i = 0; i < col; i++)
            {
                Console.Write($"{i.ToString("00")}.");
                for (int j = 0; j < row; j++)
                {
                    int index = i * col;
                    index += j;
                    Console.ForegroundColor = grid[index].color;
                    Console.Write(grid[index].gridChar);
                    grid[index].gridChar = emptySpace;
                    grid[index].color = standardColor;
                }
                Console.ForegroundColor = standardColor;
                Console.WriteLine($";");
            }
        }

        internal int GetIndex(int vX, int vY)
        {
           return vX + (vY * col); 
        }

        internal void DrawAt(int index, char v)
        {
            if (index < 0 || index > grid.Length - 1)
                return;

            grid[index].gridChar = v;
            grid[index].color = pieceColor;
        }
    }
}
