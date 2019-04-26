using System;
using System.Collections.Generic;

namespace WordCounterModels
{
    public class WordCounter
    {
        private string _targetWord;

        public WordCounter (string userInput)
        {
            _targetWord = userInput;
        }

        public string GetTargetWord()
        {
            return _targetWord;
        }

        public void SetTargetWord(string newTargetWord)
        {
            _targetWord = newTargetWord;
        }
    }
}