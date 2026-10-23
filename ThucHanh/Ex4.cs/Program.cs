using System;
class PhanLoai
{
    static void Main(string[] args)
    {
        double score = 7.5;
        if(score >=5.0 && score < 8.0)
        {
            Console.WriteLine("Kha");
        }
        else if(score >= 8.0)
        {
            Console.WriteLine("Gioi");
        }
        else
        {
            Console.WriteLine("Chua dat");
        }

        Console.ReadKey();
    }
}