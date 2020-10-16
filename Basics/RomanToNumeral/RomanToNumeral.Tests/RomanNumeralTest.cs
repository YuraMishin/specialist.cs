using NUnit.Framework;

namespace RomanToNumeral.Tests
{
  /// <summary>
  /// Class RomanNumeralTest.
  /// Tests RomanNumeral class
  /// </summary>
  [TestFixture]
  public class RomanNumeralTest
  {
    /// <summary>
    /// Tests Parse() method
    /// </summary>
    /// <param name="input">Input numeral</param>
    /// <param name="result">Result</param>
    [Test]
    [TestCase("XIV", 14)]
    [TestCase("I", 1)]
    [TestCase("X", 10)]
    public void Parse_InputXIV_Get14(string input, int result)
    {
      Assert.That(RomanNumeral.Parse(input), Is.EqualTo(result));
    }
  }
}
