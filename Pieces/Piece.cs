using System;
using System.Drawing;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.GazeusMath;

namespace GazeusGamesEtapaTeste.Pieces
{
    public abstract class Piece
    {
        readonly static int maxColor = Enum.GetValues(typeof(ConsoleColor)).Length;
        static int lastColor = 0;

        List<Vertex> vertices;

        Point position;
        int angle = 0;

        public List<Vertex> Vertices { get => vertices; }
        public Point Position { get => position; }
        public int Angle { get => angle; }

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
            angle += mov.Rotation;
        }

        internal void RevertMovement(Input.Input mov)
        {
            position.X -= mov.Movement.X;
            position.Y -= mov.Movement.Y + 1;
            angle -= mov.Rotation;
        }

        internal List<DeadVertex> GetTransformed()
        {
            List<DeadVertex> verts = new List<DeadVertex>();
            foreach (Vertex myVertex in vertices)
            {
                DeadVertex dV = myVertex.GetDeadVertex(position, angle);
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
                Point p = vertex.GetTransformedPoint(position, angle);
                int index = MathG.GetIndex(p.Y, p.X);
                screen.DrawAt(index, vertex.VertexChar, color);
            }
        }

        internal bool IsAtLimit(int limit)
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, angle);
                if (p.Y >= limit)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
