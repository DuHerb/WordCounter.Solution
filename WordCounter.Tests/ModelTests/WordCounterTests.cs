using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounterModels;
using System;
using System.Collections.Generic;

namespace WordCounterTests
{
        [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void WordCounterConstructor_CreateObjectInstance_WordCounter()
        {
            WordCounter newWordCounter = new WordCounter("test");
            Assert.AreEqual(typeof(WordCounter), newWordCounter.GetType());
        }
         [TestMethod]
        public void GetTargetWord_ReturnsTargetWord_String()
        {
            string targetWord = "cat";
            WordCounter newWordCounter = new WordCounter("cat");

            string result = newWordCounter.GetTargetWord();

            Assert.AreEqual(targetWord, result);
        }

        [TestMethod]
        public void SetTargetWord_SetTargetWord_String()
        {
            string oldTarget = "cat";
            string newTarget = "dog";
            WordCounter newCounter = new WordCounter(oldTarget);

            newCounter.SetTargetWord(newTarget);
            string result = newCounter.GetTargetWord();

            Assert.AreEqual(newTarget, result);
        }

        [TestMethod]
        public void ScanForTarget_ScanStringForTargetWord_Int()
        {
            string targetWord = "dog";
            string stringToScan = "I own a dog";
            WordCounter newCounter = new WordCounter(targetWord);
            int expected = 1;

            newCounter.ScanForTarget(stringToScan);
            int result = newCounter.GetTargetCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTargetCount_ReturnTargetCount_Int()
        {
            string targetWord = "dog";
            WordCounter newCounter = new WordCounter(targetWord);
            int expected = 0;

            int result = newCounter.GetTargetCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTargetValid_CheckIfTargetWordIsAString_True()
        {
            string userTarget = "dog";
            bool expected = true;
            WordCounter newCounter = new WordCounter(userTarget);

            bool result = newCounter.IsTargetValid(userTarget);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ScanForPlurals_ScanForPluralInstancesOfTarget_int()
        {
            string targetWord = "dog";
            string stringToScan = "My dog owns several dogs that love hot dogs";
            WordCounter newCounter = new WordCounter(targetWord);
            int expected = 2;

            newCounter.ScanForPlurals(stringToScan);
            int result = newCounter.GetPluralCount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPluralCount_ReturnNumberOfPluralTarget_int()
        {
            string targetWord = "dog";
            WordCounter newCounter = new WordCounter(targetWord);
            int expected = 0;

            int result = newCounter.GetPluralCount();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPartialCount_ReturnNumberOfPartialMatches_int()
        {
            string targetWord = "dog";
            WordCounter newCounter = new WordCounter(targetWord);
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
            WordCounter newCounter = new WordCounter(targetWord);

            List<string> returnedList = newCounter.ScanForPartials(stringToScan);
            CollectionAssert.AreEqual(expectedList, returnedList);
        }
    }
}