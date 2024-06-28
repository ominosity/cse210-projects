using System.Text;

class Scripture
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
        
        // Pick a random index of the List<Word) and 
        // hide it. Repeat until the right number are
        // hidden/ 
        for (int i = 0; i < numberToHide; i++)
        {
            int newPickIndex = random.Next(_words.Count());
            _words[newPickIndex].Hide();
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
}