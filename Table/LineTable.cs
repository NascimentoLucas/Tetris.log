using System;
using GazeusGamesEtapaTeste.GazeusMath;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Table
{
    public class LineTable
    {
        LineManager manager;
        DeadVertex[] vertices;

        bool wasEmptied;

        public bool WasEmptied { get => wasEmptied; set => wasEmptied = value; }

        public LineTable(LineManager manager, int myIndex)
        {
            this.manager = manager;
            wasEmptied = false;
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
                throw new VertexAlreadyAddedException(x);

            vertices[x] = vertex;
        }

        internal void Draw(int lineIndex, Screen screen, ConsoleColor color)
        {
            foreach (DeadVertex vertex in vertices)
            {
                if (vertex == null) continue;
                int index = MathG.GetIndex(lineIndex, vertex.Point.X);
                screen.DrawAt(index, vertex.VertexChar, vertex.Color);
            }
        }

        internal bool IsFillAt(int x)
        {
            if (x < 0 || x > vertices.Length - 1)
                throw new ArgumentException($"index out of range");

            return vertices[x] != null;
        }

        internal void EmptyLine()
        {
            wasEmptied = true;
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = null;
            }
        }
    }
}
