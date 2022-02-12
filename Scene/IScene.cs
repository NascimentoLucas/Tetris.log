using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste.Scene
{
    public interface IScene
    {
        void Input(ConsoleKey key);
        void Draw();
    }
}
