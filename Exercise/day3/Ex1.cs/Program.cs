
using System;

class SoHoc
{
    // 1. Khai báo các trường private
    private float number1;
    private float number2;

    // 2. Khai báo Property cho các trường
    public float Number1
    {
        get { return number1; }
        set { number1 = value; }
    }

    public float Number2
    {
        get { return number2; }
        set { number2 = value; }
    }

    // 3. Hàm tạo không tham số
    public SoHoc()
    {
        number1 = 0;
        number2 = 0;
    }

    // 4. Hàm tạo đầy đủ tham số
    public SoHoc(float number1, float number2)
    {
        this.number1 = number1;
        this.number2 = number2;
    }

    // 5. Nhập thông tin
    public void InputInfo()
    {
        Console.Write("Nhap number1: ");
        while (!float.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Du lieu khong hop le. Nhap lai number1: ");
        }

        Console.Write("Nhap number2: ");
        while (!float.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Du lieu khong hop le. Nhap lai number2: ");
        }
    }

    // 6. Hiển thị thông tin
    public void PrintInfo()
    {
        Console.WriteLine("number1 = " + number1);
        Console.WriteLine("number2 = " + number2);
    }

    // 7. Phép cộng
    public float Addition()
    {
        return number1 + number2;
    }

    // 8. Phép trừ
    public float Subtract()
    {
        return number1 - number2;
    }

    // 9. Phép nhân
    public float Multi()
    {
        return number1 * number2;
    }

    // 10. Phép chia
    public float Division()
    {
        if (number2 == 0)
        {
            throw new DivideByZeroException("Khong the chia cho 0!");
        }

        return number1 / number2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng SoHoc
        SoHoc sh = new SoHoc();

        // Nhập hai số
        sh.InputInfo();

        // Hiển thị hai số
        Console.WriteLine("\nThong tin hai so:");
        sh.PrintInfo();

        // Hiển thị kết quả các phép toán
        Console.WriteLine("\nKet qua cac phep toan:");
        Console.WriteLine("Tong = " + sh.Addition());
        Console.WriteLine("Hieu = " + sh.Subtract());
        Console.WriteLine("Tich = " + sh.Multi());

        if (sh.Number2 != 0)
        {
            Console.WriteLine("Thuong = " + sh.Division());
        }
        else
        {
            Console.WriteLine("Khong the chia cho 0!");
        }
    }
}
