using Microsoft.Extensions.Options;
using Ozow.GameOfLife.Game.Instructions;
using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class ToolBox : IToolBox
    {
        private IOptions<GameSettings> _gameSettings;

        public Random Random { get; set; }
        public Queue<byte> RandomRowCoordinates { get; set; }
        public Queue<byte> RandomColomnCoordinates { get; set; }

        public ToolBox(IOptions<GameSettings> settings)
        {
            this._gameSettings = settings;
            this.SetRandomRowsAndColumns();
        }

        private void SetRandomRowsAndColumns()
        {
            byte temp;
            this.Random = new Random(0);
            this.RandomRowCoordinates = new Queue<byte>();
            this.RandomColomnCoordinates = new Queue<byte>();

            for (byte row = 0; row < this._gameSettings.Value.Formations.Length; row++)
            {
                temp = (byte)(this.Random.Next(this._gameSettings.Value.GameMatrixFormationHeightMargin, this._gameSettings.Value.BoardHeight - this._gameSettings.Value.GameMatrixFormationHeightMargin));
                this.RandomRowCoordinates.Enqueue(temp);
            }

            for (byte col = 0; col < this._gameSettings.Value.Formations.Length; col++)
            {
                temp = (byte)(this.Random.Next(this._gameSettings.Value.GameMatrixFormationHeightMargin, this._gameSettings.Value.BoardWidth - this._gameSettings.Value.GameMatrixFormationWidthMargin));
                this.RandomColomnCoordinates.Enqueue(temp);
            }
        }

        public List<ICellPosition> GetAllNeighbourgs(byte row, byte col)
        {
            return GetAllNeighbourgs(new CellPosition(row, col));
        }
        public List<ICellPosition> GetAllNeighbourgs(ICellPosition position)
        {
            List<ICellPosition> result = new List<ICellPosition>();
            List<ICellPosition> x = this.Get_X_Neighbourgs(position);
            List<ICellPosition> y = this.Get_Y_Neighbourgs(position);
            List<ICellPosition> cross = this.Get_CrossSection_Neighbourgs(position);

            result.AddRange(x);
            result.AddRange(y);
            result.AddRange(cross);

            return result;
        }


        public List<ICellPosition> Get_X_Neighbourgs(ICellPosition position)
        {
            List<ICellPosition> result = new List<ICellPosition>();

            // Get X neighboughs
            if (position.Column == 0) // No Left neighbour
                result.Add(new CellPosition((byte)(position.Row), (byte)(position.Column + 1)));
            else if (position.Column == _gameSettings.Value.BoardWidth - 1) // No right neighbour
                result.Add(new CellPosition((byte)(position.Row), (byte)(position.Column - 1)));
            else // Both left & right neighbours apply
            {
                result.Add(new CellPosition((byte)(position.Row), (byte)(position.Column + 1)));
                result.Add(new CellPosition((byte)(position.Row), (byte)(position.Column - 1)));
            }

            return result;

        }

        public List<ICellPosition> Get_Y_Neighbourgs(ICellPosition position)
        {
            List<ICellPosition> result = new List<ICellPosition>();

            // Get Y neighboughs
            if (position.Row == 0) // // No top neighbour
                result.Add(new CellPosition((byte)(position.Row + 1), position.Column));
            else if (position.Row == _gameSettings.Value.BoardHeight - 1) // No bottom neighbour
                result.Add(new CellPosition((byte)(position.Row - 1), position.Column));
            else // Both top & bottom neighbours apply
            {
                result.Add(new CellPosition((byte)(position.Row + 1), position.Column));
                result.Add(new CellPosition((byte)(position.Row - 1), position.Column));
            }

            return result;

        }


        public List<ICellPosition> Get_CrossSection_Neighbourgs(ICellPosition position)
        {
            List<ICellPosition> result = new List<ICellPosition>();

            // Top left
            if (position.Row - 1 >= 0 &&
                position.Column - 1 >= 0)
                result.Add(new CellPosition((byte)(position.Row - 1), (byte)(position.Column - 1)));


            // Top right
            if (position.Row - 1 >= 0 &&
                position.Column + 1 <= this._gameSettings.Value.BoardWidth - 1)
                result.Add(new CellPosition((byte)(position.Row - 1), (byte)(position.Column + 1)));

            // Bottom left
            if (position.Row + 1 <= this._gameSettings.Value.BoardHeight - 1 &&
                position.Column - 1 >= 0)
                result.Add(new CellPosition((byte)(position.Row + 1), (byte)(position.Column - 1)));

            // Bottom right
            if (position.Row + 1 <= this._gameSettings.Value.BoardHeight - 1 &&
                position.Column + 1 <= this._gameSettings.Value.BoardWidth - 1)
                result.Add(new CellPosition((byte)(position.Row + 1), (byte)(position.Column + 1)));

            return result;

        }


        public bool IsCellWall(ICellPosition position)
        {
            bool result = false;

            if (position.Row == 0 || position.Row == _gameSettings.Value.BoardHeight)
                result = true;
            else if (position.Column == 0 || position.Column == _gameSettings.Value.BoardWidth)
                result = true;

            return result;
        }

        public int GenerateRandomNumber(int min, int max)
        {
            int result;

            result = this.Random.Next(min, max);

            return result;
        }

        public ICellPosition GetRandomCellPosition()
        {
            //int rowMax = this._gameSettings.Value.BoardHeight;
            //int colMax = this._gameSettings.Value.BoardWidth;

            //int row = this.GenerateRandomNumber(0, rowMax);
            //int col = this.GenerateRandomNumber(0, colMax);

            ICellPosition result = new CellPosition(this.RandomRowCoordinates.Dequeue(), this.RandomColomnCoordinates.Dequeue());
            return result;
        }

        public Queue<IInstruction> CreateInstructions(string instructionString, ICell[,] grid, ICellPosition position)
        {
            Queue<IInstruction> result = new Queue<IInstruction>();
            IInstruction tempInstruction = null;

            var set = instructionString.Split(' ');

            foreach (string instruction in set)
            {
                switch (instruction)
                {
                    case "x":
                        tempInstruction = new Live(grid, position);
                        break;
                    case "up":
                        tempInstruction = new Up(grid, position);
                        break;
                    case "down":
                        tempInstruction = new Down(grid, position);
                        break;
                    default:
                    case "left":
                        tempInstruction = new Left(grid, position);
                        break;
                    case "right":
                        tempInstruction = new Right(grid, position);
                        break;
                }

                result.Enqueue(tempInstruction);
            }

            return result;
        }

        public bool IsCellWall(byte row, byte col)
        {
            bool result = false;

            if (row == 0 || row == _gameSettings.Value.BoardHeight - 1)
                result = true;
            else if (col == 0 || col == _gameSettings.Value.BoardWidth - 1)
                result = true;

            return result;
        }
    }
}
