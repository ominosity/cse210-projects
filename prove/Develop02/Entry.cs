using System.Configuration.Assemblies;

public class Entry 
{
    private string _date;
    private string _promptText;
    private string _entryText;
    static private string _delimiter = "~|~";

    public Entry (string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }
    
    public void Display() 
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }

    public string FormatEntryForStorage()
    {
        string formattedValue = $"{_date}{_delimiter}{_promptText}{_delimiter}{_entryText}";
        return formattedValue;
    }

    public static Entry CreateEntryFromStorage(string line)
    {
            // Split the line into parts, based on the Entry's delimiter
            string[] parts = line.Split(_delimiter);

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            Entry newEntry = new Entry(date, prompt, response);
            return newEntry;
    }
}