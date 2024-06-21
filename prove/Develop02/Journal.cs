public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        // Iterate through the journal entries
        foreach (Entry entry in _entries)
        {
            // Show the Entry, formatted by the Entry itself
            entry.Display();    

            // Separate entries with a blank line. 
            Console.WriteLine("");
        }
    }

    public void SaveToFile(string filename)
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to save!");
            return;
        }
        // Open a file for saving
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Iterate through the entries
            foreach (Entry entry in _entries)
            {
                // Write each line, formatted by the Entry itself
                outputFile.WriteLine(entry.FormatEntryForStorage()); 
            }
        }
        Console.WriteLine("Journal saved!");
    }    

    public void LoadFromFile(string filename)
    {
        if (_entries.Count != 0)
        {
            Console.WriteLine("Current journal is not empty.");
            Console.WriteLine("Press 'y' to overwrite it or any other key to abort.");
            ConsoleKeyInfo response = Console.ReadKey();
            if (response.Key != ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Aborting load...");
                return;
            }
            else 
            {
                Console.WriteLine("");
                // Clear the journal in anticipation of the new
                // load. 
                _entries.Clear();
            }
        }
        // Read the file into memory
        string[] lines = System.IO.File.ReadAllLines(filename);

        // Iterate through each line
        foreach (string line in lines)
        {
            // Pass the line into the Entry function that will turn
            // it into an Entry object            
            _entries.Add(Entry.CreateEntryFromStorage(line));
        }
        Console.WriteLine("Journal Loaded!");
    }
}