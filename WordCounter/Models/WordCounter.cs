using System;
using System.Collections.Generic;

namespace WordCounterModels
{
    public class WordCounter
    {
        private string _targetWord;
        private int _targetCount;

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

        public int ScanForTarget(string userString)
        {
            string stringToScan = userString;
            string[] scanArray = stringToScan.Split(' ');

            foreach(String word in scanArray)
            {
                if(word == _targetWord)
                {
                    _targetCount ++;
                }
            }
            return _targetCount;
        }
    }
}