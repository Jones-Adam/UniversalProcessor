using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalProcessor;
using System.IO;

namespace UPTestSuite
{
    [TestClass]
    public class UPFileStream
    {
        [TestMethod]
        public void CanProcessFileStream()
        {
            using (FileStream fs = File.Open("d:\\temp\\UPTestFile.txt", FileMode.Open))
            {
                SelfDescribingData data = ProcessorAPI.Describe(fs);
                Assert.IsNotNull(data);
            }

        }
    }
}
