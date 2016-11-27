using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{
    public class Helpers
    {
        public static int GetRandomCardIndex(Deck deck)
        {
            Console.WriteLine(deck.Name + ": Get random card");
            var random = new Random((int)DateTime.Now.Subtract(DateTime.MinValue).TotalMilliseconds);
            return random.Next(deck.Count);
        }
        public static void SwapCards(Deck deck, int source, int destination)
        {
            Console.WriteLine(deck.Name + ": Swap");
            var tempCard = deck[destination];
            deck[destination] = deck[source];
            deck[source] = tempCard;
        }
        public static void Shuffle(Deck deck)
        {
            for (var i=0; i <= deck.Count - 1; i++)
            {
                Helpers.SwapCards(deck, i, GetRandomCardIndex(deck));
            }
        }
    }
}