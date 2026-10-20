using System;
using System.Globalization;

public class Vector2D
{
    public double XDau { get; }
    public double YDau { get; }
    public double XCuoi { get; }
    public double YCuoi { get; }
    public double X => XCuoi - XDau;
    public double Y => YCuoi - YDau;

    public Vector2D(double xDau, double yDau, double xCuoi, double yCuoi)
    { XDau = xDau; YDau = yDau; XCuoi = xCuoi; YCuoi = yCuoi; }

    public double Module() => Math.Sqrt(X * X + Y * Y);
    public bool BangNhau(Vector2D other) => GanBang(X, other.X) && GanBang(Y, other.Y);
    public bool CungPhuong(Vector2D other) => Math.Abs(X * other.Y - Y * other.X) < 1e-9;
    public double TichVoHuong(Vector2D other) => X * other.X + Y * other.Y;
    public double TichCoHuong2D(Vector2D other) => X * other.Y - Y * other.X;

    public double GocVoi(Vector2D other)
    {
        double m1 = Module(), m2 = other.Module();
        if (m1 == 0 || m2 == 0) throw new InvalidOperationException("Khong xac dinh goc voi vectơ khong.");
        double cos = TichVoHuong(other) / (m1 * m2);
        cos = Math.Max(-1, Math.Min(1, cos));
        return Math.Acos(cos) * 180.0 / Math.PI;
    }

    public Vector2D Cong(Vector2D other) => new Vector2D(0, 0, X + other.X, Y + other.Y);
    public Vector2D Tru(Vector2D other) => new Vector2D(0, 0, X - other.X, Y - other.Y);
    private static bool GanBang(double a, double b) => Math.Abs(a - b) < 1e-9;

    public static Vector2D Nhap(string ten)
    {
        Console.WriteLine($"Nhap toa do dau va cuoi cua vectơ {ten}:");
        return new Vector2D(Read("x dau: "), Read("y dau: "), Read("x cuoi: "), Read("y cuoi: "));
    }
    private static double Read(string prompt)
    {
        Console.Write(prompt);
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) || double.IsNaN(x) || double.IsInfinity(x))
            Console.Write("Gia tri khong hop le. Nhap lai: ");
        return x;
    }
    public override string ToString() => $"({X:0.##}, {Y:0.##})";
}

public class Program
{
    public static void Main()
    {
        Vector2D a = Vector2D.Nhap("A");
        Vector2D b = Vector2D.Nhap("B");
        Console.WriteLine($"A = {a}, |A| = {a.Module():0.##}");
        Console.WriteLine($"B = {b}, |B| = {b.Module():0.##}");
        Console.WriteLine("Hai vectơ bang nhau? " + a.BangNhau(b));
        Console.WriteLine("Hai vectơ cung phuong? " + a.CungPhuong(b));
        Console.WriteLine("A + B = " + a.Cong(b));
        Console.WriteLine("A - B = " + a.Tru(b));
        Console.WriteLine("Tich vo huong A.B = " + a.TichVoHuong(b));
        Console.WriteLine("Tich co huong 2D = " + a.TichCoHuong2D(b));
        try { Console.WriteLine($"Goc giua A va B = {a.GocVoi(b):0.##} do"); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
    }
}
