using System;
using GazeusGamesEtapaTeste.GazeusMath;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Table
{
    public class LineTable
    {
        LineManager manager;
        DeadVertex[] vertices;
        int myIndex;

        bool wasEmptied;

        public bool WasEmptied { get => wasEmptied; }
        public int UnderLineIndex { get => myIndex + 1; }

        public LineTable(LineManager manager, int underLineIndex)
        {
            this.manager = manager;
            this.myIndex = underLineIndex;
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
                //throw new ArgumentException($"index ({x}) alreday have {nameof(Vertex)} ");
                return;

            vertices[x] = vertex;
        }

        internal void Draw(Screen screen, ConsoleColor color)
        {
            foreach (DeadVertex vertex in vertices)
            {
                if (vertex == null) continue;
                int index = MathG.GetIndex(myIndex, vertex.Point.X);
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

        internal bool CheckUnderLine()
        {
            if (!manager.IsAValidIndex(UnderLineIndex)) return false;

            LineTable underLine = manager.GetLine(UnderLineIndex);
            if (underLine.wasEmptied)
            {
                manager.SwapLines(myIndex, UnderLineIndex);
                myIndex++;
                return true;
            }

            return false;
        }
    }
}
