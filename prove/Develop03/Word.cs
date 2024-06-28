using System.Text;

class Word 
{
    private string _text;
    private bool _isHidden;

    public Word (string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() 
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText() 
    {
        // If the word isn't hidden yet, return it as-is
        if (!_isHidden)
        {
            return _text;
        }

        // Otherwise, return a string of underscores the length
        // of the original word
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _text.Length; i++)
        {
            sb.Append("_");
        }
        return sb.ToString();
    }


}