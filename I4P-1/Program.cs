using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static string Encrypt(string message, string key)
    {
        string encryptmessage = "";

        for (int i = 0; i < message.Length; i++)
        {
            char messageletter = message[i];
            char keyletter = key[i % key.Length];

            int messagecode = (messageletter == ' ') ? 26 : messageletter - 'a';
            int keycode = (keyletter == ' ') ? 26 : keyletter - 'a';

            int encryptlettercode = (messagecode + keycode) % 27;
            char encryptletter = (encryptlettercode == 26) ? ' ' : (char)(encryptlettercode + 'a');

            encryptmessage += encryptletter;
        }

        return encryptmessage;
    }

    static string Solver(string encryptedmessage, string key)
    {
        string solvedmessage = "";

        for (int i = 0; i < encryptedmessage.Length; i++)
        {
            char encryptedletter = encryptedmessage[i];
            char keyletter = key[i % key.Length];

            int encryptedlettercode = (encryptedletter == ' ') ? 26 : encryptedletter - 'a';
            int keyCode = (keyletter == ' ') ? 26 : keyletter - 'a';

            int solvedCharCode = (encryptedlettercode - keyCode + 27) % 27;
            char solvedChar = (solvedCharCode == 26) ? ' ' : (char)(solvedCharCode + 'a');

            solvedmessage += solvedChar;
        }

        return solvedmessage;
    }

    static void Main(string[] args)
    {
        Console.Write("Kérem adja meg az üzenetet(Csak kisbetüt vagy/és szóközt hasznájon!): ");
        string message = (Console.ReadLine());
        Console.Write("Kérem adja meg a kulcsot (Csak kisbetüt vagy/és szóközt hasznájon!): ");
        string key = (Console.ReadLine());

        string encryptmessage = Encrypt(message, key);
        Console.WriteLine("Rejtett üzenet: " + encryptmessage);

        string solvedmessage = Solver(encryptmessage, key);
        Console.WriteLine("Megfejtett üzenet: " + solvedmessage);
    }
}