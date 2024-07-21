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
    private string _zipPostalCode;

    /// <summary>
    /// Create a new Address from component parts
    /// </summary>
    /// <param name="streetAddress">The street address, including house number, direction, street name, street type, 
    /// and quadrant, as applicable</param>
    /// <param name="city">The city this address is in</param>
    /// <param name="stateProvince">The state or province this address is in</param>
    /// <param name="zipPostalCode">The zip or postal code of this address</param>
    /// <param name="country">The country this address is in</param>
    public Address(string streetAddress, string city, string stateProvince, string zipPostalCode, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _zipPostalCode = zipPostalCode;
        _country = country;
    }

    /// <summary>
    /// Formats and returns this address
    /// </summary>
    /// <returns>A string representation of this address</returns>
    public string GetFormattedAddress() 
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{_streetAddress}");
        sb.AppendLine($"{_city}, {_stateProvince}  {_zipPostalCode}");
        sb.AppendLine(_country);

        return sb.ToString();
    }
}