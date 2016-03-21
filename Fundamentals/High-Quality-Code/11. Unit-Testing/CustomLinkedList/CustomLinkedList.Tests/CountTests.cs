using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Tests
{
    [TestClass]
    public class CountTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void Count_GetCountOnEmptyDynamicList_ShouldReturnZero()
        {
            Assert.AreEqual(0, dynamicList.Count);
        }

        [TestMethod]
        public void Count_GetCountOnNonEmptyDynamicList_ShouldReturnExpectedCount()
        {
            
            dynamicList.Add(24);
            dynamicList.Add(-3);
            dynamicList.Add(4);
            Assert.AreEqual(3, dynamicList.Count);
        }
    }
}
