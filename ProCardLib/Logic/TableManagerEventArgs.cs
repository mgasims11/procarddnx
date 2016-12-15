using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{    
    public class TableEventArgs : EventArgs
    {
        public Table Table {get;set;}
        public TableEventArgs(Table table)
        {
            this.Table = table;    
        }
    }
    public class DeckEventArgs : EventArgs
    {
        public Table Table {get;set;}
        public Deck Deck {get;set;}
        public DeckEventArgs(Table table, Deck deck)
        {            
            this.Table = table;
            this.Deck = deck;
        }
    }
    public class CardEventArgs : EventArgs
    {
        public Deck Deck {get;set;}
        public Card Card {get;set;}
        public CardEventArgs(Deck deck, Card card)
        {
            this.Deck = deck;
            this.Card = card;
        }
    }
}