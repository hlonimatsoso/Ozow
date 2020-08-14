using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class Piccasso : IGameUiDrawer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Refresh(ICell[,] latestGeneration)
        {
            this.Clear();

        }
    }
}
