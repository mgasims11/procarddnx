using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private DeckOptions HandOptions;
      
        public void Initialize()
        {
            this.DealerDeckOptions = new DeckOptions(52) { CardDisplayFormat = Card.Formats.ConciseLetter };
            this.HandOptions = new DeckOptions(1) { CardDisplayFormat = Card.Formats.ConciseLetter };           

            this.DealerDeck = new Deck("Dealer Deck",DealerDeckOptions);
            this.DealerHand = new Deck("Dealer Hand",HandOptions);
            this.PlayerHand = new Deck("Player Hand",HandOptions);

            this.Table = new Table();
            
            this.TableManager = new TableManager() {Table = this.Table};

            TableManager.AddDecksToTable(this.Table, this.DealerDeck,this.DealerHand,this.PlayerHand);
            TableManager.Fill(this.DealerDeck);
            TableManager.Shuffle(this.DealerDeck);
        }

        public void Deal()
        {
            TableManager.DealCardToTopOf(this.DealerDeck,0,this.DealerHand);
            TableManager.DealCardToTopOf(this.DealerDeck,0,this.PlayerHand); 
        }

        public void Play() 
        {
            if (this.DealerHand[0].Rank > this.PlayerHand[0].Rank)
                Console.WriteLine("Dealer Wins");
                else
                    if (this.DealerHand[0].Rank < this.PlayerHand[0].Rank)
                        Console.WriteLine("Player Wins");
                    else
                        Console.WriteLine("Tie!");
        }
    }        
}
