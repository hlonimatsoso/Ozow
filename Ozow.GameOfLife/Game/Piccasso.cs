using Microsoft.Extensions.Options;
using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class Piccasso : IGameUiDrawer
    {
        public string AliveSymbol { get { return this._gameSettings.Value.AliveSymbol; } }
        public string DeadSymbol { get { return this._gameSettings.Value.DeadSymbol; } }
        public string WallSymbol { get { return this._gameSettings.Value.WallSymbol; } }
        public string ExplosionSymbol { get { return this._gameSettings.Value.ExplosionSymbol; } }


        public IOptions<GameSettings> _gameSettings { get; set; }

        public IToolBox _toolBox { get; set; }

        public Piccasso(IOptions<GameSettings> setings, IToolBox toolBox)
        {
            this._gameSettings = setings;
            this._toolBox = toolBox;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Refresh(ICell[,] latestGeneration)
        {
            this.Clear();
            ICell cell;

            for (int row = 0; row < this._gameSettings.Value.BoardHeight; row++)
            {
                for (int col = 0; col < this._gameSettings.Value.BoardWidth; col++)
                {
                    cell = latestGeneration[row, col];

                    if (this._toolBox.IsCellWall((byte)row, (byte)col))
                    {
                        Console.Write(this.WallSymbol);
                    }
                    else
                    {
                        if (cell.State == CellState.Alive)
                            Console.Write(this.AliveSymbol);
                        else
                            Console.Write(this.DeadSymbol);
                    }

                }
                Console.WriteLine();
            }

            //foreach (ICell cell in latestGeneration)
            //{
            //    if (cell.State == CellState.Alive)
            //        Console.Write(this.AliveSymbol);
            //    else
            //        Console.Write(this.DeadSymbol);

            //}

        }
    }
}
