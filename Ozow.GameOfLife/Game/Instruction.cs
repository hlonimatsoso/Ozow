using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class Instruction : IInstruction
    {
        public string Name { get; }

        public ICell[,] Grid { get; set ; }
        public ICellPosition Position { get ; set ; }

        public bool Execute()
        {
            throw new NotImplementedException();
        }
    }
}
