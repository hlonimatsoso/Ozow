using Microsoft.Extensions.Options;
using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class GameBoard : IGameBoard
    {
        public IGameUiDrawer Drawer { get; set; }
        public IMatrix Matrix { get; set; }
        public List<IInstruction> Instructions { get; set; }
        public List<IActiveFormation> ActiveFormations { get; set; }

        private IOptions<GameSettings> _gameSettings;

        private IToolBox _toolBox;

        public GameBoard(IGameUiDrawer drawer, IMatrix matrix, IOptions<GameSettings> settings, IToolBox toolBox)
        {
            this.Drawer = drawer;
            this.Matrix = matrix;
            this._gameSettings = settings;
            this._toolBox = toolBox;
            
        }

        public void OnRefresh()
        {
            this.Matrix.GenerateNextGeneration();
            this.Drawer.Refresh(this.Matrix.TheNextGenerationGrid);
        }

        public void OnGameStart()
        {
            this.Drawer.Refresh(this.Matrix.TheGrid);
        }

        public void OnGameEnd()
        {
         //   this.Drawer.Refresh(this.Matrix.TheGrid);
        }

        public void OnInitialize()
        {
            this.Matrix.Initialize();
            this.InitializeActiveFormations();
            this.InitializeBoard();
        }

        private void InitializeBoard()
        {
            foreach (IActiveFormation formation in this.ActiveFormations)
                formation.PrintFormation(this.Matrix.TheGrid);

            this.Drawer.Refresh(this.Matrix.TheGrid);

        }

        private void InitializeActiveFormations()
        {
            this.ActiveFormations = new List<IActiveFormation>();
            ICellPosition randomPosition;
            IActiveFormation tempFormation;

            foreach (IFormation formation in this._gameSettings.Value.Formations)
            {
                if (!formation.IsActive)
                    continue;

                randomPosition = this._toolBox.GetRandomCellPosition();
                tempFormation = new ActiveFormation(formation, randomPosition,this._toolBox);
                tempFormation.ToolBox = this._toolBox;
                this.ActiveFormations.Add(tempFormation);
            }

        }
    }
}
