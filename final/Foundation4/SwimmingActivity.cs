/// <summary>
/// Represents a Swimming activity
/// </summary>
public class SwimmingActivity : Activity
{
    private int _numberOfLaps;

    /// <summary>
    /// Creates a swimming activity
    /// </summary>
    /// <param name="dateTime">The date and time the exercise was performed</param>
    /// <param name="minutesExercised">The number of minutes exercised</param>
    /// <param name="numberOfLaps">The number of 50m laps completed</param>
    public SwimmingActivity(DateTime dateTime, int minutesExercised, int numberOfLaps)
        : base(dateTime, minutesExercised)
    {
        _numberOfLaps = numberOfLaps;
    }

    /// <summary>
    /// Get the summary of this swimming activity
    /// </summary>
    /// <returns>Date, Exercise Type, Distance, Speed, and Pace 
    /// as a concatenated string</returns>
    public override string GetSummary()
    {
        return base.GetSummary("Swimming");
    }

    /// <summary>
    /// Gets the swimming distance in miles
    /// </summary>
    /// <returns>A double representing the swimming distance in miles</returns>
    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000 * 0.62;
    }

    /// <summary>
    /// Gets the average swimming speed, in miles per hour
    /// </summary>
    /// <returns>A double representing the swimmming speed, in miles
    /// per hour</returns>
    public override double GetSpeed()
    {
        return GetDistance() / base.GetMinutesExercised() * 60;
    }

    /// <summary>
    /// Gets the average swimming pace, in minutes per mile
    /// </summary>
    /// <returns>A double representing the average swimming pace, 
    /// in minutes per mile</returns>
    public override double GetPace()
    {
        return base.GetMinutesExercised() / GetDistance();
    }
}