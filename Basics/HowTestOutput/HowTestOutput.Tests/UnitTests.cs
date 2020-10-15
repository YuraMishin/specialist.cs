using NUnit.Framework;
using System;
using System.IO;

namespace HowTestOutput.Tests
{
  /// <summary>
  /// Class Tests.
  /// Shows how test console output
  /// </summary>
  [TestFixture]
  public class Tests
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
    /// Tests console output
    /// </summary>
    [Test]
    [TestCase("Hello!")]
    public void MethodName_Condition_Result(string expected)
    {
      Console.Write(expected);

      Assert.That(_stringWriter.ToString(), Is.EqualTo(expected));
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
