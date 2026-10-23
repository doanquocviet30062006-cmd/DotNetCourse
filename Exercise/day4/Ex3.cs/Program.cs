
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Danh sách mã sinh viên đã đăng ký
    static HashSet<string> studentIds =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    // 1. Đăng ký sinh viên
    static void RegisterStudent()
    {
        Console.Write("Enter student ID: ");
        string? id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Student ID cannot be empty.");
            return;
        }

        id = id.Trim();

        if (studentIds.Add(id))
        {
            Console.WriteLine("Registration successful.");
        }
        else
        {
            Console.WriteLine("This student is already registered.");
        }
    }

    // 2. Hủy đăng ký
    static void CancelRegistration()
    {
        Console.Write("Enter student ID to cancel: ");
        string? id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Student ID cannot be empty.");
            return;
        }

        id = id.Trim();

        if (studentIds.Remove(id))
        {
            Console.WriteLine("Registration cancelled successfully.");
        }
        else
        {
            Console.WriteLine("Student ID is not registered.");
        }
    }

    // 3. Kiểm tra sinh viên đã đăng ký chưa
    static void CheckRegistration()
    {
        Console.Write("Enter student ID to check: ");
        string? id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Student ID cannot be empty.");
            return;
        }

        id = id.Trim();

        if (studentIds.Contains(id))
        {
            Console.WriteLine("Student is registered.");
        }
        else
        {
            Console.WriteLine("Student is not registered.");
        }
    }

    // 4. Hiển thị danh sách sinh viên
    static void DisplayStudents()
    {
        if (studentIds.Count == 0)
        {
            Console.WriteLine("No students have registered.");
            return;
        }

        Console.WriteLine("\nRegistered student IDs:");

        int index = 1;

        foreach (string id in studentIds.OrderBy(id => id))
        {
            Console.WriteLine($"{index}. {id}");
            index++;
        }

        Console.WriteLine($"Total: {studentIds.Count} student(s).");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== COURSE REGISTRATION =====");
            Console.WriteLine("1. Register a student ID");
            Console.WriteLine("2. Cancel registration");
            Console.WriteLine("3. Check registration");
            Console.WriteLine("4. Display registered student IDs");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterStudent();
                    break;

                case "2":
                    CancelRegistration();
                    break;

                case "3":
                    CheckRegistration();
                    break;

                case "4":
                    DisplayStudents();
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
