using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the first order by creating an address, using it to create a customer, and using the 
        // customer to create the empty order.
        Address address1 = new Address("2246 Grandview Dr NW", "Albany", "Oregon", "USA");
        Customer customer1 = new Customer("Richard Burgener", address1);
        Order order1 = new Order(customer1);

        // Create the first order's products
        Product product1 = new Product("Catco Automatic Litter Box", 1538, 399.00, 1);
        Product product2 = new Product("Pretty Litter, 40lb Bag", 98763, 27.99, 5);
        Product product3 = new Product("Iams for Senior Cats, 12lbs", 645, 26.99, 2);

        // Add the first order's products to the order
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create the second order by creating an address, using it to create a customer, and using the 
        // customer to create the empty order.
        Address address2 = new Address("705 W 54th Ave", "Vancouver", "British Columbia", "Canada");
        Customer customer2 = new Customer("Zeke Hammerstein", address2);
        Order order2 = new Order(customer2);

        // Create the second order's products
        Product product4 = new Product("Stanley Quencher H2.0 Tumbler with Handle 40 oz", 6579, 45.00, 1);
        Product product5 = new Product("Ice Cube Tray Mold for Stanley 40oz", 98765, 9.99, 2);
        Product product6 = new Product("Silicone Straw Covers and Caps - Cats - for Stanley Tumblers", 98735, 6.29, 1);
        Product product7 = new Product("Insefocc Stanley Cup 40oz Snack Bowl with Handle", 359846, 6.29, 1);

        // Add the second order's products to the order
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        order2.AddProduct(product7);

        // Clear the terminal for the printouts
        Console.Clear();

        // Print the packing label, the shipping label, and the total price of the first order
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total price: ${Math.Round(order1.GetTotalCost(), 2)}");

        // Create a delimiter between the orders
        Console.WriteLine("----------------------------------------------------------------");

        // Print the packing label, the shipping label, and the total price of the second order
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total price: ${Math.Round(order2.GetTotalCost(), 2)}");
    }
}