using System;
using System.Collections.Generic;
using System.Drawing;

namespace GazeusGamesEtapaTeste
{
    public static class InputManager
    {
        public static readonly Point right = new Point(1, 0);
        public static readonly Point left = new Point(-1, 0);
        public static readonly Point down = new Point(0, 1);

        internal static Dictionary<string, Point> GetInputs()
        {

            return new Dictionary<string, Point>()
            {
                ["d"] = right,
                ["a"] = left,
                ["s"] = down,
            };
        }
    }
}
