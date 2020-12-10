using System.Diagnostics;
using NUnit.Framework;

namespace HelloApp.UnitTests
{
    [TestFixture]
    public class ClassNameNUnitTests
    {
        private int number;

        [SetUp]
        public void SetUp()
        {
            number = 1;
        }

        [Test]
        public void DoSmthBy_UserIsAdmin_ReturnsTrue()
        {
            var result = true;
            var resultString = "test string";
            var numbers = new int[] {1, 2, 3};

            Assert.That(result, Is.True);
            Assert.That(3, Is.EqualTo(3).IgnoreCase);
            Assert.That(resultString, Does.StartWith("test"));
            Assert.That(resultString, Does.EndWith("string"));
            Assert.That(resultString, Does.Contain("te"));

            Assert.That(numbers, Is.Not.Empty);
            Assert.That(numbers.Length, Is.EqualTo(3));
            Assert.That(numbers, Does.Contain(1));
            Assert.That(numbers, Is.EquivalentTo(new int[] {1, 2, 3}));
            Assert.That(numbers, Is.Ordered);
            Assert.That(numbers, Is.Unique);
          //  Assert.That(numbers, Is.TypeOf());
          // Assert.That(numbers, Is.InstanceOf());
          // Assert.That(()=> 1/0, Throws.Exception);

        }

        [Test]
        [Ignore("Why?")]
        [TestCase(1)]
        public void DoSmth2By_UserIsAdmin_ReturnsTrue(int a)
        {
            var result = true;

            Assert.That(1, Is.EqualTo(a));
        }
    }
}