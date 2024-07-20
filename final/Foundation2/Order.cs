using System.Text;

/// <summary>
/// Represents a customer order, with the customer information and a product list
/// </summary>
public class Order
{
    private Customer _customer;
    private List<Product> _products;

    /// <summary>
    /// Create a new Order
    /// </summary>
    /// <param name="customer">The customer placing this order</param>
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    /// <summary>
    /// Creates and formats a packing label
    /// </summary>
    /// <returns>A string with tabs and newlines representing a packing label</returns>
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label: ");
        foreach (Product product in _products)
        {
            string quantityString = ""; 
            if (product.GetQuantity() > 1) 
            {
                quantityString = $" x{product.GetQuantity()}";
            }
            sb.AppendLine($"\t{product.GetProductID()} - {product.GetName()}{quantityString}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// Creates and formats a shipping label. 
    /// </summary>
    /// <returns>A string with tabs and newlines representing a shipping label</returns>
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label: ");
        sb.AppendLine($"\t{_customer.GetName()}");

        // Modify an address to be indented, and add it
        string indentedAddress = _customer.GetAddress().GetFormattedAddress();
        indentedAddress = indentedAddress.Replace("\n", "\n\t");
        sb.AppendLine($"\t{indentedAddress}");
        return sb.ToString();
    }

    /// <summary>
    /// Add a product to this order
    /// </summary>
    /// <param name="product">The product to add</param>
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    /// <summary>
    /// Figure the total cost as the total product cost + shipping
    /// </summary>
    /// <returns>The total cost, including shipping</returns>
    public double GetTotalCost()
    {
        double grandTotal = 0;

        // Add the cost for each product line
        foreach (Product product in _products)
        {
            grandTotal += product.GetTotalPrice();
        }

        // If the customer is international, add $35 shipping
        if (_customer.GetAddress().IsInternational())
        {
            grandTotal += 35;
        } 
        // If the customer is domestic, add $5 shipping
        else 
        {
            grandTotal += 5;
        }

        return grandTotal;
    }
}