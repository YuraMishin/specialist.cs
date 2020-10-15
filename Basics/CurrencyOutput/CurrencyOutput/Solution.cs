using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace CurrencyOutput
{
  /// <summary>
  /// Class Solution.
  /// Displays different currencies
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method displays currencies
    /// </summary>
    /// <param name="money">(double) Money</param>
    public static void ShowCurrences(double money)
    {
      Console.OutputEncoding = Encoding.UTF8;
      var currentThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine($"{money:C2}");
      Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-Ru");
      Console.WriteLine($"{money:C2}");
      Thread.CurrentThread.CurrentCulture = currentThreadCurrentCulture;
    }
  }
}
