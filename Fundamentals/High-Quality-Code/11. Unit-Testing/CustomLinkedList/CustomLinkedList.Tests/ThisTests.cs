namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ThisTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_GetElementOnEmptyDynamicList_ShouldThorwArgumentOutOfRangeException()
        {
            var emptyList = dynamicList[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_GetNegativeElementOnEmptyDynamicList_ShouldThorwArgumentOutOfRangeException()
        {
            var negativeIndex = dynamicList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_GetElementGreaterThanDynamicListLength_ShouldThorwArgumentOutOfRangeException()
        {
            dynamicList.Add(5);
            dynamicList.Add(2);
            dynamicList.Add(3);
            var emptyList = dynamicList[4];
        }

        [TestMethod]
        public void This_GetAnElement_ShouldReturnExpectedElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(20);
            var elementAtIndex = dynamicList[1];
            Assert.AreEqual(20, elementAtIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_SetAnElementOnEmptyDynamicList_ShouldThorwArgumentOutOfRangeException()
        {
            dynamicList[0] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_SetAnElementOnNegativeIndex_ShouldThorwArgumentOutOfRangeException()
        {
            dynamicList[-1] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void This_SetAnElementOnIndexGreaterThanDynmicListLength_ShouldThorwArgumentOutOfRangeException()
        {
            dynamicList.Add(10);
            dynamicList.Add(20);
            dynamicList.Add(31);
            dynamicList[4] = 10;
        }

        [TestMethod]
        public void This_SetAnElement_ShouldReturnExpectedElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(20);
            dynamicList[1] = 40;
            Assert.AreEqual(40, dynamicList[1], "The element value is not the expected one.");
        }
    }
}