using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
   public interface ICellPosition
    {
        public byte Row { get; set; }
        public byte Column { get; set; }

    }
}
