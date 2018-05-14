namespace Tris.Game
{
    public class Validator
    {
        public bool Validate(string[] strings)
        {
            return string.Equals(strings[0], strings[1]);
        }
    }
}