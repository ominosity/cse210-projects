/// <summary>
/// Represents a Running activity with the given distance
/// </summary>
public class RunningActivity : Activity
{
    private double _distance;

    /// <summary>
    /// Create a running activity
    /// </summary>
    /// <param name="dateTime">The date and time the exercise was performed</param>
    /// <param name="minutesExercised">The number of minutes exercised</param>
    /// <param name="distance">The distance run, in miles</param>
    public RunningActivity(DateTime dateTime, int minutesExercised, double distance)
        : base(dateTime, minutesExercised)
    {
        _distance = distance;
    }

    /// <summary>
    /// Get the summary of this running activity
    /// </summary>
    /// <returns>Date, Exercise Type, Distance, Speed, and Pace 
    /// as a concatenated string</returns>
    public override string GetSummary()
    {
        return base.GetSummary("Running");
    }

    /// <summary>
    /// Gets the distance run, in miles
    /// </summary>
    /// <returns>A double representing the number of miles run</returns>
    public override double GetDistance()
    {
        return _distance;
    }

    /// <summary>
    /// Gets the speed, in miles per hour (mph)
    /// </summary>
    /// <returns>A double representing the speed run, in miles 
    /// per hour (mph)</returns>
    public override double GetSpeed()
    {
        return _distance / base.GetMinutesExercised() * 60;
    }

    /// <summary>
    /// Gets the average pace of the run, in minutes per mile
    /// </summary>
    /// <returns>A double representing the average pace run,
    /// in minutes per mile</returns>
    public override double GetPace()
    {
        return base.GetMinutesExercised() / _distance;
    }
}