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

    static void Main(string[] args)
    {
        Console.Write("Kérem adja meg az üzenetet(Csak kisbetüt vagy/és szóközt hasznájon!): ");
        string message = (Console.ReadLine());
        Console.Write("Kérem adja meg a kulcsot (Csak kisbetüt vagy/és szóközt hasznájon!): ");
        string key = (Console.ReadLine());

        string encryptmessage = Encrypt(message, key);
        Console.WriteLine("Rejtett üzenet: " + encryptmessage);
    }

}