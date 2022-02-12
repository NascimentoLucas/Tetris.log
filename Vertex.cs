using System;
using System.Numerics;
using System.Drawing;
using GazeusGamesEtapaTeste.GazeusMath;

namespace GazeusGamesEtapaTeste
{
    public struct Vertex
    {
        Point point;
        char vertexChar;
        ConsoleColor color;

        public char VertexChar { get => vertexChar; }
        public ConsoleColor Color { get => color;  }

        public Vertex(int x, int y, ConsoleColor color)
        {
            point = new Point(x, y);
            vertexChar = '.';
            this.color = color;
        }


        internal Point GetTransformedPoint(Point position, int angle)
        {
            Point screePos = MathG.GetScreenPositon(point, angle);
            int vertexX = position.X + screePos.X;
            int vertexY = position.Y - screePos.Y;
            return new Point(vertexX, vertexY);
        }

        internal DeadVertex GetDeadVertex(Point position, int angle)
        {
            Point p = GetTransformedPoint(position, angle);
            return new DeadVertex(p, vertexChar, color);
        }
    }
}
