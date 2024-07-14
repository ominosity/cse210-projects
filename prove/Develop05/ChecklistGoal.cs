public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

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
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    /// <summary>
    /// Creates a new Checklist Goal, with knowlege of progress
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
    /// <param name="amountCompleted">The number of bonus points to
    /// award upon completion of target</param>
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    /// <summary>
    /// Records the event as completed
    /// </summary>
    public override void RecordEvent()
    {
        _amountCompleted++;
;
    }

    /// <summary>
    /// Return the point value for this goal. If the target has been met, award bonus points. 
    /// </summary>
    /// <returns>An int indicating how many points this is worth</returns>
    public override int GetPointValue() 
    {
        if (_amountCompleted >= _target)
        {
            return base.GetPointValue() + _bonus;
        }
        else 
        {
            return base.GetPointValue();
        }
    }

    /// <summary>
    /// Indicates whether the goal has been completed
    /// </summary>
    /// <returns>True if the target number has been completed, 
    /// false otherwise
    /// </returns>
    public override bool IsComplete()
    {
        return _amountCompleted >= _target ? true : false; 
    }

    /// <summary>
    /// Gets the details of the progress towards completing 
    /// this goal
    /// </summary>
    /// <returns>A string indicating the progress towards 
    /// completing this goal</returns>
    public override string GetDetailsString()
    {
        string message = base.GetDetailsString();
        message += $" -- Currently completed {_amountCompleted}/{_target}";
        return message;
    }

    /// <summary>
    /// Provides all of the details of the goal in a way that 
    /// it can be saved to a file and retrieved later
    /// </summary>
    /// <returns>A delimited string serializing this goal's state
    /// </returns>
    public override string GetStringRepresentation()
    {
        string representation = $"{GetType()}{Delimiter}{base.GetStringRepresentation()}{Delimiter}{_bonus}{Delimiter}{_target}{Delimiter}{_amountCompleted}";
        return representation;
    }
}