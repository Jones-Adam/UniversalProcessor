using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalProcessor;

namespace UPTestSuite
{
    [TestClass]
    public class UPSetup
    {
        [TestMethod]
        public void ProcessorSetup()
        {
            Assert.IsTrue(ProcessorAPI.ProcessorCount > 0);
        }
    }
}
