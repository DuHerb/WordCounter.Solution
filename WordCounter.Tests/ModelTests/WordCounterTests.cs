using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounterModels;
using System;
using System.Collections.Generic;

namespace WordCounterTests
{
        [TestClass]
    public class WordCounterTests : IDisposable
    {

        public void Dispose()
        {
            Counter.ClearAll();
        }

        [TestMethod]
        public void CounterConstructor_CreateObjectInstance_Counter()
        {
            Counter newCounter = new Counter("test");
            Assert.AreEqual(typeof(Counter), newCounter.GetType());
        }
         [TestMethod]
        public void GetTargetWord_ReturnsTargetWord_String()
        {
            string targetWord = "cat";
            Counter newCounter = new Counter("cat");

            string result = newCounter.GetTargetWord();

            Assert.AreEqual(targetWord, result);
        }

        [TestMethod]
        public void SetTargetWord_SetTargetWord_String()
        {
            string oldTarget = "cat";
            string newTarget = "dog";
            Counter newCounter = new Counter(oldTarget);

            newCounter.SetTargetWord(newTarget);
            string result = newCounter.GetTargetWord();

            Assert.AreEqual(newTarget, result);
        }

        [TestMethod]
        public void ScanForTarget_ScanStringForTargetWord_Int()
        {
            string targetWord = "dog";
            string stringToScan = "I own a dog";
            Counter newCounter = new Counter(targetWord);
            int expected = 1;

            newCounter.ScanForTarget(stringToScan);
            int result = newCounter.GetTargetCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTargetCount_ReturnTargetCount_Int()
        {
            string targetWord = "dog";
            Counter newCounter = new Counter(targetWord);
            int expected = 0;

            int result = newCounter.GetTargetCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTargetValid_CheckIfTargetWordIsAString_True()
        {
            string userTarget = "dog";
            bool expected = true;
            Counter newCounter = new Counter(userTarget);

            bool result = newCounter.IsTargetValid(userTarget);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ScanForPlurals_ScanForPluralInstancesOfTarget_int()
        {
            string targetWord = "dog";
            string stringToScan = "My dog owns several dogs that love hot dogs";
            Counter newCounter = new Counter(targetWord);
            int expected = 2;

            newCounter.ScanForPlurals(stringToScan);
            int result = newCounter.GetPluralCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPluralCount_ReturnNumberOfPluralTarget_int()
        {
            string targetWord = "dog";
            Counter newCounter = new Counter(targetWord);
            int expected = 0;

            int result = newCounter.GetPluralCount();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPartialCount_ReturnNumberOfPartialMatches_int()
        {
            string targetWord = "dog";
            Counter newCounter = new Counter(targetWord);
            int expected = 0;

            int result = newCounter.GetPartialCount();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ScanForPartials_ReturnListofPartialTargetMatches_List()
        {
            string targetWord = "dog";
            string stringToScan = "doggies like dogtreats shaped like dogs";
            List<string> expectedList = new List<string> { "doggies", "dogtreats" };
            Counter newCounter = new Counter(targetWord);

            List<string> returnedList = newCounter.ScanForPartials(stringToScan);
            CollectionAssert.AreEqual(expectedList, returnedList);
        }

        [TestMethod]
        public void GetAll_ReturnsListOfCounters_List()
        {
            string targetWord1 = "cat";
            string targetWord2 = "dog";
            Counter counter1 = new Counter(targetWord1);
            Counter counter2 = new Counter(targetWord2);

            List<Counter> expected = new List<Counter> { counter1, counter2};

            List<Counter> result = Counter.GetAll();
            CollectionAssert.AreEqual(expected, result);
        }
    }
}