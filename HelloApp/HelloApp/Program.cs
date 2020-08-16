using System;
using System.Text;

namespace HelloApp
{
    /// <summary>
    /// Class Program.
    /// CLI App.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method is the entry point.
        /// </summary>
        /// <param name="args">CLI params</param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = Encoding.GetEncoding(1251);
            Console.WriteLine("Hello World!");
            var name = "Yura";
            Console.WriteLine($"Hello, {name}");
            Console.ReadKey();
        }
    }
}