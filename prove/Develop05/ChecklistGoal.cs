public class ChecklistGoal : Goal
{
    private int _amountCompleted ;
    private int _target ;
    private int _bonus ;

    /// <summary>
    /// Creates a new Checklist Goal
    /// </summary>
    /// <param name="name">The name of the goal</param>
    /// <param name="description">A brief description of 
    /// the goal</param>
    /// <param name="points">The number of points awarded
    /// upon completion of the goal </param>
    /// <param name="target">The number of iterations to 
    /// earn bonus points</param>
    /// <param name="bonus">The number of bonus points to
    /// award upon completion of target</param>
    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0 ;
        _target = target ;
        _bonus = bonus ;
    }

    /// <summary>
    /// Records the event as completed and updates score
    /// </summary>
    public override void RecordEvent()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Indicates whether the goal has been completed
    /// </summary>
    /// <returns>True if the goal has been completed, 
    /// false otherwise
    /// </returns>
    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the details of the progress towards completing 
    /// this goal
    /// </summary>
    /// <returns>A string indicating the progress towards 
    /// completing this goal</returns>
    public override string GetDetailsString()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Provides all of the details of the goal in a way that 
    /// it can be saved to a file and retrieved later
    /// </summary>
    /// <returns>A delimited string serializing this goal's state
    /// </returns>
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}