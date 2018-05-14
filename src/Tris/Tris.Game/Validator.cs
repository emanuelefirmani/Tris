using System;

namespace Tris.Game
{
    public class Validator
    {
        public bool Validate(string[] strings)
        {
            if(strings.Length != 9)
                throw new Exception("Only arrays with 9 elements are allowed");

            if (DoMatch(strings[0], strings[1], strings[2])) return true;
            if (DoMatch(strings[3], strings[4], strings[5])) return true;
            if (DoMatch(strings[6], strings[7], strings[8])) return true;
            if (DoMatch(strings[0], strings[3], strings[6])) return true;

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