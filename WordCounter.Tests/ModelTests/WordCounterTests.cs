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
    }
}