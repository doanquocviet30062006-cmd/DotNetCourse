
using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(
        string productId,
        string productName,
        string category,
        decimal price,
        int quantity)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Product ID cannot be empty.");

        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name cannot be empty.");

        if (price < 0)
            throw new ArgumentOutOfRangeException(
                nameof(price), "Price cannot be negative.");

        if (quantity < 0)
            throw new ArgumentOutOfRangeException(
                nameof(quantity), "Quantity cannot be negative.");

        ProductId = productId;
        ProductName = productName;
        Category = category;
        Price = price;
        Quantity = quantity;
    }

    // Tính tổng giá trị tồn kho của sản phẩm
    public decimal GetInventoryValue()
    {
        return Price * Quantity;
    }

    // Kiểm tra sản phẩm còn hàng
    public bool IsInStock()
    {
        return Quantity > 0;
    }

    // In thông tin sản phẩm
    public void PrintInfo()
    {
        Console.WriteLine($"ID: {ProductId}");
        Console.WriteLine($"Name: {ProductName}");
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Price: {Price:N2}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Inventory value: {GetInventoryValue():N2}");
        Console.WriteLine($"In stock: {(IsInStock() ? "Yes" : "No")}");
        Console.WriteLine(new string('-', 40));
    }
}

public class ProductManager
{
    private readonly Dictionary<string, Product> _products;

    public ProductManager()
    {
        _products = new Dictionary<string, Product>(
            StringComparer.OrdinalIgnoreCase);
    }

    // Thêm sản phẩm
    public void AddProduct(Product product)
    {
        if (_products.ContainsKey(product.ProductId))
        {
            throw new InvalidOperationException(
                $"Product ID {product.ProductId} already exists.");
        }

        _products.Add(product.ProductId, product);
        Console.WriteLine("Product added successfully.");
    }

    // Hiển thị tất cả sản phẩm
    public void DisplayAllProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("The product list is empty.");
            return;
        }

        foreach (Product product in _products.Values)
        {
            product.PrintInfo();
        }
    }

    // Tìm sản phẩm theo mã
    public Product? FindProduct(string productId)
    {
        if (_products.TryGetValue(productId, out Product? product))
        {
            return product;
        }

        return null;
    }

    // Xóa sản phẩm
    public bool RemoveProduct(string productId)
    {
        return _products.Remove(productId);
    }

    // Tính tổng giá trị toàn bộ hàng tồn kho
    public decimal GetTotalInventoryValue()
    {
        return _products.Values.Sum(
            product => product.GetInventoryValue());
    }

    // Hiển thị các sản phẩm còn hàng
    public void DisplayProductsInStock()
    {
        var inStockProducts = _products.Values
            .Where(product => product.IsInStock())
            .ToList();

        if (inStockProducts.Count == 0)
        {
            Console.WriteLine("No products are in stock.");
            return;
        }

        foreach (Product product in inStockProducts)
        {
            product.PrintInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        ProductManager manager = new ProductManager();

        while (true)
        {
            Console.WriteLine("\n===== PRODUCT MANAGEMENT =====");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Display all products");
            Console.WriteLine("3. Find product by ID");
            Console.WriteLine("4. Remove product");
            Console.WriteLine("5. Calculate total inventory value");
            Console.WriteLine("6. Display products in stock");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            try
            {
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Product ID: ");
                        string id = Console.ReadLine()!;

                        Console.Write("Product name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Category: ");
                        string category = Console.ReadLine()!;

                        Console.Write("Price: ");
                        decimal price = decimal.Parse(
                            Console.ReadLine()!);

                        Console.Write("Quantity: ");
                        int quantity = int.Parse(
                            Console.ReadLine()!);

                        Product product = new Product(
                            id, name, category, price, quantity);

                        manager.AddProduct(product);
                        break;

                    case "2":
                        manager.DisplayAllProducts();
                        break;

                    case "3":
                        Console.Write("Enter product ID: ");
                        string searchId = Console.ReadLine()!;

                        Product? found = manager.FindProduct(searchId);

                        if (found == null)
                            Console.WriteLine("Product not found.");
                        else
                            found.PrintInfo();

                        break;

                    case "4":
                        Console.Write("Enter product ID to remove: ");
                        string removeId = Console.ReadLine()!;

                        if (manager.RemoveProduct(removeId))
                            Console.WriteLine("Product removed.");
                        else
                            Console.WriteLine("Product not found.");

                        break;

                    case "5":
                        Console.WriteLine(
                            $"Total inventory value: " +
                            $"{manager.GetTotalInventoryValue():N2}");
                        break;

                    case "6":
                        manager.DisplayProductsInStock();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter the correct data type.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
