using Ozow.GameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Game
{
    public class Formation:IFormation
    {
        public string Name { get; set; }
        public byte ID { get; set; }
        public byte Width { get; set; }
        public string Instructions { get; set; }
        public bool IsActive { get ; set ; }
    }
}
