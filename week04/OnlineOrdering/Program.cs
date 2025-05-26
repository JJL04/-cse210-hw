using System;

class Program
{
    static void Main()
    {
        // First Order
        Address address1 = new Address("123 Elm St", "Dallas", "TX", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 25.50, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Second Order
        Address address2 = new Address("45 King Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MON789", 200.00, 1));
        order2.AddProduct(new Product("Keyboard", "KYB101", 50.00, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
