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

        public string AliveSymbol { get; set; }
        
        public string DeadSymbol { get; set; }

        public string WallSymbol { get; set; }

        public string ExplosionSymbol { get; set; }

        public byte LowKillCount { get; set; }

        public byte HighKillCount { get; set; }

        public byte ResserectionCount { get; set; }

        public byte WindowPadding { get; set; }

        public byte GameMatrixFormationHeightMargin { get; set; }

        public byte GameMatrixFormationWidthMargin { get; set; }

        public Formation[] Formations { get; set; }


    }


}
