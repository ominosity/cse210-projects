using System.Text;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    public Scripture(Reference reference, string text)
    {
        // Store the reference item
        _reference = reference;

        // Create a new List of Words from the given text
        _words = new List<Word>();
        string[] wordArray = text.Split([' ']);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        // Get a list of words that are still visible
        List<Word> words = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                words.Add(word);
            }
        }
        // If fewer than numberToHide, hide all remaining
        if (words.Count < numberToHide)
        {
            foreach (Word word in words)
            {
                word.Hide();
            }
        }
        else
        {
            // Otherwise, randomly hide numberToHide words
            for (int i = 0; i < numberToHide; i++)
            {
                int newPickIndex = random.Next(words.Count);
                words[newPickIndex].Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        // Create a stringbuilder to hold the scripture text. 
        StringBuilder sb = new StringBuilder();

        // Iterate through the list of words and add the display
        // value to the stringbuilder
        foreach (Word word in _words)
        {
            sb.Append($"{word.GetDisplayText()} ");
        }

        // Return the new string
        return sb.ToString();
    }

    public bool IsCompletelyHidden()
    {
        // Scan through each word in the list
        foreach (Word word in _words)
        {
            // If the word is visible, there are words left
            // to hide. 
            if (!word.IsHidden())
            {
                return false;
            }
        }
        // If we get here, no visible words were found. 
        return true;
    }

    public Reference GetReference()
    {
        return _reference;
    }

    /// <summary>
    ///     Reset the default so all words are visible
    /// </summary>
    public void ResetVisibility()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
}