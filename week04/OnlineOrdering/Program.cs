using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Sarah Mitchell", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P1001", 19.99, 2));
        order1.AddProduct(new Product("USB-C Hub", "P1002", 34.50, 1));
        order1.AddProduct(new Product("Laptop Stand", "P1003", 45.00, 1));
        orders.Add(order1);

        Address address2 = new Address("45 Adeola Odeku St", "Victoria Island, Lagos", "Lagos", "Nigeria");
        Customer customer2 = new Customer("Ifeanyi Obi", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "P2001", 79.99, 1));
        order2.AddProduct(new Product("Noise Cancelling Headphones", "P2002", 129.99, 1));
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
        }
    }
}