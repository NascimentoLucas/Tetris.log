using System;
using System.Drawing;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.GazeusMath;

namespace GazeusGamesEtapaTeste.Pieces
{
    public abstract class Piece
    {
        readonly static int maxColor = System.Enum.GetValues(typeof(ConsoleColor)).Length;
        static int lastColor = 0;

        List<Vertex> vertices;

        Point position;
        int rot = 0;


        public Piece(int x, int y)
        {
            position = new Point(x, y);
            vertices = GenerateVertex();
        }

        protected abstract List<Vertex> GenerateVertex();

        internal void Move(Input.Input mov)
        {
            position.X += mov.Movement.X;
            position.Y += mov.Movement.Y + 1;
            rot += mov.Rotation;
        }

        internal void RevertMovement(Input.Input mov)
        {
            position.X -= mov.Movement.X;
            position.Y -= mov.Movement.Y + 1;
            rot -= mov.Rotation;
        }

        internal List<DeadVertex> GetTransformed()
        {
            List<DeadVertex> verts = new List<DeadVertex>();
            foreach (Vertex myVertex in vertices)
            {
                DeadVertex dV = myVertex.GetDeadVertex(position, rot);
                verts.Add(dV);
            }

            return verts;
        }

        internal void SequenceColorDraw(Screen screen)
        {
            Draw(screen, (ConsoleColor)(lastColor++ % maxColor));
        }

        internal void Draw(Screen screen, ConsoleColor color)
        {
            foreach (Vertex vertex in vertices)
            {
                Point p = vertex.GetTransformedPoint(position, rot);
                int index = MathG.GetIndex(p.Y, p.X);
                screen.DrawAt(index, vertex.VertexChar, color);
            }
        }

        internal bool Colision(Piece otherPiece)
        {
            Point myPoint;
            Point otherPoint;
            foreach (Vertex myVertex in vertices)
            {
                myPoint = myVertex.GetTransformedPoint(position, rot);
                foreach (Vertex otherVertex in otherPiece.vertices)
                {
                    otherPoint = otherVertex.GetTransformedPoint(otherPiece.position
                        , otherPiece.rot);
                    if (myPoint == otherPoint)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool IsAtLimit(int limit)
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, rot);
                if (p.Y >= limit)
                {
                    return true;
                }
            }

            return false;
        }

        internal void RemoveVertex(int i)
        {
            vertices.RemoveAt(i);
        }

        internal void GetVerticesAtLimit(ref int count, int limit)
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, rot);
                if (p.Y == limit)
                {
                    count++;
                }
            }
        }

        internal void RemoveVerticesAtLimit(int limit)
        {
            for (int i = vertices.Count - 1; i >= 0; i--)
            {
                Point p = vertices[i].GetTransformedPoint(position, rot);

                if (p.Y >= limit)
                {
                    vertices.RemoveAt(i);
                }
            }
        }


    }
}
