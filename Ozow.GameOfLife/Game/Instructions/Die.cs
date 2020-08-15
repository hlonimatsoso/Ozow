using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game.Instructions
{
    public class Die : IInstruction
    {
        public string Name { get { return "Die"; } }
        public ICell[,] Grid { get ; set ; }
        public ICellPosition Position { get ; set ; }


        public Die(ICell[,] grid, ICellPosition position)
        {
            this.Grid = grid;
            this.Position = position;
        }

        public bool Execute()
        {
            bool result = false;

            this.Grid[this.Position.Row,this.Position.Column].State = CellState.Dead;

            return result;
        }
    }
}
