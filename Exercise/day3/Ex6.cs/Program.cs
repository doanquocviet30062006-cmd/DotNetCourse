using System;
using System.Globalization;

public class Triangle
{
    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    public Triangle(double a, double b, double c)
    {
        SetSides(a, b, c);
    }

    public void SetSides(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0 ||
            a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Ba canh khong tao thanh tam giac hop le.");
        A = a; B = b; C = c;
    }

    public void InputInfo()
    {
        while (true)
        {
            Console.Write("Nhap canh a: ");
            double a = ReadDouble();
            Console.Write("Nhap canh b: ");
            double b = ReadDouble();
            Console.Write("Nhap canh c: ");
            double c = ReadDouble();
            try { SetSides(a, b, c); return; }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message + " Hay nhap lai."); }
        }
    }

    private static double ReadDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out double value) &&
                !double.IsNaN(value) && !double.IsInfinity(value) && value > 0)
                return value;

            Console.Write("Gia tri phai la so duong. Nhap lai: ");
        }
    }

    public string XacDinhLoaiTamGiac()
    {
        const double eps = 1e-8;
        bool ab = Math.Abs(A - B) < eps;
        bool bc = Math.Abs(B - C) < eps;
        bool ac = Math.Abs(A - C) < eps;
        if (ab && bc) return "Tam giac deu";

        double[] s = { A, B, C };
        Array.Sort(s);
        bool right = Math.Abs(s[0] * s[0] + s[1] * s[1] - s[2] * s[2]) < eps * Math.Max(1, s[2] * s[2]);
        bool isosceles = ab || bc || ac;
        if (right && isosceles) return "Tam giac vuong can";
        if (right) return "Tam giac vuong";
        if (isosceles) return "Tam giac can";
        return "Tam giac thuong";
    }

    public double TinhChuVi() => A + B + C;

    public double TinhDienTich()
    {
        double p = TinhChuVi() / 2.0;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}

public class Program
{
    public static void Main()
    {
        Triangle triangle = new Triangle(3, 4, 5);
        triangle.InputInfo();
        Console.WriteLine("Loai: " + triangle.XacDinhLoaiTamGiac());
        Console.WriteLine("Chu vi: " + triangle.TinhChuVi().ToString("0.##"));
        Console.WriteLine("Dien tich: " + triangle.TinhDienTich().ToString("0.##"));
    }
}
