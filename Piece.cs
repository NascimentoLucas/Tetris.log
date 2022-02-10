using System;
using System.Drawing;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    public class Piece
    {
        Screen screen;
        List<Vertex> vertices;

        Point position;
        int rot = 0;
        int id;

        public int Id { get => id; }
        public int Index { get => Screen.GetIndex(position.X, position.Y); }
        public List<Vertex> Vertices { get => vertices; }
        public Point Position { get => position; }

        public Piece(Screen screen, int x, int y, int id)
        {
            this.screen = screen;
            position = new Point(x, y);
            this.id = id;
            vertices = new List<Vertex>()
            {
                new Vertex(0,0),
                new Vertex(0,1),
                new Vertex(-1,0),
                new Vertex(1,0),

            };
        }

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

        internal void Draw(ConsoleColor color)
        {
            foreach (Vertex vertex in vertices)
            {
                vertex.RotateTo(rot);
                Point p = vertex.Point;
                int vertexX = position.X + p.X;
                int vertexY = position.Y - p.Y;
                int index = Screen.GetIndex(vertexX, vertexY);
                screen.DrawAt(index, vertex.VertexChar, color);
            }

        }

        internal bool Colision(Piece otherPiece)
        {
            Point myPoint;
            Point otherPoint;
            foreach (Vertex myVertex in vertices)
            {
                myPoint = new Point(position.X + myVertex.Point.X,
                    position.Y - myVertex.Point.Y);

                foreach (Vertex otherVertex in otherPiece.vertices)
                {
                    otherPoint = new Point(otherPiece.position.X + otherVertex.Point.X,
                        otherPiece.position.Y - otherVertex.Point.Y);

                    if (myPoint == otherPoint)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal bool IsAtLimit()
        {
            foreach (Vertex v in vertices)
            {
                v.RotateTo(rot);
                Point p = v.Point;
                int vY = position.Y - p.Y;

                if (vY >= Screen.col - 1)
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
    }
}
