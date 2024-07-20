/// <summary>
/// Represents a single product order, with name, ID, price per unit, and quantity ordered
/// </summary>
public class Product 
{
    private string _name;
    private int _productID;
    private double _unitPrice;
    private int _quantity;

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="name">The name of the product</param>
    /// <param name="productID">The unique identifier of the product</param>
    /// <param name="unitPrice">The price per unit of the product</param>
    /// <param name="quantity">The number of units ordered</param>
    public Product(string name, int productID, double unitPrice, int quantity)
    {
        _name = name;
        _productID = productID;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    /// <summary>
    /// Gets the total price for this product
    /// </summary>
    /// <returns>A double representing the total price of this product order</returns>
    public double GetTotalPrice() 
    {
        double totalPrice = _unitPrice * _quantity;
        return totalPrice;
    }

    /// <summary>
    /// Get the name of this product
    /// </summary>
    /// <returns>A string representation of this product's name</returns>
    public string GetName() 
    {
        return _name;
    }

    /// <summary>
    /// Get the unique ID of this product
    /// </summary>
    /// <returns>An integer representing the unique ID of this product</returns>
    public int GetProductID()
    {
        return _productID;
    }

    /// <summary>
    /// Get the number of units in this product
    /// </summary>
    /// <returns>An integer representing the number of units in this product order</returns>
    public int GetQuantity()
    {
        return _quantity;
    }
}