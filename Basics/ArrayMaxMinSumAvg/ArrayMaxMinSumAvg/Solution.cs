namespace ArrayMaxMinSumAvg
{
  /// <summary>
  /// Class Solution.
  /// Searching for the maximum, minimum, sum, average within array.
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method computes the maximum
    /// </summary>
    /// <param name="arr">Array</param>
    /// <returns>int</returns>
    public int GetMax(int[] arr)
    {
      int max = int.MinValue;
      foreach (var item in arr)
      {
        if (item > max)
        {
          max = item;
        }
      }
      return max;
    }

    /// <summary>
    /// Method computes the minimum
    /// </summary>
    /// <param name="arr">Array</param>
    /// <returns>int</returns>
    public int GetMin(int[] arr)
    {
      int min = int.MaxValue;
      foreach (var item in arr)
      {
        if (item < min)
        {
          min = item;
        }
      }
      return min;
    }

    /// <summary>
    /// Method computes the sum
    /// </summary>
    /// <param name="arr">Array</param>
    /// <returns>int</returns>
    public int GetSum(int[] arr)
    {
      int sum = 0;
      foreach (var item in arr)
      {
        sum += item;
      }
      return sum;
    }

    /// <summary>
    /// Method computes the average
    /// </summary>
    /// <param name="arr">Array</param>
    /// <returns>double</returns>
    public double GetAVG(int[] arr)
    {
      return (double)GetSum(arr) / arr.Length;
    }
  }
}
