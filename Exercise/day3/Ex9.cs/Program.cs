using System;
using System.Globalization;

public class ComplexNumber
{
    public double PhanThuc { get; set; }
    public double PhanAo { get; set; }

    public ComplexNumber() { }
    public ComplexNumber(double phanThuc, double phanAo) { PhanThuc = phanThuc; PhanAo = phanAo; }

    public ComplexNumber Cong(ComplexNumber z) => new ComplexNumber(PhanThuc + z.PhanThuc, PhanAo + z.PhanAo);
    public ComplexNumber Tru(ComplexNumber z) => new ComplexNumber(PhanThuc - z.PhanThuc, PhanAo - z.PhanAo);
    public ComplexNumber Nhan(ComplexNumber z) => new ComplexNumber(
        PhanThuc * z.PhanThuc - PhanAo * z.PhanAo,
        PhanThuc * z.PhanAo + PhanAo * z.PhanThuc);
    public ComplexNumber Chia(ComplexNumber z)
    {
        double denominator = z.PhanThuc * z.PhanThuc + z.PhanAo * z.PhanAo;
        if (denominator == 0) throw new DivideByZeroException("Khong the chia cho so phuc 0.");
        return new ComplexNumber(
            (PhanThuc * z.PhanThuc + PhanAo * z.PhanAo) / denominator,
            (PhanAo * z.PhanThuc - PhanThuc * z.PhanAo) / denominator);
    }

    public static ComplexNumber Nhap(string ten)
    {
        Console.WriteLine($"Nhap {ten}:");
        return new ComplexNumber(ReadDouble("Phan thuc: "), ReadDouble("Phan ao: "));
    }

    private static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) ||
               double.IsNaN(x) || double.IsInfinity(x)) Console.Write("So khong hop le. Nhap lai: ");
        return x;
    }

    public override string ToString()
    {
        string real = PhanThuc.ToString("0.##", CultureInfo.CurrentCulture);
        string imag = Math.Abs(PhanAo).ToString("0.##", CultureInfo.CurrentCulture);
        if (PhanAo == 0) return real;
        if (PhanThuc == 0) return (PhanAo < 0 ? "-" : "") + imag + "i";
        return real + (PhanAo < 0 ? " - " : " + ") + imag + "i";
    }
}

public class Program
{
    public static void Main()
    {
        ComplexNumber a = ComplexNumber.Nhap("so phuc A");
        ComplexNumber b = ComplexNumber.Nhap("so phuc B");
        Console.WriteLine($"A = {a}; B = {b}");
        Console.WriteLine("A + B = " + a.Cong(b));
        Console.WriteLine("A - B = " + a.Tru(b));
        Console.WriteLine("A * B = " + a.Nhan(b));
        try { Console.WriteLine("A / B = " + a.Chia(b)); }
        catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
    }
}
