using System;
using System.Drawing;
using System.Collections.Generic;
using GazeusGamesEtapaTeste.Input;

namespace GazeusGamesEtapaTeste
{
    public class Piece
    {
        int x;
        int y;
        List<Vertex> vertices;
        int rot = 0;
        public Piece(int x, int y)
        {
            this.x = x;
            this.y = y;
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
            this.x += mov.Movement.X;
            this.y += mov.Movement.Y + 1;
            rot += mov.Rotation;
        }

        internal void Draw(Screen screen)
        {
            foreach (Vertex v in vertices)
            {
                v.RotateTo(rot);
                Point p = v.Point;
                int vX = x + p.X;
                int vY = y - p.Y;
                int index = vX + (vY * Screen.col);
                screen.DrawAt(index, v.Image);
            }
        }
    }
}
