using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace FactorialTests
{
  /// <summary>
  /// Class FactorialTests.
  /// Tests Factorial class
  /// </summary>
  [TestFixture]
  public class FactorialTests
  {
    /// <summary>
    /// TestContext
    /// </summary>
    public TestContext TestContext { get; set; }

    /// <summary>
    /// Tests Get() method
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="expected">Expected value</param>
    [Test]
    [Description("Tests if returns the valid result")]
    [Author("Mishin Yura")]
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 6)]
    [TestCase(4, 24)]
    public void Get_WhenInvokes_ReturnsResult(int number, int expected)
    {
      var result = Factorial.Factorial.Get(number);

      var config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();
      var name = config["Name"];
      TestContext.WriteLine(name);


      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
