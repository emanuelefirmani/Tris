using System;

namespace Tris.Game
{
    public class Validator
    {
        public bool Validate(string[] strings)
        {
            if(strings.Length != 9)
                throw new Exception("Only arrays with 9 elements are allowed");
            
            return string.Equals(strings[0], strings[1]);
        }
    }
}