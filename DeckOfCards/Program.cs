using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeckofCards = new Deck();                  //this is looking at the deck class for the deck function(the constructor function)
            // myDeckofCards.showDeck();                         //this is the deck method function on a specific instance
            // Cards pullCard = myDeckofCards.Deal();            
            // System.Console.WriteLine(pullCard.suit);
            // System.Console.WriteLine(pullCard.stringVal);
            // System.Console.WriteLine(pullCard.val);
            // myDeckofCards.reset();
            // myDeckofCards.showDeck();
            myDeckofCards.shuffle();

        }
    }
}
