using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our Online Ordering system! Let's get shopping!");
        Console.WriteLine();

        Address address1 = new Address("1122 Main St", "Big City", "UT", "USA");
        Customer customer1 = new Customer("Alice Berry", address1);

        Product product1 = new Product("Apple", 1, 0.99, 2);
        Product product2 = new Product("Hair Brush", 2, 7.99, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Address address2 = new Address("3344 Center St", "Small Town", "ON", "Canada");
        Customer customer2 = new Customer("Sam Trimble", address2);

        Product product3 = new Product("Basket", 3, 15.99, 3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Console.WriteLine("\n-------------------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}