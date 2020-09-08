using NUnit.Framework;

namespace Euclid.UnitTests
{
    /// <summary>
    /// Class tests Program class
    /// </summary>
    [TestFixture]
    public class ProgramNUnitTests
    {
        /// <summary>
        /// Tests Gcd() method
        /// </summary>
        [Test]
        public void Gcd_When1071And462_Returns21()
        {
            var expected = 21;
            var actual = Program.Gcd(1071, 462);

            Assert.That(actual, Is.EqualTo(expected));
        }
        /// <summary>
        /// Tests Gcd() method
        /// </summary>
        [Test]
        public void Gcd_When462And1071_Returns21()
        {
            var expected = 21;
            var actual = Program.Gcd(462, 1071);

            Assert.That(actual, Is.EqualTo(expected));
        }
        /// <summary>
        /// Tests Gcd() method
        /// </summary>
        [TestCase(1071, 462, 21)]
        [TestCase(462, 1071, 21)]
        public void Gcd_TestCase1_ReturnsTrue(int a, int b, int result)
        {
            var actual = Program.Gcd(a, b);

            Assert.That(actual, Is.EqualTo(result));
        }
        /// <summary>
        /// Tests Gcd() method
        /// </summary>
        [TestCase(new int[] { 462, 1071, 42 }, 21)]
        public void Gcd_TestCase2_ReturnsTrue(int[] ints, int result)
        {
            var actual = Program.Gcd(ints);

            Assert.That(actual, Is.EqualTo(result));
        }
    }
}
