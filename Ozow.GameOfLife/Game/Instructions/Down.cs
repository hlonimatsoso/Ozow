using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game.Instructions
{
    public class Down : IInstruction
    {
        public string Name { get { return "Down"; } }
        public ICell[,] Grid { get ; set ; }
        public ICellPosition Position { get ; set ; }


        public Down(ICell[,] grid, ICellPosition position)
        {
            this.Grid = grid;
            this.Position = position;
        }

        public bool Execute()
        {
            bool result = false;

            this.Position.Row += 1;

            return result;
        }
    }
}
