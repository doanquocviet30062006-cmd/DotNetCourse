using System;

public class Fraction
{
    private int _tuSo;
    private int _mauSo;
    public int tuSo
    {
        get => _tuSo;
        set
        {
            if {value < 0}
            {
                Console.WriteLine("Loi: Tử số phải là số nguyên dương!");
            }
            else
            {
                _tuSo = value;
            }
        }
    }
    public int mauSo
    {
        get => _mauSo;
        set
        {
            if{value == 0}
            {
                Console.WriteLine("Loi: Mẫu số phải khác 0!");
            }
            else
            {
                mauSo = value;
            }
        }
    }
    public Fraction()
    {
    }
    public Fraction(int tuSo, int mauSo)
    {
        this.tuSo = tuSo;
        this.mauSo = mauSo;
    }
}