using Ozow.GameOfLife.Game;
using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ozow.GameOfLife
{
    public static class Extensions
    {
        public static ICellPosition[,] GetAllCellNeighbours(this ICell[,] theMatrix ,byte row, byte col)
        {
            ICellPosition[,] result = new CellPosition[0,0];

            return result;
        }
    }
}
