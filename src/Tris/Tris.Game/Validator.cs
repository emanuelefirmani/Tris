using System;

namespace Tris.Game
{
    public class Validator
    {
        public bool Validate(string[] strings)
        {
            if(strings.Length != 9)
                throw new Exception("Only arrays with 9 elements are allowed");

            var value = strings[0];
            var value2 = strings[1];
            var value3 = strings[2];

            if (DoMatch(value, value2, value3)) return true;

            value = strings[3];
            value2 = strings[4];
            value3 = strings[5];

            if (DoMatch(value, value2, value3)) return true;

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