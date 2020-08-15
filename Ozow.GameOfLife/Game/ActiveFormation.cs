using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class ActiveFormation : IActiveFormation
    {
        public IFormation Formation { get; set; }
        public ICell[,] Grid { get; set; }
        public ICellPosition Position { get; set; }
        public Queue<IInstruction> Instructions { get; set; }
        public IToolBox ToolBox { get; set; }

        public ActiveFormation(IFormation formation, ICellPosition formationPosition, IToolBox toolBox)
        {
            this.Formation = formation;

            this.Position = formationPosition;
            this.ToolBox = toolBox;
            this.InitializeInstructions();
        }

        private void InitializeInstructions()
        {
            this.Instructions = new Queue<IInstruction>();
            this.Instructions = this.ToolBox.CreateInstructions(Formation.Instructions, this.Grid, this.Position);
        }

        public bool PrintFormation(ICell[,] grid)
        {
            this.Grid = grid;
            IInstruction temp;
            int count = this.Instructions.Count;

            for (int i = 0; i < count; i++)
            {
                temp = this.Instructions.Dequeue();
                temp.Grid = this.Grid;
                temp.Execute();
            }
                



            return true;
        }
    }
}
