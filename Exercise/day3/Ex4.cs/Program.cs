
using System;
using System.Globalization;

class Student
{
    // 1. Cac Property
    // Ma sinh vien va diem trung binh chi doc tu ben ngoai
    public string MaSinhVien { get; private set; }
    public double DiemTrungBinh { get; private set; }

    // Tuoi phai >= 18
    private int tuoi;
    public int Tuoi
    {
        get { return tuoi; }
        set
        {
            if (value < 18)
                throw new ArgumentException("Tuoi phai >= 18!");

            tuoi = value;
        }
    }

    // Lop hoc phai bat dau bang A hoac C
    private string lopHoc;
    public string LopHoc
    {
        get { return lopHoc; }
        set
        {
            string lop = (value ?? "").Trim().ToUpperInvariant();

            if (lop.Length == 0 ||
                (lop[0] != 'A' && lop[0] != 'C'))
            {
                throw new ArgumentException(
                    "Lop hoc phai bat dau bang A hoac C!");
            }

            lopHoc = lop;
        }
    }

    // 2. Constructor khong tham so
    public Student() : this("00000000", 0.0, 18, "A")
    {
    }

    // 3. Constructor day du tham so
    public Student(string maSinhVien, double diemTrungBinh,
                   int tuoi, string lopHoc)
    {
        string ma = (maSinhVien ?? "").Trim();

        if (ma.Length != 8)
            throw new ArgumentException(
                "Ma sinh vien phai co dung 8 ky tu!");

        if (double.IsNaN(diemTrungBinh) ||
            double.IsInfinity(diemTrungBinh) ||
            diemTrungBinh < 0 || diemTrungBinh > 10)
        {
            throw new ArgumentException(
                "Diem trung binh phai tu 0 den 10!");
        }

        MaSinhVien = ma;
        DiemTrungBinh = diemTrungBinh;
        Tuoi = tuoi;
        LopHoc = lopHoc;
    }

    // 4. Nhap thong tin
    public void InputInfo()
    {
        string ma;

        Console.Write("Nhap ma sinh vien (8 ky tu): ");
        ma = (Console.ReadLine() ?? "").Trim();

        while (ma.Length != 8)
        {
            Console.Write("Ma phai co dung 8 ky tu. Nhap lai: ");
            ma = (Console.ReadLine() ?? "").Trim();
        }

        MaSinhVien = ma;

        // Nhap diem trung binh
        double diem;
        while (true)
        {
            Console.Write("Nhap diem trung binh (0.0 - 10.0): ");
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out diem)
                && !double.IsNaN(diem)
                && !double.IsInfinity(diem)
                && diem >= 0 && diem <= 10)
            {
                break;
            }

            Console.WriteLine("Diem khong hop le! Nhap lai.");
        }

        DiemTrungBinh = diem;

        // Nhap tuoi
        int tuoiNhap;
        while (true)
        {
            Console.Write("Nhap tuoi (>= 18): ");
            if (int.TryParse(Console.ReadLine(), out tuoiNhap)
                && tuoiNhap >= 18)
            {
                break;
            }

            Console.WriteLine("Tuoi khong hop le! Nhap lai.");
        }

        Tuoi = tuoiNhap;

        // Nhap lop hoc
        string lop;
        while (true)
        {
            Console.Write("Nhap lop hoc (bat dau bang A hoac C): ");
            lop = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

            if (lop.Length > 0 &&
                (lop[0] == 'A' || lop[0] == 'C'))
            {
                break;
            }

            Console.WriteLine("Lop hoc khong hop le! Nhap lai.");
        }

        LopHoc = lop;
    }

    // 5. Hien thi thong tin
    public void ShowInfo()
    {
        Console.WriteLine("Ma sinh vien: " + MaSinhVien);
        Console.WriteLine("Diem trung binh: " +
            DiemTrungBinh.ToString("0.0",
                CultureInfo.InvariantCulture));
        Console.WriteLine("Tuoi: " + Tuoi);
        Console.WriteLine("Lop hoc: " + LopHoc);

        if (DuocHocBong())
            Console.WriteLine("Ket qua: Duoc hoc bong");
        else
            Console.WriteLine("Ket qua: Khong duoc hoc bong");
    }

    // 6. Kiem tra hoc bong
    public bool DuocHocBong()
    {
        return DiemTrungBinh >= 8.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student sv = new Student();

        sv.InputInfo();

        Console.WriteLine("\n===== THONG TIN SINH VIEN =====");
        sv.ShowInfo();

        Console.ReadKey();
    }
}
