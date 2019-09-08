using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalProcessor;
using UniversalProcessor.SDD.Common;

namespace UPTestSuite
{
    [TestClass]
    public class UPStrings
    {
        [TestMethod]
        public void CanProcessString()
        {
            SelfDescribingData data = ProcessorAPI.Describe("On the road again");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void StringCorrectSSD()
        {
            SelfDescribingData data = ProcessorAPI.Describe("On the road again");
            var dataview = data.GetViewOfType(CommonDefinitions.SDDString);
            Assert.IsTrue(dataview.Identifier == CommonDefinitions.SDDString);
        }

        [TestMethod]
        public void StringAbilities_ViewCount()
        {
            SelfDescribingData data = ProcessorAPI.Describe("On the road again");
            Assert.IsTrue(data.ViewCount == 3);
        }

        [TestMethod]
        public void StringWholeStringProperty_Length()
        {
            SelfDescribingData data = ProcessorAPI.Describe("On the road again");
            var dataview = data.GetViewOfType(CommonDefinitions.SDDString);
            SelfDescribingData stringLength = dataview.GetProperty(0);
            Assert.IsTrue(stringLength.GetViewDefinition(0).Identifier == CommonDefinitions.SDDInteger);
            Assert.IsTrue(stringLength.GetViewDefinition(0).DisplayValue() == "17");
            Assert.IsTrue((int)stringLength.SourceData == 17);
        }
    }
}
