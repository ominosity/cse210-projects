public class SimpleGoal : Goal
{
    private bool _isComplete;

    /// <summary>
    /// Creates a Simple Goal
    /// </summary>
    /// <param name="name">The name of the goal</param>
    /// <param name="description">A brief description of 
    /// the goal</param>
    /// <param name="points">The number of points awarded
    /// upon completion of the goal </param>
    public SimpleGoal (string name, string description, int points) 
        : base (name, description, points)
    {
        _isComplete = false; 
    }

    /// <summary>
    /// Creates a Simple Goal with knowledge of whether or not it's been completed 
    /// </summary>
    /// <param name="name">The name of the goal</param>
    /// <param name="description">A brief description of 
    /// the goal</param>
    /// <param name="points">The number of points awarded
    /// upon completion of the goal </param>
    /// <param name="completed">Boolean true or false whether goal has been completed
    public SimpleGoal (string name, string description, int points, bool completed) 
        : base (name, description, points)
    {
        _isComplete = completed; 
    }

    /// <summary>
    /// Records the event as completed
    /// </summary>
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    /// <summary>
    /// Indicates whether the goal has been completed
    /// </summary>
    /// <returns>True if the goal has been completed, 
    /// false otherwise
    /// </returns>
    public override bool IsComplete()
    {
        return _isComplete;
    }

    /// <summary>
    /// Provides all of the details of the goal in a way that 
    /// it can be saved to a file and retrieved later
    /// </summary>
    /// <returns>A delimited string serializing this goal's state
    /// </returns>
    public override string GetStringRepresentation()
    {
        string representation = $"{GetType()}{Delimiter}{base.GetStringRepresentation()}{Delimiter}{_isComplete}";
        return representation;
    }
}