using System;
using System.Globalization;

public class Matrix
{
    private readonly double[,] data;
    public int Rows { get; }
    public int Columns { get; }

    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0) throw new ArgumentException("Kich thuoc ma tran phai duong.");
        Rows = rows; Columns = columns; data = new double[rows, columns];
    }

    public static Matrix Input(string name)
    {
        Console.WriteLine($"Nhap ma tran {name}:");
        int rows = ReadPositiveInt("So dong: ");
        int columns = ReadPositiveInt("So cot: ");
        Matrix m = new Matrix(rows, columns);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                m.data[i, j] = ReadDouble($"[{i + 1},{j + 1}] = ");
        return m;
    }

    public Matrix Add(Matrix other)
    {
        if (Rows != other.Rows || Columns != other.Columns)
            throw new InvalidOperationException("Khong the cong hai ma tran khac kich thuoc.");
        Matrix result = new Matrix(Rows, Columns);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++) result.data[i, j] = data[i, j] + other.data[i, j];
        return result;
    }

    public Matrix Multiply(Matrix other)
    {
        if (Columns != other.Rows)
            throw new InvalidOperationException("So cot cua A phai bang so dong cua B de nhan ma tran.");
        Matrix result = new Matrix(Rows, other.Columns);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < other.Columns; j++)
                for (int k = 0; k < Columns; k++) result.data[i, j] += data[i, k] * other.data[k, j];
        return result;
    }

    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++) Console.Write($"{data[i, j],10:0.##}");
            Console.WriteLine();
        }
    }

    private static int ReadPositiveInt(string prompt)
    {
        Console.Write(prompt);
        int x;
        while (!int.TryParse(Console.ReadLine(), out x) || x <= 0 || x > 50)
            Console.Write("Nhap so nguyen tu 1 den 50: ");
        return x;
    }
    private static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        double x;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out x) || double.IsNaN(x) || double.IsInfinity(x))
            Console.Write("So khong hop le. Nhap lai: ");
        return x;
    }
}

public class Program
{
    public static void Main()
    {
        Matrix a = Matrix.Input("A");
        Matrix b = Matrix.Input("B");
        Console.WriteLine("Ma tran A:"); a.Print();
        Console.WriteLine("Ma tran B:"); b.Print();
        try { Console.WriteLine("A + B:"); a.Add(b).Print(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
        try { Console.WriteLine("A * B:"); a.Multiply(b).Print(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
    }
}
