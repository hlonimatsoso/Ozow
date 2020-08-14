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
        public List<IInstruction> Instructions { get ; set ; }
        public List<IActiveFormation> ActiveFormation { get; set; }

        private IGameEngine _engine;

        private GameSettings _gameSettings;

        public GameBoard(IGameUiDrawer drawer,IMatrix matrix, IGameEngine engine, GameSettings settings)
        {
            this.Drawer = drawer;
            this.Matrix = matrix;
            this._engine = engine;
            this._gameSettings = settings;

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
        }

        private void InitializeActiveFormations()
        {
            throw new NotImplementedException();
        }
    }
}
