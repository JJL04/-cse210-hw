namespace JournalProgram
{
    public class Program
    {
        public static void Main()
        {
            var journal = new Journal();
            journal.Load();
            while (true)
            {
                Console.WriteLine("1. Add journal entry");
                Console.WriteLine("2. Display journal entries");
                Console.WriteLine("3. Save journal");
                Console.WriteLine("4. Load journal");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        string prompt = journal.GetRandomPrompt();
                        Console.Write($"Your prompt: {prompt}\nYour entry: ");
                        var entryText = Console.ReadLine();
                        journal.AddEntry(entryText, prompt);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        journal.Save();
                        break;
                    case "4":
                        journal.Load();
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
