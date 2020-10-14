using NUnit.Framework;

namespace Factorial.Tests
{
  /// <summary>
  /// Class FactorialTests.
  /// Tests Factorial class
  /// </summary>
  [TestFixture]
  public class FactorialTests
  {
    /// <summary>
    /// Tests Get() method
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="expected">Expected value</param>
    [Test]
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 6)]
    [TestCase(4, 24)]
    public void Get_WhenInvokes_ReturnsResult(int number, int expected)
    {
      var result = Factorial.Get(number);

      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
