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

        public char VertexChar { get => vertexChar; }

        public Vertex(int x, int y)
        {
            point = new Point(x, y);
            vertexChar = '.';
        }
        

        internal Point GetTransformedPoint(Point position, int rot)
        {
            Point screePos = MathG.GetScreenPositon(point, rot);
            int vertexX = position.X + screePos.X;
            int vertexY = position.Y - screePos.Y;
            return new Point(vertexX, vertexY);
        }
    }
}
