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

    public string RemoveScripture(Reference reference)
    {
        // Holds the return message(s)
        StringBuilder sb = new StringBuilder();

        // Do nothing if it isn't there
        if (!_library.ContainsKey(reference))
        {
            sb.AppendLine("Scripture not in library.");
        }
        else
        {
            foreach (Reference key in _library.Keys)
            {
                // Compare the lowercase text representation of the reference
                if (key.GetDisplayText().ToString().ToLower() == reference.GetDisplayText().ToString().ToLower())
                {
                    // Remove the scripture from the library
                    Reference chosenKey = _library[key].GetReference();
                    _library.Remove(chosenKey);

                    sb.AppendLine($"{key.GetDisplayText()} removed!");
                }
            }
        }
        return sb.ToString();
    }

    public string ExportLibrary(string filename)
    {
        // Holds the return message(s)
        StringBuilder sb = new StringBuilder();

        // If the library is empty, don't export it
        if (_library.Count == 0)
        {
            sb.AppendLine("Library is empty. Please import or add scriptures and try again.");
        }
        else
        {
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
                        StringBuilder scriptureBuilder = new StringBuilder();
                        scriptureBuilder.Append(reference.GetBook());
                        scriptureBuilder.Append(_delimiter);
                        scriptureBuilder.Append(reference.GetChapter());
                        scriptureBuilder.Append(_delimiter);
                        scriptureBuilder.Append(reference.GetVerse());
                        scriptureBuilder.Append(_delimiter);
                        scriptureBuilder.Append(reference.GetEndVerse());

                        // Add the scripture text
                        scriptureBuilder.Append(_delimiter);
                        scriptureBuilder.Append(_library[reference].GetDisplayText());

                        // Write everything to a new line in the file
                        sw.WriteLine(scriptureBuilder.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("" + ex.Message);
            }
            sb.AppendLine($"\nFile ({filename}) saved.");
        }
        return sb.ToString();
    }

    public string ImportLibrary(string filename)
    {
        // Holds the return message(s)
        StringBuilder sb = new StringBuilder();
        try
        {
            // Empty the library
            _library.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                string newScripture;
                while ((newScripture = sr.ReadLine()) != null)
                {

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
                        sb.AppendLine("Error in file. Cannot load library.");
                        return sb.ToString();
                    }
                }
            }
            sb.AppendLine("Library loaded!");
        }
        catch (Exception ex)
        {
            sb.AppendLine("" + ex.Message);
        }
        return sb.ToString();
    }


    // public Scripture ChooseScripture()
    // {

    // }

    public List<Reference> ListReferences()
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

    public bool IsEmpty()
    {
        if (_library.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}