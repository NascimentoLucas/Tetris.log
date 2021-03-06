using System;
using GazeusGamesEtapaTeste.Scene;
using GazeusGamesEtapaTeste.Pieces;

namespace GazeusGamesEtapaTeste.GameCore
{
    public class Screen
    {
        public const int col = 10;
        public const int row = 20;
        const char emptySpace = '-';

        const ConsoleColor standardColor = ConsoleColor.White;

        Pixel[] grid = new Pixel[row * col];

        public Screen()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int index = GazeusMath.MathG.GetIndex(i, j);
                    grid[index] = new Pixel(standardColor, emptySpace);
                }
            }
        }

        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public static void Write(object obj)
        {
            Console.Write(obj);
        }

        internal void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = standardColor;
            for (int i = 0; i < row; i++)
            {
                Write(SceneManager.tapString);
                for (int j = 0; j < col; j++)
                {
                    int index = GazeusMath.MathG.GetIndex(i, j);
                    Console.ForegroundColor = grid[index].color;
                    Write(grid[index].gridChar);
                    grid[index].gridChar = emptySpace;
                    grid[index].color = standardColor;
                }
                Console.ForegroundColor = standardColor;
                WriteLine($"");
            }
        }

        internal void DrawAt(int index, char v, ConsoleColor color)
        {
            if (index < 0 || index > grid.Length - 1)
                return;

            grid[index].gridChar = v;
            grid[index].color = color;
        }
    }
}
