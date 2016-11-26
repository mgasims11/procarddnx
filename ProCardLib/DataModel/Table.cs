using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class Table
    {
        public List<Deck> Decks { get; set; }

        public Table()
        {
            Decks = new List<Deck>();
        }
    }
}
