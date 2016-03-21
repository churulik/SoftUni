namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContainsTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void Contains_OnNonExistingElement_ShouldReturnFalse()
        {
            dynamicList.Add(1);
            var contains = dynamicList.Contains(2);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Contains_OnExistingElement_ShouldReturnTrue()
        {
            dynamicList.Add(1);
            dynamicList.Add(4);
            var contains = dynamicList.Contains(1);
            Assert.IsTrue(contains);
        }
    }
}