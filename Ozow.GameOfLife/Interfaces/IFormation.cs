using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IFormation
    {
        //public ICell[,] FormationGrid { get; set; }

        //public ICellPosition Position { get; set; }

        public string Name { get; set; }

        public byte ID { get; set; }

        public byte Width { get; set; }

        public string Instructions { get; set; }

    }
}
