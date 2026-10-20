using System;

public class MyPoint
{
    private int x;
    private int y;
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public MyPoint() : this(0, 0) { }
    public MyPoint(int x, int y) { this.x = x; this.y = y; }
    public int GetX() => x;
    public int GetY() => y;
    public void SetX(int x) => this.x = x;
    public void SetY(int y) => this.y = y;
    public void SetXY(int x, int y) { this.x = x; this.y = y; }
    public int[] GetXY() => new[] { x, y };
    public double Distance(int x, int y)
    {
        double dx = this.x - x, dy = this.y - y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public double Distance(MyPoint another)
    {
        if (another == null) throw new ArgumentNullException(nameof(another));
        return Distance(another.x, another.y);
    }
    public override string ToString() => $"({x}, {y})";
}

public class MyCircle
{
    private MyPoint center;
    private int radius;
    public MyPoint Center { get => center; set => center = value ?? throw new ArgumentNullException(nameof(value)); }
    public int Radius
    {
        get => radius;
        set { if (value < 0) throw new ArgumentException("Ban kinh khong duoc am."); radius = value; }
    }
    public MyCircle(int x, int y, int radius) : this(new MyPoint(x, y), radius) { }
    public MyCircle(MyPoint center, int radius)
    {
        Center = center; Radius = radius;
    }
    public MyPoint GetCenter() => Center;
    public void SetCenter(MyPoint point) => Center = point;
    public int GetRadius() => Radius;
    public void SetRadius(int value) => Radius = value;
    public double GetArea() => Math.PI * radius * radius;
    public override string ToString() => $"Hinh tron @ {Center}, ban kinh = {Radius}";
}

public class Program
{
    public static void Main()
    {
        MyPoint p1 = new MyPoint(3, 0);
        MyPoint p2 = new MyPoint(0, 4);
        Console.WriteLine("p1 = " + p1);
        Console.WriteLine("p2 = " + p2);
        Console.WriteLine("Khoang cach p1 den p2 = " + p1.Distance(p2));
        Console.WriteLine("Khoang cach p1 den (5, 6) = " + p1.Distance(5, 6));

        MyCircle c1 = new MyCircle(2, 3, 5);
        MyCircle c2 = new MyCircle(new MyPoint(0, 0), 4);
        Console.WriteLine(c1);
        Console.WriteLine($"Dien tich c1 = {c1.GetArea():0.##}");
        Console.WriteLine(c2);
        Console.WriteLine($"Dien tich c2 = {c2.GetArea():0.##}");
    }
}
