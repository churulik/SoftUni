namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void Add_AddAnElement_ShouldReturnExpectedElement()
        {
            dynamicList.Add(1);
            Assert.AreEqual(1, dynamicList[0], "Check the value ot the tested element.");
        }

        [TestMethod]
        public void Add_AddSeveralElement_ShouldReturnExpectedElements()
        {
            dynamicList.Add(-1);
            dynamicList.Add(5);
            dynamicList.Add(10);
            Assert.AreEqual(-1, dynamicList[0]);
            Assert.AreEqual(5, dynamicList[1]);
            Assert.AreEqual(10, dynamicList[2]);
        }
    }
}
