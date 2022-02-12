using System;
using System.Collections.Generic;
using System.Drawing;
using GazeusGamesEtapaTeste.Pieces;

namespace GazeusGamesEtapaTeste.Table
{
    public class LineManager
    {
        LineTable[] lines;

        public LineManager()
        {
            lines = new LineTable[Screen.row];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = new LineTable(this, i);
            }
        }

        internal void DrawLines(Screen screen, ConsoleColor color)
        {
            foreach (LineTable line in lines)
            {
                line.Draw(screen, color);
            }
        }

        internal void GetVertexFromPiece(Piece currentPiece)
        {
            List<DeadVertex> vertices = currentPiece.GetTransformed();

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
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].IsAllFill())
                {
                    score++;
                    lines[i].EmptyLine();
                }
            }

            return score;
        }

        internal void MoveLinesDown()
        {
            bool repeat;
            bool result;
            do
            {
                repeat = false;
                for (int i = lines.Length - 2; i >= 0; i--)
                {
                    result = lines[i].CheckUnderLine();
                    repeat = repeat || result;
                }
            } while (repeat);
        }

        internal bool IsAValidIndex(int underLineIndex)
        {
            return underLineIndex < lines.Length;
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
