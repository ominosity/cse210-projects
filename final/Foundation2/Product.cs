public class Product 
{
    private string _name;
    private int _productID;
    private double _unitPrice;
    private int _quantity;

    public Product(string name, int productID, double unitPrice, int quantity)
    {
        _name = name;
        _productID = productID;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    public double GetTotalPrice() 
    {
        double totalPrice = _unitPrice * _quantity;
        return totalPrice;
    }

    public string GetName() 
    {
        return _name;
    }

    public int GetProductID()
    {
        return _productID;
    }
}