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

        internal void Draw()
        {
            Array values = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(values.Length));
            Draw((ConsoleColor)randomColor);
        }
        internal void Draw(ConsoleColor color)
        {
            foreach (Vertex vertex in vertices)
            {
                Point p = vertex.GetTransformedPoint(position, rot);
                int index = Screen.GetIndex(p.X, p.Y);
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

        internal bool IsAtLimit()
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, rot);
                if (p.Y >= Screen.col - 1)
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

        internal void GetVerticesAtLimit(ref int count)
        {
            foreach (Vertex v in vertices)
            {
                Point p = v.GetTransformedPoint(position, rot);
                if (p.Y >= Screen.col - 1)
                {
                    count++;
                }
            }
        }

        internal void RemoveVerticesAtLimit()
        {
            for (int i = vertices.Count - 1; i >= 0; i--)
            {
                Point p = vertices[i].GetTransformedPoint(position, rot);

                if (p.Y >= Screen.col - 1)
                {
                    vertices.RemoveAt(i);
                }
            }
        }
    }
}
