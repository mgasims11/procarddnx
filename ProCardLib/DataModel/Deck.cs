using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections.ObjectModel;

namespace ProCardLib.DataModel
{
    public class Deck : ObservableCollection<Card>
    {
        public string Name {get;set;}

        public DeckOptions Options {get; set;}

        public Int32 DeckId;

        public Deck(string name,DeckOptions options)
        {            
            Name = name;
            Options = options;         
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(": ");

            foreach(var card in this)
            {
                sb.Append(card.ToString(Options.CardDisplayFormat));
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
