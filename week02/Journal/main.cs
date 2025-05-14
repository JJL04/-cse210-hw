using System;

namespace JournalProgram
{
    class Program
    {
        static void Main()
        {
            Journal journal = new Journal();
            journal.Load("journal_data.json");  // Load the journal from the specified file

            while (true)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Add journal entry");
                Console.WriteLine("2. Display journal entries");
                Console.WriteLine("3. Save journal");
                Console.WriteLine("4. Load journal");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = journal.GetRandomPrompt();
                        Console.WriteLine($"\nYour prompt: {prompt}");
                        Console.Write("Your entry: ");
                        string entryText = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(entryText))
                        {
                            journal.AddEntry(entryText, prompt);
                            Console.WriteLine("Entry added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Entry cannot be empty. Please try again.");
                        }
                        break;

                    case "2":
                        journal.DisplayEntries();
                        break;

                    case "3":
                        journal.Save("journal_data.json");  // Save the journal to the specified file
                        break;

                    case "4":
                        journal.Load("journal_data.json");  // Load the journal from the specified file
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
