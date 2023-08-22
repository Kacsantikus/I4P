using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        List<string> wordList = GetEnglishWordList();
    }

    static List<string> GetEnglishWordList()
    {
        List<string> wordList = new List<string>();

        string[] words = File.ReadAllLines("words.txt");

        for (int i = 0; i < words.Length; i++)
        {
            wordList.Add(words[i]);
        }

        return wordList;
    }
}