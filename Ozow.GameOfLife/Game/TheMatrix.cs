using Microsoft.Extensions.Options;
using Ozow.GameOfLife.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class TheMatrix : IMatrix
    {
        IOptions<GameSettings> _gamesttings;
        public ICell[,] TheGrid { get; set; }
        public IToolBox ToolBox { get; set; }
        public ICell[,] TheNextGenerationGrid { get; set; }

        public TheMatrix(IOptions<GameSettings> settings, IToolBox toolBox)
        {
            this._gamesttings = settings;
            this.TheGrid = new ICell[this._gamesttings.Value.BoardHeight, this._gamesttings.Value.BoardWidth];
            this.TheNextGenerationGrid = new ICell[this._gamesttings.Value.BoardHeight, this._gamesttings.Value.BoardWidth];

            this.ToolBox = toolBox;
        }


        public void GenerateDefaultGeneration()
        {
            ICell tempCell;

            for (int row = 0; row < this._gamesttings.Value.BoardHeight; row++)
            {
                for (int col = 0; col < this._gamesttings.Value.BoardWidth; col++)
                {
                    tempCell = new Cell(CellState.Dead);
                    this.TheGrid[row, col] = tempCell;
                }
            }

        }

        public void GenerateNextGeneration()
        {
            List<ICellPosition> neighbours;
            List<ICellPosition> aliveNeighbours;


            for (byte row = 0; row < this._gamesttings.Value.BoardHeight; row++)
            {
                for (byte col = 0; col < this._gamesttings.Value.BoardWidth; col++)
                {
                    neighbours = this.ToolBox.GetAllNeighbourgs(row, col);
                    aliveNeighbours = new List<ICellPosition>();

                    foreach (ICellPosition position in neighbours)
                    {
                        if (this.TheGrid[position.Row, position.Column].State == CellState.Alive)
                            aliveNeighbours.Add(position);
                    }



                    if (this.TheGrid[row, col].State == CellState.Alive)
                    {
                        if (aliveNeighbours.Count <= this._gamesttings.Value.LowKillCount || aliveNeighbours.Count >= this._gamesttings.Value.HighKillCount)
                            this.TheNextGenerationGrid[row, col] = new Cell(CellState.Dead);
                        else
                            this.TheNextGenerationGrid[row, col] = new Cell(CellState.Alive);
                    }
                    else
                    {
                        if (aliveNeighbours.Count == this._gamesttings.Value.ResserectionCount)
                            this.TheNextGenerationGrid[row, col] = new Cell(CellState.Alive);
                        else
                            this.TheNextGenerationGrid[row, col] = new Cell(CellState.Dead);
                    }




                }
            }


            for (byte row = 0; row < this._gamesttings.Value.BoardHeight; row++)
                for (byte col = 0; col < this._gamesttings.Value.BoardWidth; col++)
                    this.TheGrid[row, col] = this.TheNextGenerationGrid[row, col];

        }


        public void Initialize()
        {
            this.GenerateDefaultGeneration();
        }
    }
}
