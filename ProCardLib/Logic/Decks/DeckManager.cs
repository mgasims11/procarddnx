using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProCardLib.DataModel;

namespace ProCardLib.Logic.Decks
{
    public class DeckManager
    {              
        public void Fill(Deck deck)
        {
            for(var suit = 1; suit <= 4 && deck.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Count < deck.Options.MaxCards; rank++)
                {
                    deck.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck));                    
                }
            }
        }
        
        public void Append(Deck deck, Card card) 
        {
            deck.Add(card);
        }

        public void Shuffle(Deck deck)
        {            
            for (var i = 0; i <= deck.Count - 1; i++)
            {
                var randomCard = Helpers.GetRandomCardIndex(deck);
                Helpers.SwapCards(deck, i, randomCard);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
