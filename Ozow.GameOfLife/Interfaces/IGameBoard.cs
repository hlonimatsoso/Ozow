using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IGameBoard
    {
        public IGameUiDrawer Drawer { get; set; }

        public IMatrix Matrix { get; set; }

        public List<IActiveFormation> ActiveFormations { get; set; }

        public void OnGameStart();

        public void OnGameEnd();

        public void OnRefresh();

        public void OnInitialize();

    }
}
