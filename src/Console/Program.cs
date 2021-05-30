using System;
using System.Collections.Generic;
using System.Text.Json;
using AtomicCipher.Models;
using Spectre.Console;

namespace AtomicCipher
{
   class Program
   {
      //========== Private Properties

      static void Main(string[] args)
      {
         string message = "X";

         while (!string.IsNullOrEmpty(message))
         {
            AnsiConsole.Write("What's the message you want to convert?");
            message = Console.ReadLine();

            if (!string.IsNullOrEmpty(message))
            {
               string encrypted = Cipher.EncryptMessage(message);
               AnsiConsole.WriteLine(encrypted);
               AnsiConsole.WriteLine(Cipher.DecryptMessage(encrypted));
            }
         }

      }
   }
}