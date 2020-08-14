using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class ToolBox : IToolBox
    {
        private GameSettings _gameSettings;
              
        public ToolBox(GameSettings settings)
        {
            this._gameSettings = settings;
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
                result.Add(new CellPosition((byte)(position.Row + 1), position.Column));
            if (position.Column == _gameSettings.BoardWidth) // No right neighbour
                result.Add(new CellPosition((byte)(position.Row - 1), position.Column));
            else // Both left & right neighbours apply
            {
                result.Add(new CellPosition((byte)(position.Row + 1), position.Column));
                result.Add(new CellPosition((byte)(position.Row - 1), position.Column));
            }

            return result;

        }

        public List<ICellPosition> Get_Y_Neighbourgs(ICellPosition position)
        {
            List<ICellPosition> result = new List<ICellPosition>();

            // Get Y neighboughs
            if (position.Row == 0) // // No top neighbour
                result.Add(new CellPosition((byte)(position.Row + 1), position.Column));
            if (position.Column == _gameSettings.BoardHeight) // No bottom neighbour
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
            if (position.Row - 1 >= 0 && position.Column - 1 <= this._gameSettings.BoardWidth)
                result.Add(new CellPosition((byte)(position.Row - 1), (byte)(position.Column - 1)));


            // Top left
            if (position.Row - 1 >= 0 && position.Column + 1 <= this._gameSettings.BoardWidth)
                result.Add(new CellPosition((byte)(position.Row - 1), (byte)(position.Column + 1)));

            // Bottom left
            if (position.Row + 1 <= this._gameSettings.BoardHeight && position.Column - 1 <= this._gameSettings.BoardHeight)
                result.Add(new CellPosition((byte)(position.Row + 1), (byte)(position.Column - 1)));

            // Bottmo right
            if (position.Row + 1 <= this._gameSettings.BoardHeight && position.Column + 1 <= this._gameSettings.BoardHeight)
                result.Add(new CellPosition((byte)(position.Row + 1), (byte)(position.Column + 1)));

            return result;

        }


        public bool IsCellWall(ICellPosition position)
        {
            bool result = false;

            if (position.Row == 0 || position.Row == _gameSettings.BoardHeight)
                result = true;
            else if (position.Column == 0 || position.Column == _gameSettings.BoardWidth)
                result = true;

            return result;
        }

        public int GenerateRandomNumber(int min, int max)
        {
            int result = -1;

            Random random = new Random(min);

            result = random.Next(max);

            return result;
        }

        public ICellPosition GetRandomCellPosition()
        {
            int rowMax = this._gameSettings.BoardHeight;
            int colMax = this._gameSettings.BoardWidth;

            int row = this.GenerateRandomNumber(0, rowMax);
            int col = this.GenerateRandomNumber(0, colMax);

            ICellPosition result = new CellPosition((byte)row, (byte)col);
            return result;
        }
    }
}
