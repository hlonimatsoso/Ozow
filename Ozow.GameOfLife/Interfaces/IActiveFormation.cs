using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IActiveFormation
    {
        public IFormation Formation { get; set; }

        public ICell[,] Grid { get; set; }

        public ICellPosition Position { get; set; }

        public List<IInstruction> Instructions { get; set; }

        public bool PrintFormation();

    }
}
