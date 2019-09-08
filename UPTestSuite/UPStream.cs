using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalProcessor;
using System.IO;
using System.Text;

namespace UPTestSuite
{
    [TestClass]
    public class UPStream
    {
        [TestMethod]
        public void CanProcessStreamg()
        {
            string x = "on the road again";
            byte[] bytes = Encoding.UTF8.GetBytes(x);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                SelfDescribingData data = ProcessorAPI.Describe(ms);
                Assert.IsNotNull(data);
            }
        }
    }
}
