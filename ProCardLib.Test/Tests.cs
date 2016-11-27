using System;
using Xunit;
using ProCardLib.DataModel;
using ProCardLib.Logic.Decks;
using ProCardLib.Logic;

namespace ProCardLibTest
{
    public class Tests
    {
        [Fact]       
        public void CreateDeck() 
        {

            var dealerDeck = new Deck(23,new DeckOptions(52), "Dealer");
            var dealerDeckManager = new DeckManager();           
            dealerDeckManager.Fill(dealerDeck);
            dealerDeckManager.Append(dealerDeck,new Card(Ranks.Joker1,Suits.None,Orientations.FaceUp,dealerDeck));
            dealerDeckManager.Append(dealerDeck,new Card(Ranks.Joker2,Suits.None,Orientations.FaceUp,dealerDeck));
            dealerDeckManager.Append(dealerDeck,new Card(Ranks.Joker3,Suits.None,Orientations.FaceUp,dealerDeck));

            Helpers.Shuffle(dealerDeck);

            foreach (var card in dealerDeck)
            {
                Console.WriteLine(card.ToString());
            }

            
            Console.WriteLine(dealerDeck.Count);
            
            
            
        }
    }
}
