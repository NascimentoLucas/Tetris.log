using System;
using System.Drawing;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.GazeusMath;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Pieces
{
    public abstract class Piece
    {
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
            position.Y += mov.Movement.Y;
            angle += mov.Rotation;
        }

        internal void RevertMovement(Input.Input mov)
        {
            position.X -= mov.Movement.X;
            position.Y -= mov.Movement.Y;
            angle -= mov.Rotation;
        }

        internal List<DeadVertex> GetTransformedVertices()
        {
            List<DeadVertex> verts = new List<DeadVertex>();
            foreach (Vertex myVertex in vertices)
            {
                DeadVertex dV = myVertex.GetDeadVertex(position, angle);
                verts.Add(dV);
            }

            return verts;
        }

        internal void Draw(Screen screen)
        {
            foreach (Vertex vertex in vertices)
            {
                Point p = vertex.GetTransformedPoint(position, angle);
                int index = MathG.GetIndex(p.Y, p.X);
                screen.DrawAt(index, vertex.VertexChar, vertex.Color);
            }
        }

        internal bool IsAtHightLimit(int limit)
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

        internal bool IsAtWidthLimit(int limit)
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, angle);
                if (p.X >= limit || p.X < 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal void DrawInMiniScreen(MiniScreen miniScreen)
        {
            foreach (Vertex vertex in vertices)
            {
                Point p = vertex.GetTransformedPoint(position, angle);
                int index = MiniScreen.GetIndex(p.Y, p.X);
                miniScreen.DrawAt(index, vertex.VertexChar, vertex.Color);
            }
        }

        internal void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
            angle = 0;
        }
    }
}
