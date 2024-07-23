using System.Text;

/// <summary>
/// Represents an exercise activity
/// </summary>
public abstract class Activity
{
    private DateTime _exerciseDateTime;
    private int _minutesExercised;

    /// <summary>
    /// Create an exercise activity
    /// </summary>
    /// <param name="exerciseDateTime"></param>
    /// <param name="minutesExercised"></param>
    protected Activity(DateTime exerciseDateTime, int minutesExercised)
    {
        _exerciseDateTime = exerciseDateTime;
        _minutesExercised = minutesExercised;
    }

    /// <summary>
    /// Gets a formatted string representing the date and time
    /// </summary>
    /// <returns>A string of the form day month year 
    /// (e.g. 01 Jan 2022)</returns>
    protected string GetExerciseDateString()
    {
        return _exerciseDateTime.ToString("dd MMM yyyy");
    }

    /// <summary>
    /// Use public methods to get the summary of the activity
    /// </summary>
    /// <returns>Date, Exercise Type, Distance, Speed, and Pace 
    /// as a concatenated string</returns>
    public string GetSummary(string activityType)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{GetExerciseDateString()} ");
        sb.Append($"{activityType} ({GetMinutesExercised()}): ");
        sb.Append($"Distance {Math.Round(GetDistance(), 1)} miles, ");
        sb.Append($"Speed {Math.Round(GetSpeed(), 1)} mph");
        sb.Append($"Pace {Math.Round(GetPace(), 2)} min per mile");

        return sb.ToString();
    }

    public abstract string GetSummary();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    /// <summary>
    /// Get the number of minutes exercised
    /// </summary>
    /// <returns>An integer of the number of minutes exercised</returns>
    public int GetMinutesExercised()
    {
        return _minutesExercised;
    }
}