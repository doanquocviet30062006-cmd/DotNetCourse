
using System;
using System.Collections.Generic;

// ==================== STUDENT ====================
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    public Student(int id, string name, int yearOfBirth)
    {
        Id = id;
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Year of birth: {YearOfBirth}";
    }
}

// ==================== PRODUCT ====================
public class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public Product(string productId, string productName, decimal price)
    {
        ProductId = productId;
        ProductName = productName;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Price: {Price:N0}";
    }
}

// ==================== GENERIC REPOSITORY ====================
public class SimpleRepository<T>
{
    private readonly List<T> _items = new List<T>();

    // Add an item
    public void Add(T item)
    {
        _items.Add(item);
    }

    // Get all items
    public List<T> GetAll()
    {
        return new List<T>(_items);
    }

    // Count items
    public int Count()
    {
        return _items.Count;
    }
}

// ==================== MAIN PROGRAM ====================
class Program
{
    static void Main()
    {
        // Repository for students
        SimpleRepository<Student> studentRepository =
            new SimpleRepository<Student>();

        studentRepository.Add(new Student(1, "An", 2005));
        studentRepository.Add(new Student(2, "Binh", 2004));
        studentRepository.Add(new Student(3, "Chi", 2005));

        // Repository for products
        SimpleRepository<Product> productRepository =
            new SimpleRepository<Product>();

        productRepository.Add(new Product("P01", "Laptop", 15000000));
        productRepository.Add(new Product("P02", "Mouse", 200000));
        productRepository.Add(new Product("P03", "Keyboard", 500000));

        // Display students
        Console.WriteLine("===== STUDENT LIST =====");

        foreach (Student student in studentRepository.GetAll())
        {
            Console.WriteLine(student);
        }

        Console.WriteLine($"Total students: {studentRepository.Count()}");

        // Display products
        Console.WriteLine("\n===== PRODUCT LIST =====");

        foreach (Product product in productRepository.GetAll())
        {
            Console.WriteLine(product);
        }

        Console.WriteLine($"Total products: {productRepository.Count()}");
    }
}
