using System;

namespace Tris.Game
{
    public class Board
    {
        public void AddMark(int position, string mark)
        {
            if(position < 0 || position > 8)
                throw  new Exception($"Invalid position {position}");
            
            if(string.IsNullOrEmpty(mark))
                throw new Exception($"Invalid mark {mark}");
        }
    }
}