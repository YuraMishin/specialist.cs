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
        /// Programm entry point.
        /// </summary>
        /// <param name="args">Command line parameters</param>
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