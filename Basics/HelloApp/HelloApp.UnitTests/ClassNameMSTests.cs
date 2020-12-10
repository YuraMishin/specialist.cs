using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloApp.UnitTests
{
    [TestClass]
    public class ClassNameMSTests
    {
        [TestMethod]
        public void DoSmthBy_UserIsAdmin_ReturnsTrue()
        {
            var result = true;
            
            Assert.IsTrue(result);
            Assert.IsFalse(!result);
        }
    }
}
