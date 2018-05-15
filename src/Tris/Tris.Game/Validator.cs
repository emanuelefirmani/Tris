using System;
using System.Collections.Generic;

namespace Tris.Game
{
    public interface IValidator
    {
        bool Validate(string[] strings);
    }

    public class Validator : IValidator
    {
        private readonly List<Tuple<int, int, int>> _winningCombinations;

        public Validator()
        {
            _winningCombinations = new List<Tuple<int, int, int>>();
            _winningCombinations.Add(new Tuple<int, int, int>(0, 1, 2));
            _winningCombinations.Add(new Tuple<int, int, int>(3, 4, 5));
            _winningCombinations.Add(new Tuple<int, int, int>(6, 7, 8));
            _winningCombinations.Add(new Tuple<int, int, int>(0, 3, 6));
            _winningCombinations.Add(new Tuple<int, int, int>(1, 4, 7));
            _winningCombinations.Add(new Tuple<int, int, int>(2, 5, 8));
            _winningCombinations.Add(new Tuple<int, int, int>(0, 4, 8));
            _winningCombinations.Add(new Tuple<int, int, int>(2, 4, 6));
        }

        public bool Validate(string[] strings)
        {
            if(strings.Length != 9)
                throw new Exception("Only arrays with 9 elements are allowed");

            foreach (var tuple in _winningCombinations)
            {
                if (DoMatch(strings[tuple.Item1], strings[tuple.Item2], strings[tuple.Item3])) return true;
            }

            return false;
        }

        private static bool DoMatch(string value, string value2, string value3)
        {
            if (value != null)
            {
                if (string.Equals(value, value2) && string.Equals(value, value3))
                    return true;
            }

            return false;
        }
    }
}