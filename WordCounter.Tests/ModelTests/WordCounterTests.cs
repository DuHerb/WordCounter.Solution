using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Models;
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
            Counter newCounter = new Counter("testWord", "testPhrase");
            Assert.AreEqual(typeof(Counter), newCounter.GetType());
        }

         [TestMethod]
        public void GetTargetWord_ReturnsTargetWord_String()
        {
            string targetWord = "cat";
            string targetPhrase = "I own one cat";
            Counter newCounter = new Counter("cat", targetPhrase);

            string result = newCounter.TargetWord;

            Assert.AreEqual(targetWord, result);
        }

        [TestMethod]
        public void ScanForTarget_ScanStringForTargetWord_Int()
        {
            string targetWord = "dog";
            string stringToScan = "I own a dog";
            Counter newCounter = new Counter(targetWord, stringToScan);
            int expected = 1;

            // newCounter.ScanForTarget();
            int result = newCounter.TargetCount;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTargetCount_ReturnTargetCount_Int()
        {
            string targetWord = "dog";
            string targetPhrase = "i own a dog";
            Counter newCounter = new Counter(targetWord, targetPhrase);
            int expected = 1;

            int result = newCounter.TargetCount;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTargetValid_CheckIfTargetWordIsAString_True()
        {
            string userTarget = "dog";
            string userPhrase = "i own dog";
            bool expected = true;
            Counter newCounter = new Counter(userTarget, userPhrase);

            bool result = newCounter.IsValidData(userTarget);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ScanForPlurals_ScanForPluralInstancesOfTarget_int()
        {
            string targetWord = "dog";
            string targetPhrase = "My dog owns several dogs that love hot dogs";
            Counter newCounter = new Counter(targetWord, targetPhrase);
            int expected = 2;

            // newCounter.ScanForPlurals();
            int result = newCounter.PluralCount;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPluralCount_ReturnNumberOfPluralTarget_int()
        {
            string targetWord = "dog";
            string targetPhrase = "My cat is rude";
            Counter newCounter = new Counter(targetWord, targetPhrase);
            int expected = 0;

            int result = newCounter.PluralCount;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPartialCount_ReturnNumberOfPartialMatches_int()
        {
            string targetWord = "dog";
            string targetPhrase = "My cat is rude";
            Counter newCounter = new Counter(targetWord, targetPhrase);
            int expected = 0;

            int result = newCounter.PartialCount;
            Assert.AreEqual(expected, result);
        }

        //Function ScanForPartials no longer returns a List object
        // [TestMethod]
        // public void ScanForPartials_ReturnListofPartialTargetMatches_Int()
        // {
        //     string targetWord = "dog";
        //     string targetPhrase = "doggies like dogtreats shaped like dogs";
        //     List<string> expectedList = new List<string> { "doggies", "dogtreats" };
        //     Counter newCounter = new Counter(targetWord, targetPhrase);

        //     List<string> returnedList = newCounter.ScanForPartials();
        //     CollectionAssert.AreEqual(expectedList, returnedList);
        // }

        [TestMethod]
        public void GetAll_ReturnsListOfCounters_List()
        {
            string targetWord1 = "cat";
            string targetWord2 = "dog";
            string targetPhrase = "I own one cat and one dog";
            Counter counter1 = new Counter(targetWord1, targetPhrase);
            Counter counter2 = new Counter(targetWord2, targetPhrase);

            List<Counter> expected = new List<Counter> { counter1, counter2};

            List<Counter> result = Counter.GetAll();
            CollectionAssert.AreEqual(expected, result);
        }

// Dictionary tests......Not Working as expected.  TODO: Rewrite tests
        // [TestMethod]
        // public void GetWordBook_ReturnDictionaryOfUniqueTargetWords_Dictionary()
        // {
        //     string targetWord = "cat";
        //     string targetPhrase = "i own a cat";
        //     Counter newCounter = new Counter(targetWord, targetPhrase);
        //     Dictionary<string, List<Counter>> result = Counter.GetWordBook();
        //     Assert.AreEqual(typeof(Dictionary<string, List<Counter>>), result.GetType());
        // }

        // public void AddToDictionary_AddUniqueTargetWordObjectsToWordBook_Dictionary()
        // {
        //     string targetWord = "cat";
        //     string targetPhrase = "i own a cat";
        //     string targetWord2 = "cat";
        //     string targetPhrase2 = "my cat wants me dead";
        //     Counter newCounter = new Counter(targetWord, targetPhrase);
        //     Counter newCounter2 = new Counter(targetWord2, targetPhrase2);
        //     List<Counter> newList = new List<Counter> {newCounter, newCounter2};
        //     Dictionary<string, List<Counter>> expected = new Dictionary<string, List<Counter>> { {"cat", newList }};
        //     Dictionary<string, List<Counter>> result = Counter.GetWordBook();
        //     CollectionAssert.AreEqual(expected, result);
        // }
    }
}