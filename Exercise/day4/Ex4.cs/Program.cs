
using System;
using System.Collections.Generic;

class Program
{
    // Hàng đợi lưu các yêu cầu hỗ trợ
    static Queue<string> requests = new Queue<string>();

    // 1. Thêm yêu cầu
    static void AddRequest()
    {
        Console.Write("Enter support request: ");
        string? request = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(request))
        {
            Console.WriteLine("Request cannot be empty.");
            return;
        }

        requests.Enqueue(request.Trim());

        Console.WriteLine("Request added successfully.");
    }

    // 2. Xử lý yêu cầu tiếp theo
    static void ProcessNextRequest()
    {
        if (requests.Count == 0)
        {
            Console.WriteLine("No pending requests to process.");
            return;
        }

        string request = requests.Dequeue();

        Console.WriteLine($"Processing request: {request}");
        Console.WriteLine("Request processed successfully.");
    }

    // 3. Xem yêu cầu tiếp theo mà không xóa
    static void ViewNextRequest()
    {
        if (requests.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        Console.WriteLine($"Next request: {requests.Peek()}");
    }

    // 4. Đếm số yêu cầu đang chờ
    static void CountRequests()
    {
        Console.WriteLine(
            $"Pending requests: {requests.Count}");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== TECHNICAL SUPPORT QUEUE =====");
            Console.WriteLine("1. Add a request");
            Console.WriteLine("2. Process the next request");
            Console.WriteLine("3. View the next request");
            Console.WriteLine("4. Count pending requests");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRequest();
                    break;

                case "2":
                    ProcessNextRequest();
                    break;

                case "3":
                    ViewNextRequest();
                    break;

                case "4":
                    CountRequests();
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine(
                        "Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
