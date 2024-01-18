public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        Entry entry = new Entry();

        PromptGenerator generatePrompt = new PromptGenerator();
        entry._promptText = generatePrompt.GetRandomPrompt();
        Console.WriteLine($"{entry._promptText}");

        entry._date = DateTime.Now.ToString("MM/dd/yyyy");

        Console.Write("> ");
        entry._entryText = Console.ReadLine();

        _entries.Add(entry);
    }


    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear(); // Clear existing entries before loading

        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                string[] entryData = reader.ReadLine().Split('|');
                if (entryData.Length == 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = entryData[0];
                    loadedEntry._promptText = entryData[1];
                    loadedEntry._entryText = entryData[2];

                    _entries.Add(loadedEntry);
                }
            }
        }
    }
}