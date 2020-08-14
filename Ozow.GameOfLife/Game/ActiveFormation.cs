using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class ActiveFormation : IActiveFormation
    {
        public IFormation Formation { get; set ; }
        public ICell[,] Grid { get; set; }
        public ICellPosition Position { get; set ; }
        public List<IInstruction> Instructions { get ; set ; }


        public ActiveFormation(IFormation formation, ICell[,] grid, ICellPosition formationPosition)
        {
            this.Formation = formation;
            this.Grid = grid;
            this.Position = formationPosition;
            this.InitializeInstructions();
        }

        private void InitializeInstructions()
        {
            throw new NotImplementedException();
        }

        public bool PrintFormation()
        {
            throw new NotImplementedException();
        }
    }
}
