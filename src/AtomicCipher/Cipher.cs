using System;
using System.Collections.Generic;
using System.Linq;
using AtomicCipher.Models;

namespace AtomicCipher
{
   public static class Cipher
   {
      private static Random _rand= new Random();

      public static string EncryptMessage(string message) =>
         message
            .ToUpper()
            .Select(l => l switch
               {
                  'J' => ConvertCharacter("G"),
                  'Q' => ConvertCharacter("K") + ConvertCharacter("W"),
                  (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') => ConvertCharacter(l.ToString()),
                  _ => l.ToString()
               })
            .Aggregate("", (i, j) => i + j);

      public static string DecryptMessage(string encryptedMessage)
      {
         string[] segmentedMessage = BreakdownEncryptedMessage(encryptedMessage);

         return segmentedMessage.Aggregate("", (i, j) => i + DeconvertCharacter(j));
      }



      private static string ConvertCharacter(string l)
      {
         // Get a list of elements that match the letter.
         var possibleElements = Elements.GetElementsBySymbolSearch(l);

         if (possibleElements.Count() > 0)
         {
            Element element = possibleElements[_rand.Next(0, possibleElements.Count())];

            string id = new String('!', element.Symbol.ToUpper().IndexOf(l) + 1);
            id += element.Number.ToString();

            return id;
         }
         return "@";
      }

      private static string DeconvertCharacter(string c)
      {
         int location = c.Count(e => e == '!');
         ushort atomicNumber;
         if (location == 0 || !ushort.TryParse(c.TrimStart('!'), out atomicNumber))
            return c;
         
         Element element = Elements.GetElementByNumber(atomicNumber);

         return element.Symbol[location - 1].ToString();
      }


      private static string[] BreakdownEncryptedMessage(string message)
      {
         List<string> segmentedMessage = new();

         int sequenceStart = 0;

         for (int i = 1; i < message.Length; i++)
         {
            char currentCharacter = message[i];
            char previousCharacter = message[i - 1];

            if (currentCharacter != '!')
            {
               if (!int.TryParse(message[i].ToString(), out int k))
               {
                  segmentedMessage.Add(message.Substring(sequenceStart, i - sequenceStart));
                  sequenceStart = i;
               }
            }

            if (currentCharacter == '!' && previousCharacter != '!')
            {
               segmentedMessage.Add(message.Substring(sequenceStart, i - sequenceStart));
               sequenceStart = i;
            }

            if (i == message.Length - 1)
            {
               segmentedMessage.Add(message.Substring(sequenceStart, i - sequenceStart + 1));
            }
         }

         if (segmentedMessage.Count == 0)
            segmentedMessage.Add(message);

         return segmentedMessage.ToArray();
      }
   }
}