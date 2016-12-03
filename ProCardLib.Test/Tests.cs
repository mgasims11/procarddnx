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

            var dealerDeckOptions = new DeckOptions(52);
            dealerDeckOptions.CardDisplayFormat = Card.Formats.ConciseLetter;
            var dealerDeck = new Deck( "Dealer",dealerDeckOptions );

            var dealerDeckManager = new DeckManager();           
            dealerDeckManager.Fill(dealerDeck);

            var myDeck = new Deck("Me", new DeckOptions(5));
            var myDeckManager = new DeckManager();           

            Helpers.Shuffle(dealerDeck);

            Console.WriteLine(dealerDeck.ToString());
            // foreach (var card in dealerDeck)
            // {
            //     Console.WriteLine(card.ToString(Card.Formats.Long));
            // }            
        }
    }
}
