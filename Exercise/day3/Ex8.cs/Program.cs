using System;

public class Fraction
{
    private long tuSo;
    private long mauSo;

    public long TuSo { get => tuSo; set => tuSo = value; }
    public long MauSo
    {
        get => mauSo;
        set
        {
            if (value == 0) throw new ArgumentException("Mau so khong duoc bang 0.");
            mauSo = value;
        }
    }

    public Fraction() { tuSo = 0; mauSo = 1; }
    public Fraction(long tuSo, long mauSo)
    {
        if (mauSo == 0) throw new ArgumentException("Mau so khong duoc bang 0.");
        this.tuSo = tuSo;
        this.mauSo = mauSo;
        RutGon();
    }

    public void InputFraction()
    {
        Console.Write("Nhap tu so: ");
        while (!long.TryParse(Console.ReadLine(), out tuSo)) Console.Write("Tu so khong hop le. Nhap lai: ");
        Console.Write("Nhap mau so (khac 0): ");
        while (!long.TryParse(Console.ReadLine(), out mauSo) || mauSo == 0)
            Console.Write("Mau so phai la so nguyen khac 0. Nhap lai: ");
        RutGon();
    }

    public void PrintFraction() => Console.WriteLine(ToString());

    public void RutGon()
    {
        if (mauSo < 0) { tuSo = -tuSo; mauSo = -mauSo; }
        long gcd = GCD(Math.Abs(tuSo), Math.Abs(mauSo));
        if (gcd != 0) { tuSo /= gcd; mauSo /= gcd; }
    }

    public Fraction NghichDao()
    {
        if (tuSo == 0) throw new DivideByZeroException("Phan so 0 khong co nghich dao.");
        return new Fraction(mauSo, tuSo);
    }

    public Fraction Add(Fraction other) => new Fraction(tuSo * other.mauSo + other.tuSo * mauSo, mauSo * other.mauSo);
    public Fraction Sub(Fraction other) => new Fraction(tuSo * other.mauSo - other.tuSo * mauSo, mauSo * other.mauSo);
    public Fraction Mul(Fraction other) => new Fraction(tuSo * other.tuSo, mauSo * other.mauSo);
    public Fraction Div(Fraction other)
    {
        if (other.tuSo == 0) throw new DivideByZeroException("Khong the chia cho phan so 0.");
        return new Fraction(tuSo * other.mauSo, mauSo * other.tuSo);
    }

    private static long GCD(long a, long b)
    {
        while (b != 0) { long r = a % b; a = b; b = r; }
        return a == 0 ? 1 : a;
    }

    public override string ToString() => mauSo == 1 ? tuSo.ToString() : $"{tuSo}/{mauSo}";
}

public class Program
{
    public static void Main()
    {
        Fraction a = new Fraction();
        Fraction b = new Fraction();
        Console.WriteLine("Nhap phan so thu nhat:"); a.InputFraction();
        Console.WriteLine("Nhap phan so thu hai:"); b.InputFraction();
        Console.WriteLine($"A = {a}; B = {b}");
        Console.WriteLine($"A + B = {a.Add(b)}");
        Console.WriteLine($"A - B = {a.Sub(b)}");
        Console.WriteLine($"A * B = {a.Mul(b)}");
        try { Console.WriteLine($"A / B = {a.Div(b)}"); }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
        try { Console.WriteLine($"Nghich dao A = {a.NghichDao()}"); }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
    }
}
