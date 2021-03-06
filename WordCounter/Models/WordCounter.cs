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

        private int _counterId ;
        private static List<Counter> _counterList = new List<Counter> {};

        private static List<string> _targetWordList = new List<string> {};

        // private static Dictionary<string, List<Counter>> _wordBook= new Dictionary<string, List<Counter>>();

        //Constructor
        public Counter(string userWord, string userPhrase)
        {
            _targetWord = userWord;
            _targetPhrase = userPhrase;
            ScanForTarget();
            ScanForPlurals();
            ScanForPartials();
            // AddToDictionary();
            _counterList.Add(this);
            _counterId = _counterList.Count;
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

// Dictionary Sorting not worked out.  TODO: Put objects into dictionary with Key being unique
//Target words, and Value being a list of all objects with Key as _targetWord
        //Create new dictionary key/value pair for unique targetWords, or adds Counter object to the value matching it's targetWord/key
        // private void AddToDictionary()
        // {
        //     if(_wordBook.ContainsKey(_targetWord))
        //     {
        //         _wordBook[_targetWord].Add(this);
        //     }
        //     else
        //     {
        //         List<Counter> newList = new List<Counter> {this};
        //         _wordBook.Add(_targetWord, newList);
        //     }
        // }

        //Getter/Setters
        public string TargetWord { get => _targetWord; set => _targetWord = value;}
        public string TargetPhrase { get => _targetPhrase; set => _targetPhrase = value;}
        public int TargetCount { get => _targetCount; set => _targetCount = value;}
        public int PluralCount { get => _pluralCount; set => _pluralCount = value;}
        public int PartialCount { get => _partialCount; set => _partialCount = value;}

        public int GetId() => _counterId;

        //Scan Methods
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

        public static List<string> GetTargetWords()
        {
            return _targetWordList;
        }

        public static void ClearAll() => _counterList.Clear();

        public static Counter FindCounterById(int id)
        {
            return _counterList[id-1];
        }

        // public static Dictionary<string, List<Counter>> GetWordBook()
        // {
        //     return _wordBook;
        // }
    }
}
