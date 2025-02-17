using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to encrypt:");
            string input = Console.ReadLine();

            try
            {
                string encryptedString = EncryptString(input);
            }
            catch (Exception e)
            {
                  Console.Write(e.ToString());
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string EncryptString(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException(nameof(inputString), "inputString may not be null or empty");
            }
            // Guard clause to check if input is a valid string
            
            // Reverse the string
            char[] chars = inputString.ToCharArray();
            Array.Reverse(chars);

            // Convert every second charatcer to uppercase
            
            for (int i = 0; i<chars.Length; i++)
            {
                if (i % 2 ==0)
                {
                    chars[i] = Char.ToUpper(chars[i]);
                }

            }
            string reversedString = String.Join("", chars);
            Console.WriteLine(reversedString);

            // Interpolateion and concatenation
            string completeString = "Secret-" + reversedString + "-Code";

            char[] chars2 = completeString.ToCharArray();
            char[] newChars2 = new char[chars2.Length];
            for (int i = 0; i < chars2.Length; i++)
            {
                char c = chars2[i];
                int ascii = (int)c;
                ascii += 1;
                char newChar = (char)ascii;
                newChars2[i] = (newChar);
            }

            // String conversion using ASCII values to shift each character by 1
            string reversedString2 = String.Join("", newChars2);
            return reversedString2;
        }
    }
}
