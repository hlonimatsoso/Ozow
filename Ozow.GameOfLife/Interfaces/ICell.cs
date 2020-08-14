using Ozow.GameOfLife.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface ICell
    {
        public CellState State { get; set; }

        public CellState Interogate(ICellPosition currentPosition);
    }
}
