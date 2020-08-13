using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ozow.Sorting
{
    public class AlphabetMachine : IAlphabetMachine
    {
        public Dictionary<double, Alphabet> List { get; set; }


        public AlphabetMachine()
        {
            this.List = new Dictionary<double, Alphabet>();
        }

        public AlphabetMachine(string startString):this()
        {
            foreach (char item in startString)
            {
                this.AddAlphabet(new Alphabet(item));
            }
        }



        public void AddAlphabet(Alphabet alphabet)
        {
            if (this.List.ContainsKey(alphabet.Position))
                this.List.First(x => x.Key == alphabet.Position).Value.Count++;
            else
                if (alphabet.IsAValidCharacter)
                this.List.Add(alphabet.Position, alphabet);

        }

        public Alphabet CreateAlphabet(char charcter)
        {
            Alphabet result = new Alphabet(charcter);

            return result;
        }


        public string GetOutPutString()
        {
            string result = string.Empty;
            List<Alphabet> resultList = new List<Alphabet>();

            foreach (var letter in List)
            {
                if (result.Length == 0)
                {
                    result = new string(letter.Value.Letter, letter.Value.Count);
                    continue;
                }

                // Rebuild output string with letter
                result = this.UpdateOutput(result, letter);

            }

            return result;
        }

        private string UpdateOutput(string result, KeyValuePair<double, Alphabet> letter)
        {
            int charIndex;
            string response = string.Empty;

            foreach (char @char in result)
            {
                charIndex = result.IndexOf(@char);

                // If letter value is less or equal than current character, add to left of character
                if (letter.Key <= @char)
                {
                    response = result.Insert(charIndex, new string(letter.Value.Letter, letter.Value.Count));
                    return response;
                }// else if its the last character or character doesn't exist in the output string, add to end of string
                else if (charIndex == result.Length - 1 || charIndex == 0)
                {
                    response = $"{result}{new string(letter.Value.Letter, letter.Value.Count)}";
                }

            }

            return response;
        }
    }
}
