using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{    
    public class TableManager
    {
        public EventHandler<TableEventArgs> OnTableClearing;
        public EventHandler<TableEventArgs> OnTableCleared;
        public EventHandler<DeckEventArgs> OnDeckClearing;
        public EventHandler<DeckEventArgs> OnDeckCleared;
        public EventHandler<DeckEventArgs> OnDeckAddingToTable;
        public EventHandler<DeckEventArgs> OnDeckAddedToTable;
        public EventHandler<DeckEventArgs> OnDeckRemovedFromTable;
        public EventHandler<DeckEventArgs> OnDeckBeingRemovedFromTable;
        public EventHandler<DeckEventArgs> OnDeckShuffling;
        public EventHandler<DeckEventArgs> OnDeckShuffled;
        public EventHandler<DeckEventArgs> OnDeckFilling;
        public EventHandler<DeckEventArgs> OnDeckFilled;
        public EventHandler<CardEventArgs> OnCardAddingToDeck;
        public EventHandler<CardEventArgs> OnCardAddedToDeck;
        public EventHandler<CardEventArgs> OnCardRemovingFromDeck;
        public EventHandler<CardEventArgs> OnCardRemovedFromDeck;
        
        public Table Table {get;set;}
        public void ClearTable(Table table)
        {
            OnTableClearing(this,new TableEventArgs(table.TableId));
            table.Decks.Clear();
            OnTableCleared(this,new TableEventArgs(table.TableId));
        }
        public void AddDeckToTable(Table table, Deck deck)
        {
            OnDeckAddingToTable(this, new DeckEventArgs(deck.DeckId));
            table.Decks.Add(deck);
            OnDeckAddedToTable(this, new DeckEventArgs(deck.DeckId));
        }
        public void RemoveDeckFromTable(Table table, Deck deck)
        {
            OnDeckBeingRemovedFromTable(this, new DeckEventArgs(deck.DeckId));
            table.Decks.Add(deck);
            OnDeckRemovedFromTable(this, new DeckEventArgs(deck.DeckId));
        }
        public void ClearDeck(Deck deck)
        {
            OnDeckClearing(this, new DeckEventArgs(deck.DeckId));
            deck.Cards.Clear();
            OnDeckCleared(this, new DeckEventArgs(deck.DeckId));
        }
        public void FillDeck(Deck deck)
        {
            OnDeckFilling(this, new DeckEventArgs(deck.DeckId));
            for(var suit = 1; suit <= 4 && deck.Cards.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Cards.Count < deck.Options.MaxCards; rank++)
                {                     
                    deck.Cards.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank));
                }
            }
            OnDeckFilled(this, new DeckEventArgs(deck.DeckId));
         }         
        public void Shuffle(Deck deck)
        {
            OnDeckShuffling(this, new DeckEventArgs(deck.DeckId));
            for (var i=0; i <= deck.Cards.Count - 1; i++)
            {
                SwapCards(deck, i, GetRandomCardIndex(deck));
            }
            OnDeckShuffled(this, new DeckEventArgs(deck.DeckId));
        }

        public int GetRandomCardIndex(Deck deck)
        {
            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Cards.Count);
            Console.WriteLine(String.Format("Get Random Index: Seed={0}, Number={1}",seed,r));
            return r;
        }
        public void SwapCards(Deck deck, int source, int destination)
        {
            Console.WriteLine(String.Format("Swap {0}({1}) and {2}({3})",deck.Cards[source].ToString(), source, deck.Cards[destination].ToString(), destination));
            var tempCard = deck.Cards[destination];
            deck.Cards[destination] = deck.Cards[source];
            deck.Cards[source] = tempCard;
        }

        public void DealCardToTopOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            if (sourceDeck.Cards.Count > 0)
                destinationDeck.Cards.Insert(0,sourceDeck.Cards[sourceIndex]);
            else
                destinationDeck.Cards.Add(sourceDeck.Cards[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);
        }
        public void DealCardToBottomOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            destinationDeck.Cards.Add(sourceDeck.Cards[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public void DealCardToPositionIn(Deck sourceDeck, int sourceIndex, Deck destinationDeck, int destinationIndex)
        {
            destinationDeck.Cards.Insert(destinationIndex,sourceDeck.Cards[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public void RemoveCard(Deck deck, int index)
        {
            deck.Cards.Remove(deck.Cards[index]);
        }

 

        public void AddDecksToTable(Table table, params Deck[] decks)
        {            
            ClearTable(table);
            foreach(var deck in decks )
            {                
                AddDeckToTable(table,deck);            
            }
        }

    }
}