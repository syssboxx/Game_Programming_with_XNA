using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Lab07_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string month;
            int monthNum=0;
            int day;
            DateTime dtm;
            DateTime reminder;

            Console.WriteLine("In what month were you born?");
            month = Console.ReadLine().ToLower();

            Console.WriteLine("On what day were you born?");
            day = int.Parse(Console.ReadLine());

            switch (month)
            {
                case "january": monthNum = 1; break;
                case "february": monthNum = 2; break;
                case "mars": monthNum = 3; break;
                case "april": monthNum = 4; break;
                case "may": monthNum = 5; break;
                case "june": monthNum = 6; break;
                case "july": monthNum = 7; break;
                case "august": monthNum = 8; break;
                case "september": monthNum = 9; break;
                case "october": monthNum = 10; break;
                case "november": monthNum = 11; break;
                case "december": monthNum = 12; break;
                default: Console.WriteLine("invalid month"); break;
            }

            dtm = new DateTime(2013, monthNum, day);

            //set invariant culture
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Console.WriteLine("Your birthday is {0:MMMM d}", dtm);

            //send a reminder email for inviting the user to visit an in-game store on their birthday for 20% off - on the day before birthday
            reminder=dtm.AddDays(-1);
            Console.WriteLine("You’ll receive an email reminder on {0:MMMM d}", reminder);

            //--------------------------------------------------------------------------------------------

            //if the current culture is not invariant 

            //Console.WriteLine("You’ll receive an email reminder on "+ string.Format(CultureInfo.InvariantCulture, "{0:MMMM d}", reminder));
            //Console.WriteLine(dtm.ToString("MMMM", CultureInfo.InvariantCulture));

            //current culture
            //IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
    }
}
