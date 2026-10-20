using System;
using System.Globalization;

public abstract class Polygon
{
    public abstract double TinhChuVi();
    public abstract double TinhDienTich();
}

public class Parallelogram : Polygon
{
    protected double BaseLength;
    protected double SideLength;
    protected double Height;

    public Parallelogram(double baseLength, double sideLength, double height)
    {
        if (baseLength <= 0 || sideLength <= 0 || height <= 0 || height > sideLength)
            throw new ArgumentException("Canh phai duong va chieu cao khong vuot qua canh ben.");
        BaseLength = baseLength; SideLength = sideLength; Height = height;
    }
    public override double TinhChuVi() => 2 * (BaseLength + SideLength);
    public override double TinhDienTich() => BaseLength * Height;
}

public class Rectangle : Parallelogram
{
    public Rectangle(double length, double width) : base(length, width, width) { }
}

public class Square : Rectangle
{
    public Square(double side) : base(side, side) { }
}

public class Program
{
    private static double ReadPositive(string prompt)
    {
        Console.Write(prompt);
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) ||
               double.IsNaN(x) || double.IsInfinity(x) || x <= 0)
            Console.Write("Can nhap so duong hop le: ");
        return x;
    }

    private static void PrintShape(string name, Polygon p)
    {
        Console.WriteLine($"{name}: chu vi = {p.TinhChuVi():0.##}, dien tich = {p.TinhDienTich():0.##}");
    }

    public static void Main()
    {
        Console.WriteLine("HINH BINH HANH");
        double b = ReadPositive("Canh day: ");
        double c = ReadPositive("Canh ben: ");
        double h;
        do { h = ReadPositive("Chieu cao: "); if (h > c) Console.WriteLine("Chieu cao khong the lon hon canh ben."); } while (h > c);
        PrintShape("Hinh binh hanh", new Parallelogram(b, c, h));

        Console.WriteLine("HINH CHU NHAT");
        PrintShape("Hinh chu nhat", new Rectangle(ReadPositive("Chieu dai: "), ReadPositive("Chieu rong: ")));

        Console.WriteLine("HINH VUONG");
        PrintShape("Hinh vuong", new Square(ReadPositive("Canh: ")));
    }
}
