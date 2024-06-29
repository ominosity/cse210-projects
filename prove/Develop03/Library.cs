using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

public class Library
{
    private Dictionary<Reference, Scripture> _library;
    private Scripture _defaultScripture;
    private string _delimiter;

    public Library()
    {
        _library = new Dictionary<Reference, Scripture>();
        Reference reference = new Reference("1 Nephi", 1, 1);
        _defaultScripture = new Scripture(reference, "I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days.");
        _delimiter = "~|~";
    }

    public Scripture RandomScripture()
    {
        // If the library is empty, reset and return the default scripture
        if (_library.Count == 0)
        {
            _defaultScripture.ResetVisibility();
            return _defaultScripture;
        }

        // Select a random key in the dictionary
        // Create array of keys
        Reference[] keyList = _library.Keys.ToArray();

        // Select the reference at a random index
        Random random = new Random();
        int index = random.Next(keyList.Length);
        Reference reference = keyList[index];

        // Reset the chosen scripture (in case it's been memorized this session)
        Scripture chosenScripture = _library[reference];
        chosenScripture.ResetVisibility();

        // Return the associated scripture
        return chosenScripture;
    }

    public Scripture LoadScripture(Reference reference)
    {
        // Reset and return the scripture if it's in the library
        if (_library.ContainsKey(reference))
        {
            Scripture chosenScripture = _library[reference];
            chosenScripture.ResetVisibility();
            return chosenScripture;
        }
        // Otherwise return 1 Nephi 1:1 with all words flipped back to show
        else
        {
            _defaultScripture.ResetVisibility();
            return _defaultScripture;
        }
    }

    public void AddScripture(Reference reference, Scripture scripture)
    {
        // Do nothing if it's already in there. 
        foreach (Reference key in _library.Keys)
        {
            // Compare the lowercase text representation of the reference
            if (key.GetDisplayText().ToString().ToLower() == reference.GetDisplayText().ToString().ToLower())
            {
                return;
            }
        }
        // Add scripture to library
        _library.Add(reference, scripture);
    }

    public void RemoveScripture(Reference reference)
    {
        // Do nothing is it isn't there
        if (!_library.ContainsKey(reference))
        {
            return;
        }
        foreach (Reference key in _library.Keys)
        {

            // Compare the lowercase text representation of the reference
            if (key.GetDisplayText().ToString().ToLower() == reference.GetDisplayText().ToString().ToLower())
            {
                // Remove the scripture from the library
                Reference chosenKey = _library[key].GetReference();
                _library.Remove(reference);
                Console.WriteLine($"{key} removed!");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey(true);
                return;
            }
        }
    }

    public void ExportLibrary()
    {
        if (_library.Count() == 0)
        {
            Console.WriteLine("Library is empty. Please import or add scriptures and try again.");
            Console.ReadKey(true);
            return;
        }
        // Solicit a filename, then export library to the text file
        Console.Write("Please enter the filename to save. Libraries are stored in plain text (.txt) files: ");
        string filename = Console.ReadLine();

        try
        {
            // Write to file, one reference + delimiter + scripture per line
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Reference reference in _library.Keys)
                {
                    // Reset visibility prior to saving
                    foreach (Scripture scripture in _library.Values)
                    {
                        scripture.ResetVisibility();
                    }
                    // Build the line to write, separating out parts of the reference
                    StringBuilder sb = new StringBuilder();
                    sb.Append(reference.GetBook());
                    sb.Append(_delimiter);
                    sb.Append(reference.GetChapter().ToString());
                    sb.Append(_delimiter);
                    sb.Append(reference.GetVerse().ToString());
                    sb.Append(_delimiter);
                    sb.Append(reference.GetEndVerse().ToString());

                    // Add the scripture text
                    sb.Append(_delimiter);
                    sb.Append(_library[reference].GetDisplayText());

                    // Write everything to a new line in the file
                    sw.WriteLine(sb.ToString());
                }
            }

            Console.WriteLine("File saved! Press any key to return to the menu.");
            Console.ReadKey(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("" + ex.Message);
        }
    }

    public void ImportLibrary()
    {
        if (_library.Count() != 0)
        {
            Console.WriteLine("Library is not empty. Overwrite current library (y/n)? ");
            ConsoleKeyInfo response = Console.ReadKey(true);
            if (response.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Library load cancelled.");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey(true);
                return;
            }
        }

        // Solicit a filename, then export library to the text file
        Console.Write("Please enter the filename to save. Libraries are stored in plain text (.txt) files: ");
        string filename = Console.ReadLine();

        try
        {
            // Empty the library
            _library.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {

                string newScripture = sr.ReadLine();
                // Split incoming stream by delimiter
                string[] scriptureArray = newScripture.Split(_delimiter);

                try
                {
                    // Based on position in array, create Scripture and Reference components
                    string book = scriptureArray[0];
                    int chapter = int.Parse(scriptureArray[1]);
                    int verse = int.Parse(scriptureArray[2]);
                    int endVerse = int.Parse(scriptureArray[3]);
                    string text = scriptureArray[4];

                    Reference reference = new Reference(book, chapter, verse, endVerse);
                    Scripture scripture = new Scripture(reference, text);
                    AddScripture(reference, scripture);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error in file. Cannot load library.");
                    return;
                }
            }
            Console.WriteLine("Library loaded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("" + ex.Message);
        }
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey(true);
        return;
    }


    public Scripture ChooseScripture()
    {
        List<Reference> referenceList = ListReferences();

        // Store the user's choice
        int choice = -1;
        do
        {
            Console.WriteLine("Please choose a scripture from the following: ");
            // Iterate through the reference list, starting at 1 instead of 0
            for (int i = 0; i < referenceList.Count(); i++)
            {
                Console.WriteLine($"\t{i + 1}: {referenceList[i].GetDisplayText()}");
            }
            try
            {
                // Solicit a choice from the user
                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
        } while (choice < 1 || choice > referenceList.Count());
        // Return the indexed scripture. Note that the index is one less
        // than the user choice
        return LoadScripture(referenceList[choice - 1]);
    }

    private List<Reference> ListReferences()
    {
        // Create a reference list
        List<Reference> referenceList = new List<Reference>();

        // If library is empty, return default reference
        if (_library.Count == 0)
        {
            referenceList.Add(_defaultScripture.GetReference());
        }
        else
        {
            // Pull out the references (keys) from the library
            foreach (var item in _library)
            {
                referenceList.Add(item.Key);
            }
        }
        return referenceList;
    }
}