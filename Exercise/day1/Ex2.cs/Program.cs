
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Nhap ho ten
        Console.Write("Nhap ho ten: ");
        string fullName = Console.ReadLine() ?? "";

        // Nhap chieu cao
        double height;
        while (true)
        {
            Console.Write("Nhap chieu cao (m): ");
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out height) && height > 0)
            {
                break;
            }

            Console.WriteLine("Chieu cao khong hop le! Vui long nhap lai.");
        }

        // Nhap can nang
        double weight;
        while (true)
        {
            Console.Write("Nhap can nang (kg): ");
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out weight) && weight > 0)
            {
                break;
            }

            Console.WriteLine("Can nang khong hop le! Vui long nhap lai.");
        }

        // Tinh BMI
        double bmi = weight / (height * height);

        // Phan loai BMI
        string classification;

        if (bmi < 18.5)
        {
            classification = "Gay";
        }
        else if (bmi < 25)
        {
            classification = "Binh thuong";
        }
        else if (bmi < 30)
        {
            classification = "Thua can";
        }
        else
        {
            classification = "Beo phi";
        }

        // In ket qua
        Console.WriteLine("\n===== KET QUA BMI =====");
        Console.WriteLine($"Ho ten       : {fullName}");
        Console.WriteLine($"Chieu cao    : {height:F2} m");
        Console.WriteLine($"Can nang     : {weight:F2} kg");
        Console.WriteLine($"Chi so BMI   : {bmi:F2}");
        Console.WriteLine($"Phan loai    : {classification}");
        Console.WriteLine("======================");
    }
}