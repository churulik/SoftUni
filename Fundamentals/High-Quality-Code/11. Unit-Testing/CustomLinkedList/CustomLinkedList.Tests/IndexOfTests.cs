namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexOfTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void IndexOf_OnEmptyList_ShouldReturnNegativeOne()
        {
            var indexOf = dynamicList.IndexOf(-4);
            Assert.AreEqual(-1, indexOf);
        }

        [TestMethod]
        public void IndexOf_NonExistingElement_ShouldReturnNegativeOne()
        {
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(-3);
            var indexOf = dynamicList.IndexOf(5);
            Assert.AreEqual(-1, indexOf);
        }

        [TestMethod]
        public void IndexOf_ExistingElement_ShouldReturnTheIndexOfTheElement()
        {
            dynamicList.Add(1002);
            dynamicList.Add(322);
            dynamicList.Add(-422);
            dynamicList.Add(22);
            var indexOf = dynamicList.IndexOf(-422);
            Assert.AreEqual(2, indexOf);
        }

       
    }
}