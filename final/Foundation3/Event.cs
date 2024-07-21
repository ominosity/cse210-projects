/// <summary>
/// An Event Planner's event, with methods for generating advertising
/// copy for social media
/// </summary>
public abstract class Event 
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    /// <summary>
    /// Create an event with basic information all events need
    /// </summary>
    /// <param name="title">The title of the event</param>
    /// <param name="description">A brief description of the event</param>
    /// <param name="date">A string representation of the date of the event</param>
    /// <param name="time">A time representation of the time of the event</param>
    /// <param name="address">An Address object representing the address of the event</param>
    public Event (string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    /// <summary>
    /// Get the standard details of this event
    /// </summary>
    /// <returns>A string with event standard details on different lines:
    /// Title, description, date and time, address</returns>
    public string GetStandardDetails()
    {
        string details = $"{_title}\n{_description}\n{_date} {_time}\n\n{_address.GetFormattedAddress()}";
        return details;
    }

    /// <summary>
    /// Gets a short description of this event
    /// </summary>
    /// <returns>A string with the event's title, a hyphen, and date</returns>
    public virtual string GetShortDescription()
    {
        string shortDescription = $"{_title} - {_date}";
        return shortDescription;
    }

    /// <summary>
    /// Gets the full details of this event
    /// </summary>
    /// <returns>Children of the Event class need to implement this with 
    /// their information and the results of the GetStandardDetails method
    /// above.</returns>
    public abstract string GetFullDetails();
}