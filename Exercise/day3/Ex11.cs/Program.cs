using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class Polynomial
{
    // coefficients[i] la he so cua x^i.
    private double[] coefficients;
    public int Degree => coefficients.Length - 1;

    public Polynomial(double[] values)
    {
        if (values == null || values.Length == 0) throw new ArgumentException("Da thuc can it nhat mot he so.");
        int last = values.Length - 1;
        while (last > 0 && Math.Abs(values[last]) < 1e-12) last--;
        coefficients = new double[last + 1];
        Array.Copy(values, coefficients, last + 1);
    }

    public static Polynomial Input(string name)
    {
        Console.Write($"Nhap bac cua da thuc {name} (>= 0): ");
        int degree;
        while (!int.TryParse(Console.ReadLine(), out degree) || degree < 0 || degree > 100)
            Console.Write("Bac phai tu 0 den 100. Nhap lai: ");
        double[] c = new double[degree + 1];
        for (int i = degree; i >= 0; i--)
        {
            Console.Write($"He so cua x^{i}: ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out c[i]) || double.IsNaN(c[i]) || double.IsInfinity(c[i]))
                Console.Write("He so khong hop le. Nhap lai: ");
        }
        return new Polynomial(c);
    }

    public Polynomial Add(Polynomial other)
    {
        double[] result = new double[Math.Max(coefficients.Length, other.coefficients.Length)];
        for (int i = 0; i < result.Length; i++)
            result[i] = GetCoefficient(i) + other.GetCoefficient(i);
        return new Polynomial(result);
    }

    public Polynomial Multiply(Polynomial other)
    {
        double[] result = new double[coefficients.Length + other.coefficients.Length - 1];
        for (int i = 0; i < coefficients.Length; i++)
            for (int j = 0; j < other.coefficients.Length; j++)
                result[i + j] += coefficients[i] * other.coefficients[j];
        return new Polynomial(result);
    }

    private double GetCoefficient(int i) => i < coefficients.Length ? coefficients[i] : 0;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = Degree; i >= 0; i--)
        {
            double c = coefficients[i];
            if (Math.Abs(c) < 1e-12) continue;
            if (sb.Length > 0) sb.Append(c < 0 ? " - " : " + ");
            else if (c < 0) sb.Append("-");
            double abs = Math.Abs(c);
            if (i == 0 || Math.Abs(abs - 1) > 1e-12) sb.Append(abs.ToString("0.##", CultureInfo.CurrentCulture));
            if (i >= 1)
            {
                if (Math.Abs(abs - 1) > 1e-12) sb.Append("*");
                sb.Append("x");
                if (i > 1) sb.Append("^").Append(i);
            }
        }
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        Polynomial a = Polynomial.Input("A");
        Polynomial b = Polynomial.Input("B");
        Console.WriteLine("A(x) = " + a);
        Console.WriteLine("B(x) = " + b);
        Console.WriteLine("A(x) + B(x) = " + a.Add(b));
        Console.WriteLine("A(x) * B(x) = " + a.Multiply(b));
    }
}
