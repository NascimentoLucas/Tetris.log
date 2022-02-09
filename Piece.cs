using System;
using System.Drawing;
using System.Collections.Generic;

namespace GazeusGamesEtapaTeste
{
    public class Piece
    {
        int x;
        int y;
        List<Vertex> vertices;
        int rot = 90;
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

        internal void Move(Point mov)
        {
            this.x += mov.X + InputManager.down.X;
            this.y += mov.Y + InputManager.down.Y;
        }

        internal void Draw(Screen screen)
        {
            rot += 90;
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
