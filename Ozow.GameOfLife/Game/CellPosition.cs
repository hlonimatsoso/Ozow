using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class CellPosition : ICellPosition
    {

        public CellPosition(byte row, byte column)
        {
            this.Row = row;
            this.Column = column;
        }

        public byte Row { get; set; }
        public byte Column { get; set ; }
    }
}
