using System;
using System.Collections.Generic;

// Product class
public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Getter for total cost of the product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Packing label string representation
    public string GetPackingLabel()
    {
        return $"Name: {name}, Product ID: {productId}";
    }
}

// Address class
public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // String representation of the address
    public override string ToString()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

// Order class
public class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        products = new List<Product>();
        this.customer = customer;
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Calculate total cost of the order
    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        // Add shipping cost based on customer location
        totalCost += customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    // Packing label string representation
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetPackingLabel()}\n";
        }
        return label;
    }

    // Shipping label string representation
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.ToString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address and customer
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create products
        Product product1 = new Product("Widget", "W123", 10.99, 2);
        Product product2 = new Product("Gadget", "G456", 19.99, 1);

        // Create order and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Display packing label, shipping label, and total cost
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        // Create address and customer in another country
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products for the second order
        Product product3 = new Product("Book", "B789", 15.50, 3);

        // Create another order and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Display packing label, shipping label, and total cost for the second order
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
