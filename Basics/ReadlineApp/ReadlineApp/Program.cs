using System;

namespace ReadlineApp
{
  /// <summary>
  /// Class Program.
  /// Implements read line example
  /// </summary>
  class Program
  {
    /// <summary>
    /// The entry point of the app
    /// </summary>
    /// <param name="args">Args</param>
    static void Main(string[] args)
    {
      Console.WriteLine("What is your name?");
      var name = Console.ReadLine();
      Console.WriteLine($"Hello, {name}!");
      Console.WriteLine("How old are you?");
      int.TryParse(Console.ReadLine(), out int age);
      if (age == 0)
      {
        Console.WriteLine("Wrong input!");
      }
      else
      {
        Console.WriteLine($"You are {age} old");
      }
    }
  }
}
