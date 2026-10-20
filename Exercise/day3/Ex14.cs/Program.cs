using System;
using System.Globalization;

public class Point
{
    public double X { get; }
    public double Y { get; }
    public Point(double x, double y) { X = x; Y = y; }
    public override string ToString() => $"({X:0.##}, {Y:0.##})";
}

public class Ellipse : Point
{
    public double BanTrucLon { get; }
    public double BanTrucNho { get; }
    public Ellipse(double x, double y, double banTrucLon, double banTrucNho) : base(x, y)
    {
        if (banTrucLon <= 0 || banTrucNho <= 0) throw new ArgumentException("Ban truc phai lon hon 0.");
        BanTrucLon = banTrucLon; BanTrucNho = banTrucNho;
    }
    public virtual double TinhDienTich() => Math.PI * BanTrucLon * BanTrucNho;
    public override string ToString() => $"Elip tam {base.ToString()}, ban truc lon = {BanTrucLon:0.##}, ban truc nho = {BanTrucNho:0.##}";
}

public class Circle : Ellipse
{
    public double BanKinh => BanTrucLon;
    public Circle(double x, double y, double radius) : base(x, y, radius, radius) { }
    public override double TinhDienTich() => Math.PI * BanKinh * BanKinh;
    public override string ToString() => $"Duong tron tam ({X:0.##}, {Y:0.##}), ban kinh = {BanKinh:0.##}";
}

public class Program
{
    private static double ReadNumber(string prompt)
    {
        Console.Write(prompt);
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) || double.IsNaN(x) || double.IsInfinity(x))
            Console.Write("Gia tri khong hop le. Nhap lai: ");
        return x;
    }
    private static double ReadPositive(string prompt)
    {
        double x;
        do { x = ReadNumber(prompt); if (x <= 0) Console.WriteLine("Gia tri phai > 0."); } while (x <= 0);
        return x;
    }
    public static void Main()
    {
        Console.WriteLine("NHAP ELIP");
        double x = ReadNumber("Tam x: "), y = ReadNumber("Tam y: ");
        Ellipse e = new Ellipse(x, y, ReadPositive("Ban truc lon: "), ReadPositive("Ban truc nho: "));
        Console.WriteLine(e); Console.WriteLine($"Dien tich elip = {e.TinhDienTich():0.##}");

        Console.WriteLine("NHAP DUONG TRON");
        double cx = ReadNumber("Tam x: "), cy = ReadNumber("Tam y: ");
        Circle c = new Circle(cx, cy, ReadPositive("Ban kinh: "));
        Console.WriteLine(c); Console.WriteLine($"Dien tich duong tron = {c.TinhDienTich():0.##}");
    }
}
