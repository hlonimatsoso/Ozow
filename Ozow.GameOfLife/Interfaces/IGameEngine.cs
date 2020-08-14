using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IGameEngine
    {
        event Action OnGameStart;

        event Action OnGameEnd;

        event Action OnRefresh;

        event Action OnInitialize;


        Timer timer { get; set; }

        void Initialize();

        void Start();

        void End();

    }
}
