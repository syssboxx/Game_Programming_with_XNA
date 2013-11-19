using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09_ConditionalStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //**************
            //Menu:
            //1 – New Game
            //2 – Load Game
            //3 – Options
            //4 – Quit
            //**************

            int userChoice;

            Console.WriteLine(new string('*',20));
            Console.WriteLine("Menu");
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine(new string('*',20));

            userChoice = int.Parse(Console.ReadLine());

            //Create a menu using an if statement
            if (userChoice==1)
            {
                Console.WriteLine("Starting New Game ...");
            }
            else if (userChoice==2)
            {
                Console.WriteLine("Loading Game ...");
            }
            else if (userChoice==3)
            {
                Console.WriteLine("Opening Game Options ...");
            }
            else if (userChoice==4)
            {
                Console.WriteLine("Quiting Game ...");
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }

            //Use a switch statement
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Menu");
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine(new string('*', 20));

            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1: Console.WriteLine("Starting New Game ..."); break;
                case 2: Console.WriteLine("Loading Game ..."); break;
                case 3: Console.WriteLine("Opening Game Options ..."); break;
                case 4: Console.WriteLine("Quiting Game ..."); break;
                default: Console.WriteLine("Invalid Input.");break;
            }
        }
    }
}
