using System.Text;

namespace Binary
{
  /// <summary>
  /// Class Solution.
  /// Implements conversion from decimal to binary
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method calculates the result
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="size">Size</param>
    /// <returns>String</returns>
    public string PrintBinary(byte value, int size)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append($"{size}: ");
      for (int i = size - 1; i >= 0; i--)
      {
        long mask = 1 << i;
        long result = (mask & value) >> i;
        stringBuilder.Append(result);
      }

      return stringBuilder.ToString();
    }

    /// <summary>
    /// Method calculates the result
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="size">Size</param>
    /// <returns>String</returns>
    public string PrintBinary(short value, int size)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append($"{size}: ");
      for (int i = size - 1; i >= 0; i--)
      {
        long mask = 1 << i;
        long result = (mask & value) >> i;
        stringBuilder.Append(result);
      }

      return stringBuilder.ToString();
    }

    /// <summary>
    /// Method calculates the result
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="size">Size</param>
    /// <returns>String</returns>
    public string PrintBinary(int value, int size)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append($"{size}: ");
      for (int i = size - 1; i >= 0; i--)
      {
        long mask = 1 << i;
        long result = (mask & value) >> i;
        stringBuilder.Append(result);
      }

      return stringBuilder.ToString();
    }

    /// <summary>
    /// Method calculates the result
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="size">Size</param>
    /// <returns>String</returns>
    public string PrintBinary(long value, int size)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append($"{size}: ");
      for (int i = size - 1; i >= 0; i--)
      {
        long mask = 1 << i;
        long result = (mask & value) >> i;
        stringBuilder.Append(result);
      }

      return stringBuilder.ToString();
    }
  }
}
