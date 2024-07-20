using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label: ");
        foreach (Product product in _products)
        {
            sb.AppendLine($"\t{product.GetProductID()} - {product.GetName()}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label: ");
        sb.AppendLine($"\t{_customer.GetName()}");
        string indentedAddress = _customer.GetAddress().GetFormattedAddress();
        indentedAddress = indentedAddress.Replace("\n", "\n\t");
        sb.AppendLine($"\t{indentedAddress}");
        return sb.ToString();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double grandTotal = 0;
        foreach (Product product in _products)
        {
            grandTotal += product.GetTotalPrice();
        }

        if (_customer.GetAddress().IsInternational())
        {
            grandTotal += 35;
        } 
        else 
        {
            grandTotal += 5;
        }

        return grandTotal;
    }
}