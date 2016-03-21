using System;

namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveAtTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveElementOnEmptyDynamicList_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveElementGreaterThanDynamicListLength_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.RemoveAt(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveElementAtNegativePosition_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.RemoveAt(-2);
        }

        [TestMethod]
        public void RemoveAt_RemoveElementAtZeroPosition_ShouldRemoveTheElement()
        {
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.RemoveAt(0);
            Assert.AreEqual(2, dynamicList[0]);
        }

        [TestMethod]
        public void RemoveAt_RemoveElement_ShouldRemoveTheElementOnTheGivenPosition()
        {
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(4);
            dynamicList.Add(5);
            dynamicList.RemoveAt(2); //Remove 4
            Assert.AreEqual(5, dynamicList[2], "Check if the element and the given index match.");
        }
    }
}