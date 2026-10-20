using System;

public class SoNguyenTo
{
    private int nguyenTo;

    public int NguyenTo
    {
        get { return nguyenTo; }
        set
        {
            if (IsSoNguyenTo(value))
                nguyenTo = value;
            else
                Console.WriteLine("Khong set: gia tri phai la so nguyen to.");
        }
    }

    // Constructor khong tham so: khoi tao bang so nguyen to 2.
    public SoNguyenTo()
    {
        nguyenTo = 2;
    }

    // Constructor mot tham so.
    public SoNguyenTo(int x)
    {
        if (IsSoNguyenTo(x))
            nguyenTo = x;
        else
        {
            nguyenTo = 2;
            Console.WriteLine($"{x} khong phai la so nguyen to, khong luu tru. Gia tri mac dinh la 2.");
        }
    }

    public bool IsSoNguyenTo(int x)
    {
        if (x < 2) return false;
        if (x == 2) return true;
        if (x % 2 == 0) return false;

        for (int i = 3; i <= x / i; i += 2)
        {
            if (x % i == 0) return false;
        }
        return true;
    }

    public int TimSoNguyenToTiepTheo()
    {
        if (nguyenTo == int.MaxValue)
            throw new InvalidOperationException("Khong con so nguyen to tiep theo trong pham vi int.");

        int candidate = nguyenTo + 1;
        while (!IsSoNguyenTo(candidate))
        {
            if (candidate == int.MaxValue)
                throw new InvalidOperationException("Khong tim thay so nguyen to tiep theo trong pham vi int.");
            candidate++;
        }
        return candidate;
    }
}

public class Program
{
    public static void Main()
    {
        SoNguyenTo so = new SoNguyenTo();
        Console.WriteLine("Gia tri mac dinh: " + so.NguyenTo);

        Console.Write("Nhap mot so nguyen to: ");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            SoNguyenTo so2 = new SoNguyenTo(x);
            Console.WriteLine("Gia tri dang luu: " + so2.NguyenTo);
            Console.WriteLine($"{x} la so nguyen to? {so.IsSoNguyenTo(x)}");
        }
        else
        {
            Console.WriteLine("Du lieu khong hop le.");
        }

        Console.Write("Nhap gia tri muon gan cho NguyenTo: ");
        if (int.TryParse(Console.ReadLine(), out int y)) so.NguyenTo = y;
        Console.WriteLine("NguyenTo hien tai: " + so.NguyenTo);
        Console.WriteLine("So nguyen to lien sau: " + so.TimSoNguyenToTiepTheo());
    }
}
