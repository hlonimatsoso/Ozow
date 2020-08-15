using Ozow.GameOfLife.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IToolBox
    {
        public Random Random { get; set; }

        public bool IsCellWall(ICellPosition position);

        public bool IsCellWall(byte row,byte col);

        public List<ICellPosition> GetAllNeighbourgs(byte row, byte col);


        public List<ICellPosition> GetAllNeighbourgs(ICellPosition position);

        public int GenerateRandomNumber(int min, int max);

        public ICellPosition GetRandomCellPosition();

        public Queue<IInstruction> CreateInstructions(string instructionString, ICell[,] grid, ICellPosition position);
    }
}
