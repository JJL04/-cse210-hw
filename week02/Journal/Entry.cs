namespace JournalProgram
{
    [Serializable]  // Ensures that the class can be serialized for saving and loading
    public class Entry
    {
        // Properties to hold journal entry data
        public string Text { get; set; }
        public string Prompt { get; set; }
        public DateTime Date { get; set; }

        // Constructor to initialize a journal entry
        public Entry(string text, string prompt, DateTime date)
        {
            Text = text ?? "No text provided";
            Prompt = prompt ?? "No prompt provided";
            Date = date;
        }

        // Override ToString to display journal entry in a readable format
        public override string ToString()
        {
            return $"Date: {Date:yyyy-MM-dd HH:mm}\nPrompt: {Prompt}\nEntry: {Text}\n" + new string('=', 30);
        }
    }
}
