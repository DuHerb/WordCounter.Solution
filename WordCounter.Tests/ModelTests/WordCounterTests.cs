using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Models;
using System;
using System.Collections.Generic;

namespace WordCounter.Tests
{
    [TestClass]
    public class WordCounter
    {
        [TestMethod]
        public void WordCounterConstructor_CreateObjectInstance_WordCounter()
        {
            WordCounter newWordCounter = new WordCounter();
            Assert.AreEqual(typeof(WordCounter), newWordCounter.GetType());
        }
    }
}