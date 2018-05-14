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
            
            if (value == null)
                return false;
            
            return string.Equals(value, strings[1]) && string.Equals(value, strings[2]);
        }
    }
}