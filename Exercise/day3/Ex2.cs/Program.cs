
using System;

class NhanVien
{
    // 1. Khai bao cac truong private
    private string ten;
    private int tuoi;
    private string diaChi;
    private double tienLuong;
    private int tongSoGioLam;

    // 2. Property cho tat ca cac truong
    public string Ten
    {
        get { return ten; }
        set { ten = value; }
    }

    public int Tuoi
    {
        get { return tuoi; }
        set { tuoi = value; }
    }

    public string DiaChi
    {
        get { return diaChi; }
        set { diaChi = value; }
    }

    public double TienLuong
    {
        get { return tienLuong; }
        set { tienLuong = value; }
    }

    public int TongSoGioLam
    {
        get { return tongSoGioLam; }
        set { tongSoGioLam = value; }
    }

    // 3. Constructor khong tham so
    public NhanVien()
    {
        ten = "";
        tuoi = 0;
        diaChi = "";
        tienLuong = 0;
        tongSoGioLam = 0;
    }

    // 4. Constructor day du tham so
    public NhanVien(string ten, int tuoi, string diaChi,
                    double tienLuong, int tongSoGioLam)
    {
        this.ten = ten;
        this.tuoi = tuoi;
        this.diaChi = diaChi;
        this.tienLuong = tienLuong;
        this.tongSoGioLam = tongSoGioLam;
    }

    // 5. Nhap thong tin nhan vien
    public void InputInfo()
    {
        Console.Write("Nhap ten nhan vien: ");
        ten = Console.ReadLine() ?? "";

        Console.Write("Nhap tuoi: ");
        tuoi = int.Parse(Console.ReadLine()!);

        Console.Write("Nhap dia chi: ");
        diaChi = Console.ReadLine() ?? "";

        Console.Write("Nhap tien luong: ");
        tienLuong = double.Parse(Console.ReadLine()!);

        Console.Write("Nhap tong so gio lam: ");
        tongSoGioLam = int.Parse(Console.ReadLine()!);
    }

    // 6. In thong tin nhan vien
    public void PrintInfo()
    {
        Console.WriteLine("Ten nhan vien: " + ten);
        Console.WriteLine("Tuoi: " + tuoi);
        Console.WriteLine("Dia chi: " + diaChi);
        Console.WriteLine("Tien luong: " + tienLuong);
        Console.WriteLine("Tong so gio lam: " + tongSoGioLam);
        Console.WriteLine("Tien thuong: " + TinhThuong());
    }

    // 7. Tinh tien thuong
    public double TinhThuong()
    {
        if (tongSoGioLam >= 200)
        {
            return tienLuong * 0.20;
        }
        else if (tongSoGioLam >= 100)
        {
            return tienLuong * 0.10;
        }
        else
        {
            return 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tao doi tuong nhan vien
        NhanVien nv = new NhanVien();

        // Nhap thong tin
        nv.InputInfo();

        // In thong tin va tien thuong
        Console.WriteLine("\n===== THONG TIN NHAN VIEN =====");
        nv.PrintInfo();

        Console.ReadKey();
    }
}
