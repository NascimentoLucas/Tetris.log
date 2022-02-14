using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GazeusGamesEtapaTeste.Pieces;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Table
{
    public class LineManager
    {
        List<LineTable> lines;

        public LineManager()
        {
            lines = new List<LineTable>();
            for (int i = 0; i < Screen.row; i++)
            {
                lines.Add(new LineTable(this, i));
            }
        }

        internal void DrawLines(Screen screen, ConsoleColor color)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Draw(i, screen, color);
            }
        }

        internal void SetVerticesFromPiece(Piece currentPiece)
        {
            List<DeadVertex> vertices = currentPiece.GetTransformedVertices();

            foreach (DeadVertex vertex in vertices)
            {
                lines[vertex.Point.Y].AddVertexAt(vertex.Point.X, vertex);
            }
        }

        internal bool Colision(Piece currentPiece)
        {
            foreach (Vertex vertex in currentPiece.Vertices)
            {
                Point p = vertex.GetTransformedPoint(currentPiece.Position,
                    currentPiece.Angle);

                if (lines[p.Y].IsFillAt(p.X))
                    return true;
            }

            return false;
        }

        internal int GetScore()
        {
            int score = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsAllFill())
                {
                    score++;
                    lines[i].EmptyLine();
                }
            }

            return score;
        }

        internal bool MoveLinesDown()
        {
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].WasEmptied)
                {
                    lines.RemoveAt(i);
                    lines.Insert(0, new LineTable(this, 0));
                    return true;
                }
            }

            return false;
        }

        internal void SwapLines(int above, int under)
        {
            LineTable temp = lines[under];
            lines[under] = lines[above];
            lines[above] = temp;
        }

        internal LineTable GetLine(int index)
        {
            return lines[index];
        }
    }
}
