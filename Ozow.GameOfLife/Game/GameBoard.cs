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

        private IGameEngine _engine;

        private GameSettings _gameSettings;

        private IToolBox _toolBox;

        public GameBoard(IGameUiDrawer drawer, IMatrix matrix, IGameEngine engine, GameSettings settings, IToolBox toolBox)
        {
            this.Drawer = drawer;
            this.Matrix = matrix;
            this._engine = engine;
            this._gameSettings = settings;
            this._toolBox = toolBox;

            this._engine.OnInitialize += OnGameEngineInitialize;

            this._engine.OnGameStart += OnGameEngineStart;

            this._engine.OnRefresh += OnRefresh;
        }

        private void OnRefresh()
        {
            this.Matrix.GenerateNextGeneration();
            this.Drawer.Refresh(this.Matrix.TheGrid);
        }

        private void OnGameEngineStart()
        {
            this.Drawer.Refresh(this.Matrix.TheGrid);
        }

        private void OnGameEngineInitialize()
        {
            this.Matrix.Initialize();
            this.InitializeActiveFormations();
            this.InitializeBoard();
        }

        private void InitializeBoard()
        {
            foreach (IActiveFormation formation in this.ActiveFormations)
                formation.PrintFormation();

            this.Drawer.Refresh(this.Matrix.TheGrid);

        }

        private void InitializeActiveFormations()
        {
            this.ActiveFormations = new List<IActiveFormation>();
            ICellPosition randomPosition;
            IActiveFormation tempFormation;

            foreach (IFormation formation in this._gameSettings.Formations)
            {
                randomPosition = this._toolBox.GetRandomCellPosition();
                tempFormation = new ActiveFormation(formation, this.Matrix.TheGrid, randomPosition);
                this.ActiveFormations.Add(tempFormation);
            }

        }
    }
}
