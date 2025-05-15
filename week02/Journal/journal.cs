using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Entry
{
    public string Text { get; set; }
    public string Prompt { get; set; }
    public DateTime Date { get; set; }

    public Entry() { }  // Parameterless constructor needed for deserialization

    public Entry(string text, string prompt, DateTime date)
    {
        Text = text;
        Prompt = prompt;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nEntry: {Text}\n";
    }
}

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private static List<string> prompts = new List<string>
    {
        "What did you learn today?",
        "What are you grateful for?",
        "Describe your day in one word.",
        "What are your goals for tomorrow?",
        "What challenges did you face today?"
    };

    private static Random random = new Random();

    public void AddEntry(string text, string prompt)
    {
        var date = DateTime.Now;
        var newEntry = new Entry(text, prompt, date);
        entries.Add(newEntry);
        Console.WriteLine("Entry added successfully.");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(new string('-', 20));
        }
    }

    public void Save(string filename = "journal_data.json")
    {
        try
        {
            var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void Load(string filename = "journal_data.json")
    {
        if (File.Exists(filename))
        {
            try
            {
                var json = File.ReadAllText(filename);
                var loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

                if (loadedEntries != null)
                {
                    entries = loadedEntries;
                    Console.WriteLine("Journal loaded.");
                }
                else
                {
                    Console.WriteLine("No entries found in the loaded journal.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No journal file found.");
        }
    }

    public string GetRandomPrompt()
    {
        return prompts[random.Next(prompts.Count)];
    }
}

public class Program
{
    public static void Main()
    {
        var journal = new Journal();
        journal.Load();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add journal entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            var choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    string prompt = journal.GetRandomPrompt();
                    Console.Write($"Your prompt: {prompt}\nYour entry: ");
                    var entryText = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(entryText))
                    {
                        journal.AddEntry(entryText, prompt);
                    }
                    else
                    {
                        Console.WriteLine("Entry cannot be empty.");
                    }
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
