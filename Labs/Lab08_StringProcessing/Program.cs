using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab08_StringProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read in a string from the user in the following format:
            //<pyramid slot number>,<block letter>,<whether or not the block should be lit> exemple : 15,M,true

            int slotNumber;
            char blockLetter;
            string blockLit;
            int commaIndex;

            Console.WriteLine("Enter input in the format (<slot number>,<block letter>,<true/false>");
            string input = Console.ReadLine();

            //Extracting the Pyramid Slot Number
            commaIndex = input.IndexOf(',');
            slotNumber = int.Parse(input.Substring(0, commaIndex));
            Console.WriteLine("Slot Number : {0}",slotNumber);

            //Problem 2 – Extracting the Block Letter
            blockLetter = char.Parse(input.Substring(commaIndex+1, 1));
            Console.WriteLine("Block Letter : {0}", blockLetter);

            //Extracting Whether Or Not the Block Should Be Lit
            blockLit = input.Substring(commaIndex + 3);
            Console.WriteLine("Block Lit or Not : {0}", blockLit);
        }
    }
}
