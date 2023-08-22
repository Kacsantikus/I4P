using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<string> wordList = GetEnglishWordList();
        string encryptedMessage1 = "curiosity killed the cat";
        string encryptedMessage2 = "early bird catches the worm";

        List<string> possibleKeys = FindPossibleKeys(encryptedMessage1, encryptedMessage2, wordList);

        Console.WriteLine("Lehetséges kulcsok:");
        foreach (string key in possibleKeys)
        {
            Console.WriteLine(key);
        }
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

    static List<string> FindPossibleKeys(string encryptedMessage1, string encryptedMessage2, List<string> wordList)
    {
        List<string> possibleKeys = new List<string>();

        // Az első üzenetből és a megadott kezdeti szóból kiszámoljuk a lehetséges kulcsdarabot
        string partialKey = CalculatePartialKey(encryptedMessage1, "early ", encryptedMessage2);

        // Az így kapott kulcsdarabot használva végigmegyünk a szólistán és próbálkozunk a kulcs kiegészítésével
        foreach (string word in wordList)
        {
            string fullKey = partialKey + word;

            //Még ide kellene a próbálkozás ellenőrzése ??

            possibleKeys.Add(fullKey);
        }

        return possibleKeys;
    }

    static string CalculatePartialKey(string encryptedMessage, string knownStart, string secondMessage)
    {
        string partialKey = "";

        for (int i = 0; i < knownStart.Length; i++)
        {
            if (encryptedMessage[i] != ' ')
            {
                // https://www.tutorialspoint.com/csharp/csharp_bitwise_operators.htm
                // c ^ e ^ e
                // 63  65  65
                // 00111111
                // 01000001
                // 01000001
                // 01111110 = 126
                char keyChar = (char)((encryptedMessage[i] ^ knownStart[i] ^ secondMessage[i]));
                partialKey += keyChar;
            }
            else
            {
                partialKey += " ";
            }
        }

        return partialKey;
    }

}