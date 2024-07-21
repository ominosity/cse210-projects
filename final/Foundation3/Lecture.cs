/// <summary>
/// A representation of a Lecture-style event
/// </summary>
public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    /// <summary>
    /// Create a lecture event
    /// </summary>
    /// <param name="title">The title of the event</param>
    /// <param name="description">A brief description of the event</param>
    /// <param name="date">A string representation of the date of the event</param>
    /// <param name="time">A time representation of the time of the event</param>
    /// <param name="address">An Address object representing the address of the event</param>
    /// <param name="speaker">The name of the person speaking at this lecture</param>
    /// <param name="capacity">The maximum number of guest spaces available</param>
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
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
    /// <returns>The base standard details with the speaker and guest capacity at the end</returns>
    public override string GetFullDetails() 
    {
        string fullDetails = base.GetStandardDetails();
        fullDetails += $"\nSpeaker: {_speaker}\nCapacity: {_capacity}";
        return fullDetails;
    }
}