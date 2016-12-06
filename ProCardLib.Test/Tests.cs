using System;
using Xunit;
using ProCardLib.DataModel;
using ProCardLib.Logic;
using ProCardLib.Engines;

namespace ProCardLibTest
{
    public class Tests
    {
        [Fact]       
        public void CreateDeck() 
        { 
            var game = new HighCardWins();
            game.Initialize();
            game.Deal();
            Console.WriteLine(game.Table.ToString());
            game.Play();
        }
    }
}
