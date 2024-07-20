using System.Text;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInternational() 
    {
        if (_country.ToLower() != "usa")
        {
            return true;
        }
        return false;
    }

    public string GetFormattedAddress() 
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{_streetAddress}");
        sb.AppendLine($"{_city}, {_stateProvince}");
        sb.AppendLine(_country);

        return sb.ToString();
    }
}