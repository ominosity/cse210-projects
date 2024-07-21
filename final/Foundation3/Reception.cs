public class Reception : Event
{
    private string _emailForRSVP;
    private int _capacity;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">The title of the event</param>
    /// <param name="description">A brief description of the event</param>
    /// <param name="date">A string representation of the date of the event</param>
    /// <param name="time">A time representation of the time of the event</param>
    /// <param name="address">An Address object representing the address of the event</param>
    /// <param name="emailForRSVP"></param>
    /// <param name="capacity"></param>
    public Reception(string title, string description, string date, string time, Address address, string emailForRSVP, int capacity)
     : base(title, description, date, time, address)
    {
        _emailForRSVP = emailForRSVP;
        _capacity = capacity;
    }

    /// <summary>
    /// Gets a short description of this event
    /// </summary>
    /// <returns>This event type, a colon, and the short description from the base</returns>
    public override string GetShortDescription()
    {
        string shortDescription = GetType() + ": " + base.GetShortDescription();
        return shortDescription;
    }

    /// <summary>
    /// Gets the full details of this event
    /// </summary>
    /// <returns>The base standard details with the RSVP email and guest capacity at the end</returns>
    public override string GetFullDetails()
    {
        string fullDetails = base.GetStandardDetails();
        fullDetails += $"\nRSVP: {_emailForRSVP}\nCapacity: {_capacity}";
        return fullDetails;
    }
}