using System;
using ProCardLib.DataModel;
using ProCardLib.Logic;
namespace ProCardLib.Engines
{
    public class HighCardWins1
    {
        public TableManager TableManager {get;set;}
        public Deck DealerDeck {get;set;}
        public Deck DealerHand {get;set;}
        public Deck PlayerHand;
        private DeckOptions DealerDeckOptions;
        private DeckOptions HandDeckOptions;
      
        public void Initialize()
        {
            this.CreateTable(out this.TableManager);
            this.CreateDealerDeck(out this.CreateDealerDeck, out this.DealerDeckLayoutManager);
            
            
            this.DealerHandLayoutManager = CreateDealerHand();
            this.PlayerHandLayoutManager = CreatePlayerHand();
           
            this.TableManager = new TableManager() {Table = new Table()};
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
        private void CreateTable(out TableManager tableManager, out TableLayoutManager tableLayoutManager)
        {            
            var table = new Table();
            tableManager = new TableManager() { Table = new Table() };
            tableLayoutManager = new TableLayoutManager() { Table = new Table() };
        }
        private void CreateDealerDeck(out Deck deck, DeckLayoutManager deckLayoutManager)
        {                        
            deck = new Deck() 
            {
                DeckName = "Dealer Deck",
                Options = new DeckOptions(52) { CardDisplayFormat = Card.Formats.ConciseLetter }
            };

            deckLayoutManager = new DeckLayoutManager()
            {
                Deck = deck
            };

        }
        private void CreateDealerHand(out Deck deck, DeckLayoutManager deckLayoutManager)
        {
            deck = new Deck() 
            {
                DeckName = "Dealer Hand",
                Options = new DeckOptions(2) { CardDisplayFormat = Card.Formats.ConciseLetter }
            };

            deckLayoutManager = new DeckLayoutManager()
            {
                Deck = deck
            };
        
        }
        private void CreatePlayerHand(out Deck deck, DeckLayoutManager deckLayoutManager)
        {
            deck = new Deck() 
            {
                DeckName = "Player Hand",
                Options = new DeckOptions(2) { CardDisplayFormat = Card.Formats.ConciseLetter }
            };

            deckLayoutManager = new DeckLayoutManager()
            {
                Deck = deck
            };
        }
    }        
}
