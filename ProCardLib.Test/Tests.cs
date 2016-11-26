using System;
using Xunit;
using ProCardLib.DataModel;
using ProCardLib.Logic.Decks;

namespace ProCardLibTest
{
    public class Tests
    {
        [Fact]       
        public void CreateDeck() 
        {
            var myDeck = new Deck(23,new DeckOptions(52));
            var myDeckManager = new DeckManager();           
            myDeckManager.Fill(myDeck);
            myDeckManager.Append(myDeck,new Card(Ranks.Joker1,Suits.None,Orientations.FaceUp,myDeck));
            myDeckManager.Append(myDeck,new Card(Ranks.Joker2,Suits.None,Orientations.FaceUp,myDeck));
            myDeckManager.Append(myDeck,new Card(Ranks.Joker3,Suits.None,Orientations.FaceUp,myDeck));

            foreach (var card in myDeck)
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine(myDeck.Count);
        }
    }
}
