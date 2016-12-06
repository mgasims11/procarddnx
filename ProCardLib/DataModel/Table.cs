using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ProCardLib.DataModel
{
    public class Table
    {
        public List<Deck> Decks { get; set; }

        public Table(params Deck[] decks)
        {
            Decks = decks.ToList<Deck>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var deck in Decks)
            {
                sb.AppendLine(deck.ToString());
            }
            return sb.ToString();
        }
    }
}
