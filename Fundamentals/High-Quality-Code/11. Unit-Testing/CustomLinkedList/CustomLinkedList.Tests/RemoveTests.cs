namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveTests
    {
        private static DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void Remove_RemoveElementOnEmptyDynamicList_ShouldReturnNegativeOne()
        {
            var removeElement = dynamicList.Remove(0);
            Assert.AreEqual(-1, removeElement);
        }

        [TestMethod]
        public void Remove_RemoveElementOnNegativeIndex_ShouldReturnNegativeOne()
        {
            dynamicList.Add(23);
            var removeElement = dynamicList.Remove(-1);
            Assert.AreEqual(-1, removeElement);
        }

        [TestMethod]
        public void Remove_RemoveElementOnIndexGreaterThanDynamicListLength_ShouldReturnNegativeOne()
        {
            dynamicList.Add(23);
            dynamicList.Add(22);
            var removeElement = dynamicList.Remove(3);
            Assert.AreEqual(-1, removeElement);
        }

        [TestMethod]
        public void Remove_RemoveElement_ShouldReturnExpectedIndexOfTheRemovedElement()
        {
            dynamicList.Add(1);
            dynamicList.Add(20);
            dynamicList.Add(5);
            var removeElement = dynamicList.Remove(20); //The index of the removed element (20) is 1
            Assert.AreEqual(1, removeElement);
        }

        [TestMethod]
        public void Remove_RemoveElementOnDynamicListWithOneElement_ShouldReturnCountZero()
        {
            dynamicList.Add(3);
            dynamicList.Remove(3);
            Assert.AreEqual(0, dynamicList.Count);
        }

        [TestMethod]
        public void Remove_RemoveFirstAndLastElementsInDynamicListWithLengttThree_ShouldReturnCountOne()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(7);
            dynamicList.Remove(3);
            dynamicList.Remove(7);
            Assert.AreEqual(1, dynamicList.Count);
        }

        [TestMethod]
        public void Remove_RemoveFirstAndSecondLastElementsInDynamicListWithLengttFour_ShouldReturnCountTwo()
        {
            dynamicList.Add(3);
            dynamicList.Add(5);
            dynamicList.Add(7);
            dynamicList.Add(10);
            dynamicList.Remove(3);
            dynamicList.Remove(7);
            Assert.AreEqual(2, dynamicList.Count);
        }
    }
}