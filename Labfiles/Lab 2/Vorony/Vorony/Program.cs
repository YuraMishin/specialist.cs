using System;

namespace Vorony
{
    /// <summary>
    /// Программа выводит количество ворон на ветке
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа приложения
        /// </summary>
        static void Main()
        {
            Console.Write("Введите число ворон на ветке: ");
            var ravenQ = int.Parse(Console.ReadLine());
            string result;
            var rem100 = ravenQ % 100;
            if (rem100 >= 11 && rem100 <= 14)
            {
                result = "ворон";
            }
            else
            {
                var rem10 = ravenQ % 10;
                switch (rem10)
                {
                    case 1:
                        result = "ворона";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        result = "вороны";
                        break;
                    default:
                        result = "ворон";
                        break;
                }
            }
            Console.WriteLine($"На ветке {ravenQ} {result}");
            Console.ReadKey();
        }
    }
}
