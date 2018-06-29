﻿using RJ.Core;

namespace BobTheBot.Entities
{
    public class SearchKey : Entity<int>
    {
        private SearchKey()
        {
        }

        protected SearchKey(int id) : base(id)
        {
        }

        public SearchKey(string word)
        {
            Word = word;
        }

        public string Word { get; set; }
    }
}
