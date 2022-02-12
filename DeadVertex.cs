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

        public Point Point { get => point; }
        public char VertexChar { get => vertexChar; }

        public DeadVertex(Point point, char vertexChar)
        {
            this.point = point;
            this.vertexChar = vertexChar;
        }
    }
}
