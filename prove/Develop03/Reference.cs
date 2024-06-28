class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    private int _endVerse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText() 
    {
        // If it's a single verse:
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}: {_verse}";
        }
        // If it's multiple verses:
        else 
        {
            return $"{_book} {_chapter}: {_verse}-{_endVerse}";
        }
    }
}