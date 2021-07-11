using Nager.Date;
using Nager.Date.Model;
using System;

namespace Nager.date_API
{
    class Program
    {
        public class Car
        {
            private int distance = 0;

            public void Drive(int ds)
            {
                distance += ds;
            }

            public int GetDistane()
            {
                return distance;
            }

            public static string GetName()
            {
                return "WW";
            }
        }



        static void ShowHolidays()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("To query holidays, please, enter a two-letter country code:");
                    var countryCode = Console.ReadLine().ToUpper();

                    Console.WriteLine("Enter a year you query holidays for in YYYY format:");
                    //throw new NullReferenceException("message");
                    var yearString = Console.ReadLine();
                    if (yearString.Length != 4)
                    {
                        throw new FormatException();
                    }

                    var year = Int32.Parse(yearString);

                    var publicHolidays = DateSystem.GetPublicHoliday(year, countryCode);
                    Console.WriteLine($"\"country\":  {countryCode}\n\"holidays\":\n");
                    foreach (PublicHoliday publicHoliday in publicHolidays)
                    {
                        DateTime date = publicHoliday.Date;
                        string name = publicHoliday.Name;
                        Console.WriteLine($"\"date\":  {date.ToShortDateString()} \n\"name\":  {name}\n");
                    }
                    return;

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect format for a country code, please, try again:\n");
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Incorrect format for a year, please, try again:\n");
                }
            }
        }

        static void Main(string[] args)
        {

            try
            {
                ShowHolidays();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
