using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class Deck : List<Card>
    {
        public string Name {get;set;}

        public DeckOptions Options {get; set;}

        public Int32 DeckId;

        public Deck(string name,DeckOptions options)
        {            
            Name = name;
            Options = options;         
        }
    }
}
