using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace Lab13_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck=new Deck();
            Card[] cards = new Card[5];

            deck.Shuffle();

            cards[0] = deck.TakeTopCard();
            cards[0].FlipOver();
            cards[0].Print();

            cards[1] = deck.TakeTopCard();
            cards[1].FlipOver();

            Console.WriteLine("Cards :");
            cards[0].Print();
            cards[1].Print();


        }
    }
}
