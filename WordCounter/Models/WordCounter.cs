using System;
using System.Collections.Generic;

namespace WordCounterModels
{
    public class WordCounter
    {
        private string _targetWord;
        private int _targetCount = 0;

        public WordCounter (string userInput)
        {
            _targetWord = userInput;
        }

        public bool IsTargetValid(string userInput)
        {
            if(typeof(string) == userInput.GetType())
            {
                return true;
            }
            return false;
        }

        public string GetTargetWord()
        {
            return _targetWord;
        }

        public int GetTargetCount()
        {
            return _targetCount;
        }

        public void SetTargetWord(string newTargetWord)
        {
            _targetWord = newTargetWord;
        }

        public void ScanForTarget(string userString)
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
        }
    }
}