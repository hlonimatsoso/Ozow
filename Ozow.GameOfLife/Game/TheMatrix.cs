using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class TheMatrix : IMatrix
    {
        public ICell[,] TheGrid { get; set; }



        public void GenerateDefaultGeneration()
        {
            foreach (var cell in this.TheGrid)
                cell.State = CellState.Dead;
        }

        public void GenerateNextGeneration()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            this.GenerateDefaultGeneration();
        }
    }
}
