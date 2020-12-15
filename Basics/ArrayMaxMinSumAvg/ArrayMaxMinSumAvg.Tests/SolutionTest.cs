using Xunit;

namespace ArrayMaxMinSumAvg.Tests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// Tests GetMax() method
    /// </summary>
    [Fact]
    public void GetMax_InputArray_Return3()
    {
      Solution solution = new Solution();
      int[] ints = { 2, 1, 3 };
      int expected = 3;
      int actual = solution.GetMax(ints);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests GetMin() method
    /// </summary>
    [Fact]
    public void GetMin_InputArray_Return1()
    {
      Solution solution = new Solution();
      int[] ints = { 2, 1, 3 };
      int expected = 1;
      int actual = solution.GetMin(ints);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests GetSum() method
    /// </summary>
    [Fact]
    public void GetSum_InputArray_Return6()
    {
      Solution solution = new Solution();
      int[] ints = { 2, 1, 3 };
      int expected = 6;
      int actual = solution.GetSum(ints);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests GetAVG() method
    /// </summary>
    [Fact]
    public void GetAVG_InputArray_Return2()
    {
      Solution solution = new Solution();
      int[] ints = { 2, 1, 3, 1 };
      double expected = 1.75;
      double actual = solution.GetAVG(ints);

      Assert.Equal(expected, actual, 2);
    }
  }
}
