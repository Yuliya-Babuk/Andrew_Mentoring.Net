using Nager.Date;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.date_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To query holidays, please, enter a two-letter country code:");
            string countryCode = Console.ReadLine().ToUpper();


            Console.WriteLine("Enter a year you query holidays for in YYYY format:");
            while (true)
            {
                try
                {
                    int year = Int32.Parse(Console.ReadLine());
                    var publicHolidays = DateSystem.GetPublicHoliday(year, countryCode);
                    Console.WriteLine($"\"country\":  {countryCode}\n\"holidays\":\n"); 
                    foreach (PublicHoliday publicHoliday in publicHolidays)
                    {

                        DateTime date = publicHoliday.Date;
                        string name = publicHoliday.Name;
                        Dictionary<DateTime, string> dict = new Dictionary<DateTime, string>();
                        dict.Add(date, name);
                        Console.WriteLine($"\"date\":  {date.ToShortDateString()} \n\"name\":  {name}\n");
                    }
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect format for a year, please, try again:\n");
                }
            }

        }
    }
}
