using Xunit;

namespace OddEven.Tests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// Tests IsOdd() method
    /// </summary>
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void IsOdd_InputOdd_ReturnTrue(int value)
    {
      var solution = new Solution();

      Assert.NotNull(solution);
      Assert.IsType<Solution>(solution);

      var actual = solution.IsOdd(value);

      Assert.True(actual);
    }
    /// <summary>
    /// Tests IsOdd() method
    /// </summary>
    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void IsOdd_InputEven_ReturnFalse(int value)
    {
      var solution = new Solution();

      Assert.NotNull(solution);
      Assert.IsType<Solution>(solution);

      var actual = solution.IsOdd(value);

      Assert.False(actual);
    }
  }
}
