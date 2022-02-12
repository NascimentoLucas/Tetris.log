﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace GazeusGamesEtapaTeste.Input
{
    public static class InputManager
    {
        public static readonly Input right = new Input(new Point(1, 0), 0, "Mover para Direita");
        public static readonly Input left = new Input(new Point(-1, 0), 0, "Mover para Esquerda");
        public static readonly Input down = new Input(new Point(0, 0), 0, "Fazer nada");

        public static readonly Input rotLeft = new Input(new Point(0, 0), 90, "Girar para Esquerda");
        public static readonly Input rotRight = new Input(new Point(0, 0), -90, "Girar para Direita");

        internal static Dictionary<ConsoleKey, Input> GetInputs()
        {

            return new Dictionary<ConsoleKey, Input>()
            {
                [ConsoleKey.D] = right,
                [ConsoleKey.A] = left,
                [ConsoleKey.Q] = rotLeft,
                [ConsoleKey.E] = rotRight,
                [ConsoleKey.S] = down,
            };
        }
    }
}
