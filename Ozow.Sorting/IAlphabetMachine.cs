using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.Sorting
{
    public interface IAlphabetMachine
    {

        string GetOutPutString();

        Dictionary<double, Alphabet> List { get; set; }
        Alphabet CreateAlphabet(char chaarcter);

        void AddAlphabet(Alphabet alphabet);

    }
}
