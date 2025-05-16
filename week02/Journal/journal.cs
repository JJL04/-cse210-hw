using System.Text.Json;

namespace JournalProgram
{
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

}