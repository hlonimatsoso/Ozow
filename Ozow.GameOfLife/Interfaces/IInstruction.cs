using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IInstruction
    {
        public string Name { get; }

        public ICell[,] Grid { get; set; }

        public ICellPosition Position { get; set; }

        public bool Execute();
    }
}
