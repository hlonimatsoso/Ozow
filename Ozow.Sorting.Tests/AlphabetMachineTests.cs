using System;
using System.Collections.Generic;
using Xunit;

namespace Ozow.Sorting.Tests
{
    public class AlphabetMachineTests
    {

        private IAlphabetMachine _machine;

        public AlphabetMachineTests()
        {
            this._machine = new AlphabetMachine();
        }

        [Fact]
        public void CreateAlphabet_ValidCharacter()
        {
            char @char = 'a';
            Alphabet alphabet = this._machine.CreateAlphabet(@char);

            Assert.True(alphabet.IsAValidCharacter, $"'{@char}' is  a valid character");
        }

        [Fact]
        public void CreateAlphabet_InvalidCharacter()
        {
            char @char = '!';
            Alphabet alphabet = this._machine.CreateAlphabet(@char);

            Assert.False(alphabet.IsAValidCharacter, $"'{@char}' is  an INvalid character");
        }

        [Fact]
        public void AddAlphabet_New()
        {
            Alphabet a = new Alphabet('a');

            IAlphabetMachine machine = new AlphabetMachine();

            Assert.Empty(machine.List);

            machine.AddAlphabet(a);

            Assert.NotEmpty(machine.List);

            Assert.Equal(1, machine.List[a.Position].Count);
        }

        [Fact]
        public void AddAlphabet_DuplicateTwice_CountIs3()
        {
            Alphabet a = new Alphabet('a');

            Dictionary<double, Alphabet> list = new Dictionary<double, Alphabet>();

            IAlphabetMachine machine = new AlphabetMachine();

            Assert.Empty(machine.List);


            machine.AddAlphabet(a);
            machine.AddAlphabet(a);
            machine.AddAlphabet(a);


            Assert.NotEmpty(machine.List);

            Assert.Equal(3, machine.List[a.Position].Count);

        }

        [Fact]
        public void GetOutPutString_AddRandomly_DisplayInOrder()
        {
            string expected = "abcde";

            IAlphabetMachine machine = new AlphabetMachine();

            machine.AddAlphabet(new Alphabet('b'));
            machine.AddAlphabet(new Alphabet('c'));
            machine.AddAlphabet(new Alphabet('d'));
            machine.AddAlphabet(new Alphabet('e'));
            machine.AddAlphabet(new Alphabet('a'));


            string actual = machine.GetOutPutString();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetOutPutString_Add_AtTheBegining()
        {
            Dictionary<double, Alphabet> list = new Dictionary<double, Alphabet>();

            string input = "fed";
            string expectedInitial = "def";


            IAlphabetMachine machine = new AlphabetMachine(input);

            Assert.Equal(expectedInitial, machine.GetOutPutString());

            // now add ab&c

            string expected = "abcdef";

            machine.AddAlphabet(new Alphabet('c'));
            machine.AddAlphabet(new Alphabet('a'));
            machine.AddAlphabet(new Alphabet('b'));


            string actual = machine.GetOutPutString();

            Assert.Equal(expected, actual);

        }


        [Fact]
        public void GetOutPutString_Add_InTheMiddle()
        {
            Dictionary<double, Alphabet> list = new Dictionary<double, Alphabet>();

            string input = "zx";
            string expectedInitial = "xz";


            IAlphabetMachine machine = new AlphabetMachine(input);

            Assert.Equal(expectedInitial, machine.GetOutPutString());

            // now add ab&c

            string expected = "xyz";

            machine.AddAlphabet(new Alphabet('y'));


            string actual = machine.GetOutPutString();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetOutPutString_Add_ToTheEnd()
        {
            Dictionary<double, Alphabet> list = new Dictionary<double, Alphabet>();

            string input = "xy";
            string expectedInitial = "xy";


            IAlphabetMachine machine = new AlphabetMachine(input);

            Assert.Equal(expectedInitial, machine.GetOutPutString());

            // now add ab&c

            string expected = "xyz";

            machine.AddAlphabet(new Alphabet('z'));


            string actual = machine.GetOutPutString();

            Assert.Equal(expected, actual);

        }
    }
}
