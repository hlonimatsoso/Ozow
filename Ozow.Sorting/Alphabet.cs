using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.Sorting
{
    public class Alphabet
    {

        public Alphabet(char @char)
        {
            this.Letter = @char;

            
            if (Char.IsLetter(@char))
                this.IsAValidCharacter = true;


            this.Position = @char;

            this.Count = 1;
        }

        public char Letter { get; set; }

        public double Position { get; set; }

        public bool IsAValidCharacter { get; set; }

        public int Count { get; set; }

    }
}
