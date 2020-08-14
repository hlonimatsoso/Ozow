using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class Cell : ICell
    {
        public CellState State { get ; set ; }

        public CellState Interogate(ICellPosition currentPosition)
        {
            throw new NotImplementedException();
        }
    }
}
