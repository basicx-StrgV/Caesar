using System;
using System.Collections;
using System.Collections.Generic;

namespace Caesar
{
    public class CaesarCharset : IReadOnlyList<char>
    {
        public static CaesarCharset GermanKeyboard 
        { 
            get 
            { 
                return new CaesarCharset(
                    "|´`^°=<>ABCDEFGHIJKLMNOPQRSTUVWXYZ\"§$%&/ÄÖÜß !?.:,;@€1234567890-_+*~#'µabcdefghijklmnopqrstuvwxyz({[}])äöü");
            } 
        }

        public int StepValue { get { return _stepValue; } }

        public int RunCount { get { return _runCount; } }

        public char this[int index]
        {
            get
            {
                return _charSet[CalculateIndex(index)];
            }
        }

        public int Count
        {
            get
            {
                return _charSet.Length;
            }
        }

        private readonly char[] _charSet;
        private readonly int _stepValue = 50000;
        private readonly int _runCount = 3;

        public CaesarCharset(string charSet, int stepValue, int runCount)
        {
            _charSet = charSet.ToCharArray();
            _stepValue = stepValue;
            _runCount = runCount;
        }

        public CaesarCharset(string charSet)
        {
            _charSet = charSet.ToCharArray();
        }

        public CaesarCharset(char[] charSet, int stepValue, int runCount)
        {
            _charSet = charSet;
            _stepValue = stepValue;
            _runCount = runCount;
        }

        public CaesarCharset(char[] charSet)
        {
            _charSet = charSet;
        }

        public int IndexOf(char value)
        {
            return Array.IndexOf(_charSet, value);
        }

        private int CalculateIndex(int input)
        {
            int maxIndex = _charSet.Length - 1;
            int returnIndex = input;

            //Calculate negative index
            while (returnIndex < 0)
            {
                returnIndex = maxIndex + returnIndex;
            }

            //Calculate positive index
            while (returnIndex > maxIndex)
            {
                returnIndex = returnIndex - maxIndex;
            }

            return returnIndex;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return (IEnumerator<char>)_charSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _charSet.GetEnumerator();
        }
    }
}
