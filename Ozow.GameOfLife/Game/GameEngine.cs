using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Ozow.GameOfLife.Game
{
    public class GameEngine : IGameEngine
    {
        public GameSettings GameSetings { get; set; }
        public Timer timer { get; set; }

        private IGameEngine _engine;

        public event Action OnRefresh;
        public event Action OnGameStart;
        public event Action OnGameEnd;
        public event Action OnInitialize;

        public GameEngine(GameSettings settings, IGameEngine engine)
        {
            this.GameSetings = settings;
            this._engine = engine;
            this.Initialize();
        }

        public void Initialize()
        {
            this.timer.Interval = this.GameSetings.GameSpeed;
            this.timer.Elapsed += Refresh;
            this.OnIntialize();
        }

        private void OnIntialize()
        {
            this.OnInitialize();
        }

        private void Refresh(object sender, ElapsedEventArgs e)
        {
            this.OnRefresh?.Invoke();
        }

        public void Start()
        {
            this.timer.Enabled = true;

        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
