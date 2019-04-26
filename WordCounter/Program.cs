using System;
using System.Collections.Generic;
using WordCounterModels;

namespace MainWordCounter
{
    public class Program
    {
        public static void Main()
        {
            bool isCounting = true;

            while(isCounting)
            {
            Console.WriteLine("Enter a word that you'd like to track: ");
            WordCounter counter = new WordCounter(Console.ReadLine());
            Console.WriteLine("Your are now tracking the word '"+ counter.GetTargetWord() + "'");
            Console.WriteLine("");
            Console.WriteLine("Enter a sentence you would like to scan for '" + counter.GetTargetWord() + "'");
            counter.ScanForTarget(Console.ReadLine());
            Console.WriteLine("The word '" + counter.GetTargetWord() + "' appeared in your sentence " + counter.GetTargetCount() + " times.");
            isCounting = false;
            }
        }
    }
}