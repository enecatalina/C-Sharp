using System;
using System.Collections.Generic;

namespace DeckOfCards{
    public class Cards{             // created to build teh attributes/properites of cards
        public string stringVal;
        public string suit;
        public int val;
        public Cards(string cardSuit,string cardValue, int v)       //defines the parameters that are later passed 
        {
            suit = cardSuit;
            stringVal = cardValue;
            val = v;
        }
    }
    public class Deck
    {
        private static Random random = new Random();
        List<Cards> myDeckofCards = new List<Cards>();      //had to create a list to add the new cards...can't add to an array
        public Deck()       //constructor-defines how to start an instance. It will run everytime. Checks and functions are located here. 
            {
                makeDeck();     //had to put everything in makeDeck so that we can call back on it when we reset and make a new deck 
            }
        public void makeDeck()
            {
                string[] suits = {"Clubs","Spades","Hearts","Diamonds"};
                string [] stringVal = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
                string cardSuit;
                string cardValue;
            
                for (int s = 0; s < 3; s++)
                {
                    cardSuit = suits[s];
                    for(int v = 0; v < 13; v++)
                    {
                        cardValue = stringVal[v];
                        Cards myCard = new Cards(cardSuit,cardValue,v+1);
                        myDeckofCards.Add(myCard);
                    }
                }
            }
            public Cards Deal()         //since this is not viod, we want to return something, we need to specify what we are returning ---in this case we are wanting to return from the Card class
                {
                    Cards topcard = myDeckofCards[0];
                    return topcard;
                }
            public void showDeck()      //method --this is going to do stuff..not changing anything, just showing what's inside
                {
                    foreach (Cards card in myDeckofCards)
                    {
                        System.Console.WriteLine("Suits:" + card.suit + "," + "Val:" + card.stringVal + "," + "Value:" + card.val);
                    }
                }
            public void reset()
                {
                    myDeckofCards.Clear();
                    makeDeck();
                }
            public void shuffle()
                {
                    List<Cards> cardsToShuffle = new List<Cards>();
                    // foreach (Cards card in myDeckofCards)
                    for(int i = 0; i < 52; i++)
                    {
                        int index = random.Next(0,myDeckofCards.Count);
                        cardsToShuffle.Add(myDeckofCards[index]);
                        myDeckofCards.RemoveAt(index);
                    }
                    myDeckofCards = cardsToShuffle;
                }
    }
}



