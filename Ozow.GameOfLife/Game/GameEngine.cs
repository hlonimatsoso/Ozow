using Microsoft.Extensions.Options;
using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Ozow.GameOfLife.Game
{
    public class GameEngine : IGameEngine
    {
        public IOptions<GameSettings> GameSetings { get; set; }
        public Timer timer { get; set; }
        public IGameBoard GameBoard { get; set; }

        public event Action OnRefresh;
        public event Action OnGameStart;
        public event Action OnGameEnd;
        public event Action OnInitialize;

        public GameEngine(IGameBoard board, IOptions<GameSettings> settings)
        {
            this.GameBoard = board;
            this.GameSetings = settings;
        }

        public void Initialize()
        {
            this.timer = new Timer(this.GameSetings.Value.GameSpeed);

            this.timer.Elapsed += Refresh;

            this.OnInitialize += this.GameBoard.OnInitialize;
            this.OnRefresh += this.GameBoard.OnRefresh;
            this.OnGameStart += this.GameBoard.OnGameStart;
            this.OnGameEnd += this.GameBoard.OnGameEnd;

            Console.WindowHeight = this.GameSetings.Value.BoardHeight + this.GameSetings.Value.WindowPadding;
            Console.WindowWidth = this.GameSetings.Value.BoardWidth + this.GameSetings.Value.WindowPadding;

            this.OnInitialize?.Invoke();
        }


        private void Refresh(object sender, ElapsedEventArgs e)
        {
            //timer.Stop();
            this.OnRefresh?.Invoke();
            //timer.Start();

        }

        public void Start()
        {
           this.timer.Enabled = true;
            this.OnGameStart?.Invoke();                
        }

        public void End()
        {
            this.OnGameEnd?.Invoke();
        }
    }
}
