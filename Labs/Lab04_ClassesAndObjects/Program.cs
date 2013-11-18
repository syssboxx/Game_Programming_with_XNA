using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new deck and print the contents of the deck
            Deck deck = new Deck();
            Console.WriteLine("Initial deck :\n");
            deck.Print();

            // shuffle the deck and print the contents of the deck
            deck.Shuffle();
            Console.WriteLine("\nShuffled deck :\n");
            deck.Print();

            // take the top card from the deck and print the card rank and suit
            Card card = deck.TakeTopCard();
            Console.WriteLine("\nTop card's info : rank {0}, suit {1}", card.Rank, card.Suit);

            // take the top card from the deck and print the card rank and suit
            card = deck.TakeTopCard();
            Console.WriteLine("\nNext card's info : rank {0}, suit {1}", card.Rank, card.Suit);

        }
    }
}
