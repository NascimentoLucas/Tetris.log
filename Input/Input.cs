using System.Drawing;

namespace GazeusGamesEtapaTeste.Input
{
    public struct Input
    {
        Point movement;
        int rotation;
        string description;

        public Point Movement { get => movement; }
        public int Rotation { get => rotation; }
        public string Description { get => description; }

        public Input(Point movement, int rotation, string description)
        {
            this.movement = movement;
            this.rotation = rotation;
            this.description = description;
        }
    }
}
