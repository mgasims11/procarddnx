using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class Card
    {
        public Ranks Rank { get; set; }
        public Suits Suit { get; set; }
        public Orientations Orientation { get; set; }
        public Int32 OriginatingDeckId { get; set; }

        public Card(Ranks rank, Suits suit, Orientations orientation, Deck deck)
        {
            Rank = rank;
            Suit = suit;
            Orientation = orientation;
            OriginatingDeckId = deck.DeckId;
        }

        public override string ToString()
        {
            return String.Format("[{0} of {1}]", Rank, Suit);              
        }
    }
}
