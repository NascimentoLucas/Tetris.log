using System;
using GazeusGamesEtapaTeste.GazeusMath;

namespace GazeusGamesEtapaTeste.Table
{
    public class LineTable
    {
        DeadVertex[] vertices;
        public LineTable()
        {
            vertices = new DeadVertex[Screen.col];
        }

        public bool IsAllFill()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] == null)
                    return false;
            }

            return true;
        }

        public void AddVertexAt(int x, DeadVertex vertex)
        {
            if (x < 0 || x > vertices.Length - 1)
                throw new ArgumentException($"index out of range");

            if (vertices[x] != null)
                throw new ArgumentException($"index ({x}) alreday have {nameof(Vertex)} ");

            vertices[x] = vertex;
        }

        internal void Draw(Screen screen, ConsoleColor color)
        {
            foreach (DeadVertex vertex in vertices)
            {
                if (vertex == null) continue;
                int index = MathG.GetIndex(vertex.Point.Y, vertex.Point.X);
                screen.DrawAt(index, vertex.VertexChar, color);
            }
        }
    }
}
