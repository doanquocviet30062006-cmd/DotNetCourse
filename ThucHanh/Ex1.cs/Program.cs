using System;

public class Student
{
    // Các backing fields cho properties
    private string maSV;
    private double diemTrungBinh;
    private int tuoi;
    private string lopHoc;

    // 1. Thuộc tính Mã sinh viên (read-only từ bên ngoài: set là private) - chứa 8 kí tự
    public string MaSV
    {
        get => maSV;
        private set
        {
            if (!string.IsNullOrEmpty(value) && value.Length == 8)
            {
                maSV = value;
            }
            else
            {
                Console.WriteLine("Lỗi: Mã sinh viên phải chứa đúng 8 kí tự!");
            }
        }
    }

    // Thuộc tính Điểm trung bình (read-only từ bên ngoài) - từ 0.0 – 10.0
    public double DiemTrungBinh
    {
        get => diemTrungBinh;
        private set
        {
            if (value >= 0.0 && value <= 10.0)
            {
                diemTrungBinh = value;
            }
            else
            {
                Console.WriteLine("Lỗi: Điểm trung bình phải từ 0.0 đến 10.0!");
            }
        }
    }

    // Thuộc tính Tuổi - Phải lớn hơn hoặc bằng 18
    public int Tuoi
    {
        get => tuoi;
        set
        {
            if (value >= 18)
            {
                tuoi = value;
            }
            else
            {
                Console.WriteLine("Lỗi: Tuổi phải lớn hơn hoặc bằng 18!");
            }
        }
    }

    // Thuộc tính Lớp học - Phải bắt đầu bởi kí tự 'A' hoặc 'C'
    public string LopHoc
    {
        get => lopHoc;
        set
        {
            if (!string.IsNullOrEmpty(value) && (char.ToUpper(value[0]) == 'A' || char.ToUpper(value[0]) == 'C'))
            {
                lopHoc = value;
            }
            else
            {
                Console.WriteLine("Lỗi: Lớp học phải bắt đầu bằng ký tự 'A' hoặc 'C'!");
            }
        }
    }

    // Constructor không tham số
    public Student()
    {
    }

    // Constructor đầy đủ tham số
    public Student(string maSV, double diemTrungBinh, int tuoi, string lopHoc)
    {
        MaSV = maSV;
        DiemTrungBinh = diemTrungBinh;
        Tuoi = tuoi;
        LopHoc = lopHoc;
    }

    // a. Phương thức InputInfo(), nhập thông tin Student từ bàn phím
    public void InputInfo()
    {
        // Nhập Mã sinh viên
        while (true)
        {
            Console.Write("Nhập mã sinh viên (8 kí tự): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Length == 8)
            {
                MaSV = input;
                break;
            }
            Console.WriteLine("Mã sinh viên không hợp lệ! Vui lòng nhập lại đúng 8 kí tự.");
        }

        // Nhập Điểm trung bình
        while (true)
        {
            Console.Write("Nhập điểm trung bình (0.0 - 10.0): ");
            if (double.TryParse(Console.ReadLine(), out double dtb) && dtb >= 0.0 && dtb <= 10.0)
            {
                DiemTrungBinh = dtb;
                break;
            }
            Console.WriteLine("Điểm trung bình không hợp lệ! Vui lòng nhập số từ 0.0 đến 10.0.");
        }

        // Nhập Tuổi
        while (true)
        {
            Console.Write("Nhập tuổi (>= 18): ");
            if (int.TryParse(Console.ReadLine(), out int age) && age >= 18)
            {
                Tuoi = age;
                break;
            }
            Console.WriteLine("Tuổi không hợp lệ! Sinh viên phải từ 18 tuổi trở lên.");
        }

        // Nhập Lớp học
        while (true)
        {
            Console.Write("Nhập lớp học (bắt đầu bằng 'A' hoặc 'C'): ");
            string inputClass = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputClass) && (char.ToUpper(inputClass[0]) == 'A' || char.ToUpper(inputClass[0]) == 'C'))
            {
                LopHoc = inputClass;
                break;
            }
            Console.WriteLine("Lớp học không hợp lệ! Tên lớp phải bắt đầu bằng 'A' hoặc 'C'.");
        }
    }

    // b. Phương thức ShowInfo(), hiển thị tất cả thông tin Student
    public void ShowInfo()
    {
        Console.WriteLine("\n--- THÔNG TIN SINH VIÊN ---");
        Console.WriteLine($"Mã sinh viên: {MaSV}");
        Console.WriteLine($"Điểm trung bình: {DiemTrungBinh}");
        Console.WriteLine($"Tuổi: {Tuoi}");
        Console.WriteLine($"Lớp học: {LopHoc}");
        Console.WriteLine($"Trạng thái học bổng: {(CheckHocBong() ? "Được học bổng" : "Không được học bổng")}");
    }

    // c. Phương thức xét xem Student có được học bổng không? (Điểm TB từ 8.0 trở lên)
    public bool CheckHocBong()
    {
        return DiemTrungBinh >= 8.0;
    }
}

// Chương trình chính để chạy thử
public class Program
{
    public static void Main(string[] args)
    {
        // Thiết lập mã hóa tiếng Việt cho console nếu cần
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Student sv = new Student();
        Console.WriteLine("Vui lòng nhập thông tin cho sinh viên:");
        sv.InputInfo();

        sv.ShowInfo();
    }
}