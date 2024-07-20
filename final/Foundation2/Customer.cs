/// <summary>
/// Represents a customer who is placing an order
/// </summary>
public class Customer 
{
    private string _name;
    private Address _address;

    /// <summary>
    /// Create a customer with name and address information
    /// </summary>
    /// <param name="name">A string representing the customer's name</param>
    /// <param name="address">An Address object representing the customer's address</param>
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    /// <summary>
    /// Get the customer's name
    /// </summary>
    /// <returns>A string representing the customer's name</returns>
    public string GetName()
    {
        return _name;
    }

    /// <summary>
    /// Get the customer's address
    /// </summary>
    /// <returns>An Address object representing the customer's address</returns>
    public Address GetAddress() 
    {
        return _address;
    }
}