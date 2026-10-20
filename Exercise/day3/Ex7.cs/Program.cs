using System;
using System.Globalization;

public class Rectangle
{
    public double ChieuDai { get; private set; }
    public double ChieuRong { get; private set; }

    public Rectangle(double chieuDai, double chieuRong) { SetDimensions(chieuDai, chieuRong); }

    public void SetDimensions(double chieuDai, double chieuRong)
    {
        if (chieuDai <= 0 || chieuRong <= 0)
            throw new ArgumentException("Chieu dai va chieu rong phai lon hon 0.");
        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public void InputInfo()
    {
        Console.Write("Nhap chieu dai: ");
        double d = ReadPositiveDouble();
        Console.Write("Nhap chieu rong: ");
        double r = ReadPositiveDouble();
        SetDimensions(d, r);
    }

    private static double ReadPositiveDouble()
    {
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) ||
               double.IsNaN(x) || double.IsInfinity(x) || x <= 0)
            Console.Write("Vui long nhap so duong hop le: ");
        return x;
    }

    public double TinhDienTich() => ChieuDai * ChieuRong;
    public double TinhChuVi() => 2 * (ChieuDai + ChieuRong);
}

public class Program
{
    public static void Main()
    {
        Rectangle hcn = new Rectangle(1, 1);
        hcn.InputInfo();
        Console.WriteLine($"Dien tich = {hcn.TinhDienTich():0.##}");
        Console.WriteLine($"Chu vi = {hcn.TinhChuVi():0.##}");
    }
}
