
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Nhap thong tin sinh vien
        Console.Write("Nhap ho ten: ");
        string fullName = Console.ReadLine() ?? "";

        Console.Write("Nhap ma sinh vien: ");
        string studentId = Console.ReadLine() ?? "";

        Console.Write("Nhap lop: ");
        string className = Console.ReadLine() ?? "";

        // Kiem tra nam sinh
        int birthYear;

        while (true)
        {
            Console.Write("Nhap nam sinh: ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out birthYear)
                && birthYear >= 1900
                && birthYear <= DateTime.Now.Year)
            {
                break;
            }

            Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai!");
        }

        Console.Write("Nhap que quan: ");
        string hometown = Console.ReadLine() ?? "";

        Console.Write("Nhap so thich: ");
        string hobbies = Console.ReadLine() ?? "";

        // Tinh tuoi
        int age = DateTime.Now.Year - birthYear;

        // In thong tin
        Console.WriteLine();
        Console.WriteLine("===== THONG TIN SINH VIEN =====");
        Console.WriteLine($"Ho ten      : {fullName}");
        Console.WriteLine($"Ma SV       : {studentId}");
        Console.WriteLine($"Lop         : {className}");
        Console.WriteLine($"Nam sinh    : {birthYear}");
        Console.WriteLine($"Tuoi        : {age}");
        Console.WriteLine($"Que quan    : {hometown}");
        Console.WriteLine($"So thich    : {hobbies}");
        Console.WriteLine("===============================");
    }
}