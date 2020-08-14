using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IGameUiDrawer
    {
        public void Clear();

        public void Refresh(ICell[,] latestGeneration);
    }
}
