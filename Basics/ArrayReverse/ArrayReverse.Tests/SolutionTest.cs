using Xunit;

namespace ArrayReverse.Tests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// Tests Reverse() method
    /// </summary>
    [Fact]
    public void Reverse_InputArray_ResultSortedArray()
    {
      Solution solution = new Solution();
      int[] ints = { 1, 2, 3 };
      int[] expected = { 3, 2, 1 };
      int[] actual = solution.Reverse(ints);

      Assert.Equal(expected, actual);
    }
  }
}
