using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMaster
{
    public class StringCalculator
    {
        #region Member fields

        private readonly List<int> _negatives = new List<int>();

        private char[] _delims;
        private string _input;
        private string[] _lines;

        #endregion

        public int Add(string input)
        {
            _input = input;
            _lines = GetLines();

            SetDelims();

            int result = 0;

            foreach (string stringNumber in _lines.Select(line => line.Split(_delims))
                .SelectMany(numbers => numbers))
            {
                int parsedString;
                int.TryParse(stringNumber, out parsedString);

                if (IsNegative(parsedString))
                {
                    _negatives.Add(parsedString);
                }

                if (IsGreaterThenThousand(parsedString))
                {
                    continue;
                }

                result += parsedString;
            }

            if (_negatives.Any())
            {
                throw new NegativesNumberException(String.Format("Negatives not allowed: {0}", _negatives));
            }

            return result;
        }

        private string[] GetLines()
        {
            return _input.Split('\n');
        }

        private bool IsGreaterThenThousand(int parsedString)
        {
            return parsedString > 1000;
        }

        private bool IsNegative(int parsedString)
        {
            return parsedString < 0;
        }

        private void SetDelims()
        {
            if (_input.StartsWith("//"))
            {
                _delims = _lines.First()
                    .Substring(2)
                    .ToCharArray();
                _lines = _lines.Skip(1)
                    .ToArray();
            }
            else
            {
                _delims = new[] {','};
            }
        }
    }
}