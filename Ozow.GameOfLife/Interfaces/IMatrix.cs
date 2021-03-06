﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IMatrix
    {
        public ICell[,] TheGrid { get; set; }

        public ICell[,] TheNextGenerationGrid { get; set; }

        public IToolBox ToolBox { get; set; }


        public void GenerateNextGeneration();

        public void GenerateDefaultGeneration();

        public void Initialize();
    }
}
