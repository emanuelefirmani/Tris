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

            if (value != null)
            {
                if (string.Equals(value, strings[1]) && string.Equals(value, strings[2]))
                    return true;
            }

            value = strings[3];

            if (value != null)
            {
                if (string.Equals(value, strings[4]) && string.Equals(value, strings[5]))
                    return true;
            }

            return false;
        }
    }
}