using System;
using System.Numerics;

namespace GazeusGamesEtapaTeste
{
    public struct Vertex
    {
        int x;
        int y;
        char image;
        int rot;

        public int X { get => Rotate(x); }
        public int Y { get => Rotate(y); }
        public char Image { get => image; }

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
            image = '.';
            rot = 0;
        }

        int Rotate(int axis)
        {
            int z = 1;
            Console.WriteLine(x + "." + y);
            Matrix4x4 me = new Matrix4x4(
                1, 0, 0, x,
                0, 1, 0, y,
                0, 0, 1, z,
                0, 0, 0, 1);

            float angle = 90;
            do
            {
                double rad = (angle * (Math.PI)) / 180;
                float cos = (float)Math.Cos(rad);
                float sin = (float)Math.Sin(rad);

                Matrix4x4 rot = new Matrix4x4(
                    cos, -sin, 0, 0,
                    sin, cos, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);


                //rot = new Matrix4x4(
                //     1, 0, 0, 0,
                //     0, cos, -sin, 0,
                //     0, sin, cos, 0,
                //     0, 0, 0, 1);


                //rot = new Matrix4x4(
                //    cos, 0, sin, 0,
                //    0, 1, 0, 0,
                //    -sin, 0, cos, 0,
                //    0, 0, 0, 1);

                Matrix4x4 result = Matrix4x4.Multiply(rot, me);
                Console.WriteLine($"{angle}: {(int)result.M14}.{(int)result.M24}");
                Console.WriteLine("z: " + (int)result.M34);
                angle += 90;
            } while (angle < 360);

            return axis;
        }


    }
}
