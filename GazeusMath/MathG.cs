using System;
using System.Numerics;
using System.Drawing;


namespace GazeusGamesEtapaTeste.GazeusMath
{
    public static class MathG
    {
        public static Point GetScreenPositon(Point axis, int angle)
        {
            Matrix4x4 me = new Matrix4x4(
                1, 0, 0, axis.X,
                0, 1, 0, axis.Y,
                0, 0, 1, 1,
                0, 0, 0, 1);

            double rad = (angle * (Math.PI)) / 180;
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);

            Matrix4x4 rot = new Matrix4x4(
                cos, -sin, 0, 0,
                sin, cos, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            Matrix4x4 result = Matrix4x4.Multiply(rot, me);
            axis.X = (int)result.M14;
            axis.Y = (int)result.M24;

            return axis;
        }

        internal static int GetIndex(int i, int j)
        {
            return j + (i * Screen.col);
        }
    }
}
