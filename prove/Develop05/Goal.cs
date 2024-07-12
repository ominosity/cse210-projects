public abstract class Goal 
{
    private string _shortName ;
    private string _description ;
    private int _points ;

    public Goal (string name, string description, int points)
    {
        _description = description ;
        _points = points ;
        _shortName = name ;
    }

    public abstract void RecordEvent() ;
    public abstract bool IsComplete() ;
    public virtual string GetDetailsString() 
    {
        throw new NotImplementedException();
    }
    public abstract string GetStringRepresentation() ;
}