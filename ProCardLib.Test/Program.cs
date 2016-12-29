using System;
using ProCardLib.DataModel;
using ProCardLib.Logic;
using ProCardLib.Engines;

namespace ConsoleApplication
{
    public static class Program
    {          
        public static void Main(string[] args) 
        { 
            var game = new HighCardWins();
            game.Initialize();
            game.Deal();
            Console.WriteLine(game.Table.ToString());
            game.Play();
        }
    }
}
