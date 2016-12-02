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

            var dealerDeck = new Deck( "Dealer", new DeckOptions(52));
            var dealerDeckManager = new DeckManager();           
            dealerDeckManager.Fill(dealerDeck);

            var myDeck = new Deck("Me", new DeckOptions(5));
            var myDeckManager = new DeckManager();           

            Helpers.Shuffle(dealerDeck);


            foreach (var card in dealerDeck)
            {
                Console.WriteLine(card.ToString());
            }            
        }
    }
}
