using System.Text;
/// <summary>
/// Represents a mailing/shipping address
/// </summary>
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    /// <summary>
    /// Create a new Address from component parts
    /// </summary>
    /// <param name="streetAddress">The street address, including house number, direction, street name, street type, 
    /// and quadrant, as applicable</param>
    /// <param name="city">The city this address is in</param>
    /// <param name="stateProvince">The state or province this address is in</param>
    /// <param name="country">The country this address is in</param>
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    /// <summary>
    /// Determines whether this address is international (outside the USA)
    /// </summary>
    /// <returns>A boolean of whether the address is international</returns>
    public bool IsInternational() 
    {
        if (_country.ToLower() != "usa")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Formats and returns this address
    /// </summary>
    /// <returns>A string representation of this address</returns>
    public string GetFormattedAddress() 
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{_streetAddress}");
        sb.AppendLine($"{_city}, {_stateProvince}");
        sb.AppendLine(_country);

        return sb.ToString();
    }
}