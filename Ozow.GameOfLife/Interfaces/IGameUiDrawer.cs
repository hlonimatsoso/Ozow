using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IGameUiDrawer
    {
        public string AliveSymbol { get; }
        public string DeadSymbol { get; }
        public string WallSymbol { get; }
        public string ExplosionSymbol { get; }

        public void Clear();

        public void Refresh(ICell[,] latestGeneration);
    }
}
