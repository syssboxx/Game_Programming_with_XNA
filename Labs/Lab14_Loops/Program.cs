using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace Lab14_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print numbers in user-selected range

            Console.WriteLine("Enter a lower bound :");
            int lower = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a upper bound");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine();
            for (int i = lower; i <= upper; i++)
            {
                Console.WriteLine(i);
            }


            //Set up game objects
            Deck deck = new Deck();
            Card topCard;
            deck.Shuffle();

            List<Card> hands = new List<Card>();

            //deal 5 cards from the deck to the hand
            for (int i = 0; i < 5; i++)
            {
                topCard = deck.TakeTopCard();
                hands.Add(topCard);
            }

            //flip all the cards in the hand
            for (int i = 0; i < hands.Count; i++)
            {
                hands[i].FlipOver();
            }

            //print all the 5 cards in the hand
            Console.WriteLine("\nAll the cards : ");
            foreach (Card card in hands)
            {
                card.Print();
            }
            
        }
    }
}
