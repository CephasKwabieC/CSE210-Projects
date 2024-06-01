using System;
using System.Collections.Generic;

public class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

public class Customer
{
    private string Name { get; set; }
    private Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Product
{
    private string Name { get; set; }
    private int ProductId { get; set; }
    private decimal Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }
}

public class Order
{
    private List<Product> Products { get; set; }
    private Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = Products.Sum(p => p.GetTotalCost());
        decimal shippingCost = Customer.LivesInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", Products.Select(p => $"{p.Name} (ID: {p.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Anytown", "NY", "USA"));
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", 1, 19.99m, 3));
        order1.AddProduct(new Product("Gadget", 2, 29.99m, 2));

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total cost: ${order1.GetTotalCost()}");

    }
}
