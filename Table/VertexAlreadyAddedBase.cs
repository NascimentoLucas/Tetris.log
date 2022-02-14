using System;
using GazeusGamesEtapaTeste.GazeusMath;
using GazeusGamesEtapaTeste.GameCore;

namespace GazeusGamesEtapaTeste.Table
{
    public class VertexAlreadyAddedException : ArgumentException
    {
        public VertexAlreadyAddedException(int index) : base($"index ({index}) alreday have { nameof(Vertex) }") { }
        public VertexAlreadyAddedException(string message) : base(message) { }
        public VertexAlreadyAddedException(string message, Exception e) : base(message, e) { }
    }
}