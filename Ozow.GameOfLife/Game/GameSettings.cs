using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class GameSettings
    {
        public int GameSpeed { get; set; }

        public byte BoardHeight { get; set; }

        public byte BoardWidth { get; set; }

        public List<IFormation> Formations { get; set; }

    }

   
}
