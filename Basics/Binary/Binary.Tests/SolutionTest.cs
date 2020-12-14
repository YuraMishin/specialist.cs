using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

namespace Binary.Tests
{
  /// <summary>
  /// Class SolutionTest.
  /// Tests Solution class
  /// </summary>
  public class SolutionTest
  {
    /// <summary>
    /// ITestOutputHelper
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="output"></param>
    public SolutionTest(ITestOutputHelper output)
    {
      _output = output;
    }

    /// <summary>
    /// Tests PrintBinary() method
    /// </summary>
    [Fact(DisplayName = "PrintBinary. Input is 8. Return: 01100100")]
    public void PrintBinary_InputIs8_ReturnResult()
    {
      _output.WriteLine("This is a log from the test output helper");

      Solution solution = new Solution();

      Assert.NotNull(solution);
      solution.Should().NotBeNull();

      Assert.IsType<Solution>(solution);
      solution.Should().BeOfType(typeof(Solution));

      byte value = 100;
      var expected = "8: 01100100";
      var actual = solution.PrintBinary(value, 8);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests PrintBinary() method
    /// </summary>
    [Fact]
    public void PrintBinary_InputIs16_ReturnResult()
    {
      Solution solution = new Solution();
      short value = 100;
      var expected = "16: 0000000001100100";
      var actual = solution.PrintBinary(value, 16);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests PrintBinary() method
    /// </summary>
    [Fact]
    public void PrintBinary_InputIs32_ReturnResult()
    {
      Solution solution = new Solution();
      int value = 100;
      var expected = "32: 00000000000000000000000001100100";
      var actual = solution.PrintBinary(value, 32);

      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests PrintBinary() method
    /// </summary>
    [Fact]
    public void PrintBinary_InputIs64_ReturnResult()
    {
      Solution solution = new Solution();
      long value = 100;
      var expected = "64: 0000000000000000000000000000000000000000000000000000000001100100";
      var actual = solution.PrintBinary(value, 64);

      Assert.Equal(expected, actual);
    }
  }
}
