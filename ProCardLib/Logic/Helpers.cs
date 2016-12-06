using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{
    public class Helpers
    {
        public static int GetRandomCardIndex(Deck deck)
        {
            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Count);
            Console.WriteLine(String.Format("Get Random Index: Seed={0}, Number={1}",seed,r));
            return r;

        }
        public static void SwapCards(Deck deck, int source, int destination)
        {
            Console.WriteLine(String.Format("Swap {0}({1}) and {2}({3})",deck[source].ToString(), source, deck[destination].ToString(), destination));
            var tempCard = deck[destination];
            deck[destination] = deck[source];
            deck[source] = tempCard;
        }
        public static void Fill(Deck deck)
        {
             for(var suit = 1; suit <= 4 && deck.Count < deck.Options.MaxCards; suit++)
             {
                 for (var rank = 1; rank <= 13 && deck.Count < deck.Options.MaxCards; rank++)
                 {
                     deck.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck));                    
                 }
             }
         }         
        public static void Shuffle(Deck deck)
        {
            Console.WriteLine(String.Format("Shuffle {0} Start", deck.Name));
            for (var i=0; i <= deck.Count - 1; i++)
            {
                Helpers.SwapCards(deck, i, GetRandomCardIndex(deck));
            }
            Console.WriteLine(String.Format("Shuffle {0} End", deck.Name));
        }

        public static void DealCardToTopOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            if (sourceDeck.Count > 0)
                destinationDeck.Insert(0,sourceDeck[sourceIndex]);
            else
                destinationDeck.Add(sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);
        }
        public static void DealCardToBottomOf(Deck sourceDeck, int sourceIndex, Deck destinationDeck)
        {
            destinationDeck.Add(sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public static void DealCardToPositionIn(Deck sourceDeck, int sourceIndex, Deck destinationDeck, int destinationIndex)
        {
            destinationDeck.Insert(destinationIndex,sourceDeck[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);          
        }

        public static void RemoveCard(Deck deck, int index)
        {
            deck.Remove(deck[index]);
        }

        public static void Empty(Deck deck)
        {
            deck.Clear();
        }

        public static void AddDeckToTable(Table table, Deck deck)
        {
            table.Add(deck);
        }

        public static void AddDecksToTable(Table table, params Deck[] decks)
        {            
            ClearTable(table);
            foreach(var deck in decks )
            {
                AddDeckToTable(table,deck);   
            }
        }

        public static void ClearTable(Table table)
        {
            table.Clear();
        }
    }
}