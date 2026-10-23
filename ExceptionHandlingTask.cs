using System;
using System.Collections.Generic;

namespace ExceptionHandlingTask
{
    class Program
    {
        // 1. دالة تفحص التكرار في قائمة الأرقام
        public static void CheckForDuplicates(List<int> numbers)
        {
            HashSet<int> seenNumbers = new HashSet<int>();

            foreach (int num in numbers)
            {
                if (seenNumbers.Contains(num))
                {
                    // إطلاق استثناء عند وجود رقم مكرر
                    throw new Exception($"Duplicate number found: {num}");
                }
                seenNumbers.Add(num);
            }
            Console.WriteLine("No duplicates found in the list.");
        }

        // 2. دالة تفحص وجود حروف متحركة في النص
        public static void CheckForVowels(string input)
        {
            string vowels = "aeiouAEIOU";
            bool hasVowel = false;

            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                    hasVowel = true;
                    break;
                }
            }

            if (!hasVowel)
            {
                // إطلاق استثناء لو مفيش ولا حرف متحرك
                throw new Exception("The string does not contain any vowels.");
            }

            Console.WriteLine($"The string '{input}' contains vowels.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Duplicate Numbers Check ---");
            try
            {
                List<int> myNumbers = new List<int> { 1, 2, 3, 4, 2 }; // فيه رقم 2 مكرر
                CheckForDuplicates(myNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Testing Vowels Check ---");
            try
            {
                string text = "fly"; // كلمة مفيهاش حروف متحركة
                CheckForVowels(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
