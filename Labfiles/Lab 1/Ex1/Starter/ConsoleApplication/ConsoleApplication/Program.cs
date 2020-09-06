using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                line = line.Replace(",", " y:");
                line = "x:" + line;
                Console.WriteLine(line);
            }
        }
    }

}
