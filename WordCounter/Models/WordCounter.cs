using System;
using System.Collections.Generic;

namespace WordCounter.Models
{
    public class Counter
    {
        private string _targetWord;
        private string _targetPhrase;
        private int _targetCount = 0;
        private int _pluralCount = 0;
        private int _partialCount = 0;
        private static List<Counter> _counterList = new List<Counter> {};

        //Constructor
        public Counter(string userWord, string userPhrase)
        {
            _targetWord = userWord;
            _targetPhrase = userPhrase;
            ScanForTarget();
            ScanForPlurals();
            ScanForPartials();
            _counterList.Add(this);
        }

        //Validate input data type
        public bool IsValidData(string userInput)
        {
            if(typeof(string) == userInput.GetType())
            {
                return true;
            }
            return false;
        }

        //Getter/Setters
        public string TargetWord { get => _targetWord; set => _targetWord = value;}
        public string TargetPhrase { get => _targetPhrase; set => _targetPhrase = value;}
        public int TargetCount { get => _targetCount; set => _targetCount = value;}
        public int PluralCount { get => _pluralCount; set => _pluralCount = value;}
        public int PartialCount { get => _partialCount; set => _partialCount = value;}

        public void ScanForTarget()
        {
            // string phraseToScan = _targetPhrase;
            string[] arrayToScan = _targetPhrase.Split(' ');

            foreach(String word in arrayToScan)
            {
                if(word == _targetWord)
                {
                    _targetCount ++;
                }
            }
        }

        //Scan Methods
        public void ScanForPlurals()
        {
            // string phraseToScan = _targetPhrase;
            string[] arrayToScan = _targetPhrase.Split(' ');

            foreach(String word in arrayToScan)
            {
                if(word == _targetWord + "s")
                {
                    _pluralCount ++;
                }
            }
        }

        public void ScanForPartials()
        {
            // string phraseToScan = _targetPhrase;
            string[] arrayToScan = _targetPhrase.Split(' ');
            List<string> partialMatches = new List<string> {};

            foreach(String word in arrayToScan)
            {
                if(word.Contains(_targetWord) && word != _targetWord && word != _targetWord + "s")
                {
                    partialMatches.Add(word);
                    _partialCount ++;
                }
            }
        }

        //Static Methods
        public static List<Counter> GetAll()
        {
            return _counterList;
        }

        public static void ClearAll() => _counterList.Clear();
    }
}