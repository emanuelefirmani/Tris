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

            if (value != null)
            {
                if (string.Equals(value, value2) && string.Equals(value, value3))
                    return true;
            }

            value = strings[3];
            var value4 = strings[4];
            var value5 = strings[5];

            if (value != null)
            {
                if (string.Equals(value, value4) && string.Equals(value, value5))
                    return true;
            }

            return false;
        }
    }
}