using System;

namespace ScriptureMemorizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string scriptureText = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

            Scripture scripture = new Scripture(reference, scriptureText);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Well done!");
                    break;
                }

                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                }

                scripture.HideRandomWords(3);
            }
        }
    }
}
