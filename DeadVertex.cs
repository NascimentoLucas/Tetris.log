using System;
using System.Numerics;
using System.Drawing;
using GazeusGamesEtapaTeste.GazeusMath;


namespace GazeusGamesEtapaTeste
{
    public class DeadVertex
    {
        Point point;
        char vertexChar;
        ConsoleColor color;

        public Point Point { get => point; }
        public char VertexChar { get => vertexChar; }
        public ConsoleColor Color { get => color; }

        public DeadVertex(Point point, char vertexChar, ConsoleColor color)
        {
            this.point = point;
            this.vertexChar = vertexChar;
            this.color = color;
        }
    }
}
