using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IActiveFormation
    {
        public IToolBox ToolBox { get; set; }
        public IFormation Formation { get; set; }

        public ICell[,] Grid { get; set; }

        public ICellPosition Position { get; set; }

        public Queue<IInstruction> Instructions { get; set; }

        public bool PrintFormation(ICell[,] grid);

    }
}
