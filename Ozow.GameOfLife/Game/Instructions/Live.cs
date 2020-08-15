using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game.Instructions
{
    public class Live : IInstruction
    {
        public string Name { get { return "Live"; } }
        public ICell[,] Grid { get; set; }
        public ICellPosition Position { get; set; }


        public Live(ICell[,] grid, ICellPosition position)
        {
            this.Grid = grid;
            this.Position = position;
        }

        public bool Execute()
        {
            bool result = false;

            this.Grid[this.Position.Row - 1, this.Position.Column - 1].State = CellState.Alive;

            return result;
        }
    }
}
