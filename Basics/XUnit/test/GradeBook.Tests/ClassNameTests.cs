using Xunit;

namespace GradeBook.Tests
{
  /// <summary>
  /// Class ClassNameTests.
  /// Tests ClassName class
  /// </summary>
  public class ClassNameTests
  {
    /// <summary>
    /// Tests Get() method
    /// </summary>
    [Fact]
    public void Get_WhenInvokes_ReturnsResult()
    {
      var expected = 7.0;
      var actual = 7.0;

      Assert.Equal(expected, actual, 1);
    }
  }
}
