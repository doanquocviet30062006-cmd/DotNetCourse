
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create at least 3 students
        List<Student> students = new List<Student>
        {
            new Student(
                "SV001", "Nguyen Van An", 2005, "CNTT K22",
                8.5, 9.0, 8.0),

            new Student(
                "SV002", "Tran Thi Binh", 2004, "CNTT K22",
                9.0, 8.5, 9.5),

            new Student(
                "SV003", "Le Van Cuong", 2005, "CNTT K23",
                6.0, 7.0, 6.5)
        };

        // Print each student's information
        foreach (Student student in students)
        {
            student.PrintInfo();
            Console.WriteLine();
        }

        // Find the student with the highest average score
        Student topStudent = students
            .OrderByDescending(s => s.GetAverageScore())
            .First();

        Console.WriteLine("\n===== TOP STUDENT =====");
        Console.WriteLine($"Name: {topStudent.FullName}");
        Console.WriteLine($"Student ID: {topStudent.StudentId}");
        Console.WriteLine(
            $"Average Score: {topStudent.GetAverageScore():F2}");
        Console.WriteLine($"Rank: {topStudent.GetRank()}");
    }
}
