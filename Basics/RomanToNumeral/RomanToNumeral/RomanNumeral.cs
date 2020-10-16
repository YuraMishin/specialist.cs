using System.Collections.Generic;

namespace RomanToNumeral
{
  /// <summary>
  /// Class RomanNumeral.
  /// Implements a solution to parse roman numeral to integer number
  /// </summary>
  public class RomanNumeral
  {
    /// <summary>
    /// Dictionary
    /// </summary>
    private static Dictionary<char, int> map = new Dictionary<char, int>()
    {
      {'I', 1},
      {'V', 5},
      {'X', 10},
      {'L', 50},
      {'C', 100},
      {'D', 500},
      {'M', 1000}
    };

    /// <summary>
    /// Method parses numeral
    /// </summary>
    /// <param name="roman">Roman numeral</param>
    /// <returns>(int) Result</returns>
    public static int Parse(string roman)
    {
      var result = 0;
      for (int i = 0; i < roman.Length; i++)
      {
        if (i + 1 < roman.Length && IsSubtractive(roman[i], roman[i + 1]))
        {
          result -= map[roman[i]];
        }
        else
        {
          result += map[roman[i]];
        }
      }

      return result;
    }

    /// <summary>
    /// Method determines if there is subtraction
    /// </summary>
    /// <param name="ch1">Char1</param>
    /// <param name="ch2">Char2</param>
    /// <returns></returns>
    private static bool IsSubtractive(char ch1, char ch2)
    {
      return map[ch1] < map[ch2];
    }
  }
}
