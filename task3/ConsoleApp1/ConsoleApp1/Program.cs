using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "alphabet", "алфавит" },
                { "bread", "хлеб" },
                { "cat", "кот" },
                { "dog", "собака" },
                { "elephant", "слон" },
                { "fire", "огонь" },
                { "government", "правительство" },
                { "helicopter", "вертолёт" },
                { "icecream", "мороженое" },
                { "joke", "шутка" },
            };
            Console.WriteLine("Input word you want to translate:");
            string word = Console.ReadLine().ToLower();
            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine($"{dictionary[word]}");
            }
            else
            {
                Console.WriteLine("There is no this word in our dictionary. Sorry, bro :(");
            }
            Console.ReadKey();
        }
    }
}
