using System;

namespace Tris.Game
{
    public class Validator
    {
        public bool Validate(string[] strings)
        {
            if(strings.Length != 9)
                throw new Exception("Only arrays with 9 elements are allowed");

            if (strings[0] == null || strings[1] == null)
                return false;
            
            return string.Equals(strings[0], strings[1]);
        }
    }
}