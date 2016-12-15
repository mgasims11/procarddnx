using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class CardBase
    {
        public Orientations Orientation { get; set; }
        public Int32 OriginatingDeckId { get; set; }
        public string DisplayValue { get; set; }
        public int Value {get;set;}
        public CardBase(Orientations orientation, Deck deck, int value)
        {
            Orientation = orientation;
            OriginatingDeckId = deck.DeckId;
            Value = value;
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}
