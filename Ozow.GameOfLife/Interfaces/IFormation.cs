using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Interfaces
{
    public interface IFormation
    {
        public string Name { get; set; }

        public byte ID { get; set; }

        public bool IsActive { get; set; }

        public byte Width { get; set; }

        public string Instructions { get; set; }

    }
}
