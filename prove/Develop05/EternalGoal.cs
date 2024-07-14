public class EternalGoal : Goal
{
    /// <summary>
    /// Creates a new Eternal Goal
    /// </summary>
    /// <param name="name">The name of the goal</param>
    /// <param name="description">A brief description of 
    /// the goal</param>
    /// <param name="points">The number of points awarded
    /// upon completion of the goal </param>
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // No initialization needed
    }

    /// <summary>
    /// Records the event as completed
    /// </summary> 
    public override void RecordEvent()
    {
        // Eternal goals are never completed
    }

    /// <summary>
    /// Indicates whether the goal has been completed
    /// </summary>
    /// <returns>
    /// false - Eternal Goals are never completed
    /// </returns>
    public override bool IsComplete()
    {
        return false;
    }

    /// <summary>
    /// Provides all of the details of the goal in a way that 
    /// it can be saved to a file and retrieved later
    /// </summary>
    /// <returns>A delimited string serializing this goal's state
    /// </returns>
    public override string GetStringRepresentation()
    {
        string representation = $"{GetType()}{Delimiter}{base.GetStringRepresentation()}";
        return representation;
    }
}