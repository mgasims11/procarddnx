﻿using System;
using ProCardLib.DataModel;
using ProCardLib.Logic;
namespace ProCardLib.Engines
{
    public class HighCardWins
    {
        public Table Table {get;set;}
        public TableManager TableManager {get;set;}
        public Deck DealerDeck {get;set;}
        public Deck DealerHand {get;set;}
        public Deck PlayerHand;
        private DeckOptions DealerDeckOptions;
        private DeckOptions HandDeckOptions;
      
        public void Initialize()
        {
            this.DealerDeckOptions = new DeckOptions(52) { CardDisplayFormat = Card.Formats.ConciseLetter };
            this.HandDeckOptions = new DeckOptions(1) { CardDisplayFormat = Card.Formats.ConciseLetter };           

            this.DealerDeck = new Deck()
            {
                DeckName = "Dealer Deck",
                Options = DealerDeckOptions
            };

            this.DealerHand = new Deck()
            {
                DeckName = "Dealer Hand",
                Options = HandDeckOptions
            };

            this.PlayerHand = new Deck()
            {
                DeckName = "Player Hand",
                Options = HandDeckOptions
            };

            this.Table = new Table() {
                
            };
            
            this.TableManager = new TableManager() {Table = this.Table};
            this.TableManager.OnCardAddedToDeck += this.OnCardAddedToDeck;
            
            TableManager.AddDecksToTable(this.Table, this.DealerDeck,this.DealerHand,this.PlayerHand);
            TableManager.FillDeck(this.DealerDeck);
            TableManager.Shuffle(this.DealerDeck);
        }

        public void Deal()
        {
            TableManager.DealCardToTopOf(this.DealerDeck,0,this.DealerHand);
            TableManager.DealCardToTopOf(this.DealerDeck,0,this.PlayerHand); 
        }

        public void Play() 
        {
            if (this.DealerHand.Cards[0].Rank > this.PlayerHand.Cards[0].Rank)
                Console.WriteLine("Dealer Wins");
                else
                    if (this.DealerHand.Cards[0].Rank < this.PlayerHand.Cards[0].Rank)
                        Console.WriteLine("Player Wins");
                    else
                        Console.WriteLine("Tie!");
        }

        private void OnCardAddedToDeck(object sender, CardEventArgs args)
        {
            
        }
    }        
}
