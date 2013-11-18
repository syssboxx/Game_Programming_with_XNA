using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02_VariablesConstants
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 30;

            const int MAX_SCORE = 100;
            int score = 25;
            float percent;

            percent = (float)score / MAX_SCORE;

            Console.WriteLine("User age : {0}",age);
            Console.WriteLine("User score percent: {0}",percent);

        }
    }
}
