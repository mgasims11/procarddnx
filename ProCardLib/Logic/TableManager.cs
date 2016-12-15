using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{    
    public class TableManager
    {
        public EventHandler<TableEventArgs> OnTableClearing;
        public EventHandler<TableEventArgs> OnTableCleared;
        public EventHandler<DeckEventArgs> OnDeckAddingToTable;
        public EventHandler<DeckEventArgs> OnDeckAddedToTable;
        public EventHandler<DeckEventArgs> OnDeckRemovedFromTable;
        public EventHandler<DeckEventArgs> OnDeckRemovingFromTable;
        public EventHandler<DeckEventArgs> OnDeckShuffling;
        public EventHandler<DeckEventArgs> OnDeckShuffled;
        public EventHandler<DeckEventArgs> OnDeckFilling;
        public EventHandler<DeckEventArgs> OnDeckFilled;
        public EventHandler<DeckEventArgs> OnDeckClearing;
        public EventHandler<DeckEventArgs> OnDeckCleared;
        public EventHandler<CardEventArgs> OnCardAddingToDeck;
        public EventHandler<CardEventArgs> OnCardAddedToDeck;
        public EventHandler<CardEventArgs> OnCardRemovingFromDeck;
        public EventHandler<CardEventArgs> OnCardRemovedFromDeck;
        
        public Table Table {get;set;}

        public int GetRandomCardIndex(Deck deck)
        {
            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Count);
            Console.WriteLine(String.Format("Get Random Index: Seed={0}, Number={1}",seed,r));
            return r;

        }
        public void SwapCards(Deck deck, int source, int destination)
        {
            Console.WriteLine(String.Format("Swap {0}({1}) and {2}({3})",deck[source].ToString(), source, deck[destination].ToString(), destination));
            var tempCard = deck[destination];
            deck[destination] = deck[source];
            deck[source] = tempCard;
        }
        public void Fill(Deck deck)
        {
             for(var suit = 1; suit <= 4 && deck.Count < deck.Options.MaxCards; suit++)
             {
                 for (var rank = 1; rank <= 13 && deck.Count < deck.Options.MaxCards; rank++)
                 {                     
                     deck.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank));
                 }
             }
         }         
        public void Shuffle(Deck deck)
        {
            Console.WriteLine(String.Format("Shuffle {0} Start", deck.Name));
            for (var i=0; i <= deck.Count - 1; i++)
            {
                SwapCards(deck, i, GetRandomCardIndex(deck));
            }
            Console.WriteLine(String.Format("Shuffle {0} End", deck.Name));
        }

        public void DealCardToTopOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            if (sourceDeck.Count > 0)
                destinationDeck.Insert(0,sourceDeck[sourceIndex]);
            else
                destinationDeck.Add(sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);
        }
        public void DealCardToBottomOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            destinationDeck.Add(sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public void DealCardToPositionIn(Deck sourceDeck, int sourceIndex, Deck destinationDeck, int destinationIndex)
        {
            destinationDeck.Insert(destinationIndex,sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public void RemoveCard(Deck deck, int index)
        {
            deck.Remove(deck[index]);
        }

        public void Empty(Deck deck)
        {
            deck.Clear();
        }

        public void AddDeckToTable(Table table, Deck deck)
        {
            OnDeckAddingToTable(this, new DeckEventArgs(table,deck));
            table.Add(deck.Name,deck);
            OnDeckAddedToTable(this, new DeckEventArgs(table,deck));
        }

        public void AddDecksToTable(Table table, params Deck[] decks)
        {            
            ClearTable(table);
            foreach(var deck in decks )
            {                
                AddDeckToTable(table,deck);            
            }
        }

        public void ClearTable(Table table)
        {
            OnTableClearing(this,new TableEventArgs(table));
            table.Clear();
            OnTableCleared(this,new TableEventArgs(table));
        }
    }
}