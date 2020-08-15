using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game.Instructions
{
    public class Right : IInstruction
    {
        public string Name { get { return "Move cursor Right"; } }
        public ICell[,] Grid { get ; set ; }
        public ICellPosition Position { get ; set ; }


        public Right(ICell[,] grid, ICellPosition position)
        {
            this.Grid = grid;
            this.Position = position;
        }

        public bool Execute()
        {
            bool result = false;

            this.Position.Column += 1;
            result = true;

            return result;
        }
    }
}
