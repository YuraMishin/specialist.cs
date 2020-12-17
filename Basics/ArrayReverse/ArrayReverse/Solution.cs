namespace ArrayReverse
{
  /// <summary>
  /// Class Solution.
  /// Rearrange all elements of an array in reverse order.
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Method computes the solution
    /// </summary>
    /// <param name="array">Array</param>
    /// <returns>Array</returns>
    public int[] Reverse(int[] array)
    {
      int n = array.Length;
      for (int i = 0; i <= n / 2; i++)
      {
        int item = array[i];
        array[i] = array[n - 1 - i];
        array[n - 1 - i] = item;
      }
      return array;
    }
  }
}
