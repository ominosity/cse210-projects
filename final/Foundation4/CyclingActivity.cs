/// <summary>
/// Represents a Cycling Activity with a given speed
/// </summary>
public class CyclingActivity : Activity
{
    private double _speed;

    /// <summary>
    /// Create a cycling activity
    /// </summary>
    /// <param name="dateTime">The date and time the exercise was performed</param>
    /// <param name="minutesExercised">The number of minutes exercised</param>
    /// <param name="speed">The speed, in miles per hour (mph)</param>
    public CyclingActivity(DateTime dateTime, int minutesExercised, double speed)
        : base(dateTime, minutesExercised)
    {
        _speed = speed;
    }

    /// <summary>
    /// Get the summary of this cycling activity
    /// </summary>
    /// <returns>Date, Exercise Type, Distance, Speed, and Pace 
    /// as a concatenated string</returns>
    public override string GetSummary()
    {
        return base.GetSummary("Cycling");
    }

    /// <summary>
    /// Get the distance cycled, in miles
    /// </summary>
    /// <returns>A double representing the number of miles cycled</returns>
    public override double GetDistance()
    {
        return _speed * base.GetMinutesExercised() / 60;
    }

    /// <summary>
    /// Get the average cycling speed, in miles per hour (mph)
    /// </summary>
    /// <returns>A double representing the average speed, in 
    /// miles per hour (mph)</returns>
    public override double GetSpeed()
    {
        return _speed;
    }

    /// <summary>
    /// Gets the average cycling pace, in minutes per mile
    /// </summary>
    /// <returns>A double representing the average cycling pace,
    /// in minutes per mile</returns>
    public override double GetPace()
    {
        return 60 / _speed;
    }
}