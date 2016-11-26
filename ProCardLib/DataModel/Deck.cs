using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class Deck : List<Card>
    {
        public DeckOptions Options {get; set;}

        public Int32 DeckId;

        public Deck(int id, DeckOptions options)
        {
            DeckId = id;    
            Options = options;
        }
    }
}
