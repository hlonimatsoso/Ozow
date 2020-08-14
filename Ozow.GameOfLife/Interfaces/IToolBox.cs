using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IToolBox
    {
        public bool IsCellWall(ICellPosition position);

        public List<ICellPosition> GetAllNeighbourgs(ICellPosition position);

        public int GenerateRandomNumber(int min, int max);
    }
}
