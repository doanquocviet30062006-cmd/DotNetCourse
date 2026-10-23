using System;
using System.Data.Common;
using System.Collections.Generic;
public class Student
{
    public int Id;
    public string Name;
    public int YearOfBirth;

    public Student(int Id, string Name, int YearOfBirth)
    {
        this.Id = Id;
        this.Name = Name;
        this.YearOfBirth = YearOfBirth;
    }
}
class Program
{
    // Them sinh vien vao danh sach va hien thi danh sach sinh vien
    static void addStudents(string[] args)
    {
        List<Student> student = new List<Student>();
        student.Add(new Student(1, "Nguyen Van A", 2000));
        student.Add(new Student(2, "Nguyen Van B", 2001));
        student.Add(new Student(3, "Nguyen Van C", 2002));

        Console.WriteLine("Danh sach sinh vien:");
        foreach (Student s in student)
        {
            Console.WriteLine("Id: " + s.Id + ", Name: " + s.Name + ", YearOfBirth: " + s.YearOfBirth);
        }
        Console.ReadKey();
    }
    // Xoa sinh vien theo Id va hien thi danh sach sinh vien
    static void removeStudents(string[] args)
    {
        Console.Write("Nhap Id sinh vien can xoa: ");
        

    }
}

