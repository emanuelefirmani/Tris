﻿using System;

namespace Tris.Game
{
    public class Board
    {
        private readonly string[] _marks;

        public Board(IValidator validator)
        {
            _marks = new string[9];
        }

        public bool AddMark(int position, string mark)
        {
            if(position < 0 || position > 8)
                throw  new Exception($"Invalid position {position}");
            
            if(string.IsNullOrEmpty(mark))
                throw new Exception($"Invalid mark {mark}");
            
            if(!string.IsNullOrEmpty(_marks[position]))
                throw new Exception($"Position already used {position}");

            _marks[position] = mark;

            return true;
        }
    }
}