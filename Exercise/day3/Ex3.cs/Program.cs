
using System;

class Program
{
    static void Main(string[] args)
    {
        // a. Kiem tra khoa hoc dang ky
        Console.Write("Nhap khoa hoc dang ky: ");
        string khoaHoc = Console.ReadLine() ?? "";

        bool dangKyHDSE = khoaHoc.Trim().Equals(
            "HDSE", StringComparison.OrdinalIgnoreCase);

        // b. Nhap diem tong ket
        double diemTongKet;

        Console.Write("Nhap diem tong ket (0 - 100): ");
        while (!double.TryParse(Console.ReadLine(), out diemTongKet)
               || diemTongKet < 0 || diemTongKet > 100)
        {
            Console.Write("Diem khong hop le. Nhap lai (0 - 100): ");
        }

        // c. Kiem tra co vi pham noi quy khong
        bool viPham;
        while (true)
        {
            Console.Write("Co vi pham noi quy khong? (c/k): ");
            string traLoi = (Console.ReadLine() ?? "")
                .Trim().ToLower();

            if (traLoi == "c")
            {
                viPham = true;
                break;
            }
            else if (traLoi == "k")
            {
                viPham = false;
                break;
            }

            Console.WriteLine("Vui long nhap c (co) hoac k (khong)!");
        }

        // d. Kiem tra cac ky thi co thi lan dau tien khong
        bool thiLanDau;
        while (true)
        {
            Console.Write("Tat ca cac ky thi deu thi lan dau? (c/k): ");
            string traLoi = (Console.ReadLine() ?? "")
                .Trim().ToLower();

            if (traLoi == "c")
            {
                thiLanDau = true;
                break;
            }
            else if (traLoi == "k")
            {
                thiLanDau = false;
                break;
            }

            Console.WriteLine("Vui long nhap c (co) hoac k (khong)!");
        }

        // Kiem tra du 4 dieu kien hoc bong
        if (dangKyHDSE && diemTongKet >= 75
            && !viPham && thiLanDau)
        {
            Console.WriteLine("Chuc mung! Ban duoc nhan hoc bong.");
        }
        else
        {
            Console.WriteLine("Ban khong du dieu kien nhan hoc bong.");
        }

        Console.ReadKey();
    }
}
