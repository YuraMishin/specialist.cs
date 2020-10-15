using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace CurrencyOutput.Tests
{
  /// <summary>
  /// Class SolutionTests.
  /// Tests Solution class
  /// </summary>
  public class SolutionTests
  {
    private StringWriter _stringWriter;
    private TextWriter _originalOutput;

    /// <summary>
    /// Method invokes before tests
    /// </summary>
    [SetUp]
    public void Setup()
    {
      _stringWriter = new StringWriter();
      _originalOutput = Console.Out;
      Console.SetOut(_stringWriter);
    }

    /// <summary>
    /// Tests
    /// </summary>
    /// <param name="number"></param>
    [Test]
    [TestCase(100)]
    public void ShowCurrences_WhenInvokes_ShowCurrencies(double number)
    {
      Solution.ShowCurrences(number);
      var expected = new StringBuilder();
      var currentThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      expected.AppendLine($"{number:C2}");
      Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-Ru");
      expected.AppendLine($"{number:C2}");
      Thread.CurrentThread.CurrentCulture = currentThreadCurrentCulture;

      Assert.That(_stringWriter.ToString(), Is.EqualTo(expected.ToString()));
    }

    /// <summary>
    /// Method invokes after tests
    /// </summary>
    [TearDown]
    public void TearDown()
    {
      Console.SetOut(_originalOutput);
      _originalOutput.Dispose();
      _stringWriter.Dispose();
    }
  }
}
