public class OutdoorGathering : Event
{
    private string _weatherForecast;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">The title of the event</param>
    /// <param name="description">A brief description of the event</param>
    /// <param name="date">A string representation of the date of the event</param>
    /// <param name="time">A time representation of the time of the event</param>
    /// <param name="address">An Address object representing the address of the event</param>
    /// <param name="weatherForecast"></param>
    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    /// <summary>
    /// Gets a short description of this event
    /// </summary>
    /// <returns>This event type, a colon, and the short description from the base</returns>
    public override string GetShortDescription()
    {
        string shortDescription = "Outdoor Gathering: " + base.GetShortDescription();
        return shortDescription;
    }

    /// <summary>
    /// Get the full details of this event
    /// </summary>
    /// <returns>The base standard details with the weather forecast at the end</returns>
    public override string GetFullDetails()
    {
        string fullDetails = base.GetStandardDetails();
        fullDetails += $"\nWeather Forecase: {_weatherForecast}";
        return fullDetails;
    }
}