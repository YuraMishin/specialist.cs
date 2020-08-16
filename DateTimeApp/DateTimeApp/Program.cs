using System;

namespace DateTimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDate1 = new DateTime(2020,08,13);
            Console.WriteLine(myDate1);
            var myDate2 = DateTime.Today;
            Console.WriteLine(myDate1);
            var myDate3 = DateTime.Now;
            Console.WriteLine(myDate3);
            Console.WriteLine(myDate3.ToShortDateString());
            Console.WriteLine(myDate3.ToShortTimeString());
            Console.WriteLine(myDate3.ToLongDateString());
            Console.WriteLine(myDate3.AddDays(-3));
            var formattedDate = string.Format("Date is {0: yyyy MMMM dddd}", myDate2);
            Console.WriteLine(formattedDate);
            Console.WriteLine();
            Console.WriteLine("DateTime Exercise");
            var theDate = DateTime.Now;
            var customFormattedDate = string.Format("{0:dd-MM-yy HH:mm:ss}", theDate);
            Console.WriteLine(customFormattedDate);
            customFormattedDate = string.Format("Day {0:dddd 'of month' MMMM 'year' yyyy}", theDate);
            Console.WriteLine(customFormattedDate);
            customFormattedDate = string.Format("{0:'Day' dddd \n'Month' MMMM \n'Year' yyyy}", theDate);
            Console.WriteLine(customFormattedDate);
        }
    }
}
