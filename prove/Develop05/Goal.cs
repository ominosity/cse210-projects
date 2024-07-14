public abstract class Goal 
{
    private string _shortName;
    private string _description;
    private int _points;

    protected const string Delimiter = "|~|";

    public Goal (string name, string description, int points)
    {
        _description = description;
        _points = points;
        _shortName = name;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString() 
    {
        string details = $"{_shortName} ({_description})";
        return details; 
    }
    public virtual string GetStringRepresentation()
    {
        string representation = $"{_shortName}{Delimiter}{_description}{Delimiter}{_points}";
        return representation;
    }

    public string GetName()
    {
        return _shortName;
    }
    public static string GetDelimiter()
    {
        return Delimiter;
    }

    public virtual int GetPointValue() {
        return _points;
    }
}