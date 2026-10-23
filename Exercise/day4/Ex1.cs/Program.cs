
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double AverageScore { get; set; }

    public Student(int id, string name, double averageScore)
    {
        Id = id;
        Name = name;
        AverageScore = averageScore;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Score: {AverageScore:F2}";
    }
}

// Ngoại lệ khi ID bị trùng
public class DuplicateStudentException : Exception
{
    public DuplicateStudentException(string message)
        : base(message) { }
}

// Ngoại lệ khi không tìm thấy sinh viên
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message)
        : base(message) { }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void AddStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);

        if (students.Any(s => s.Id == id))
            throw new DuplicateStudentException(
                $"Student ID {id} already exists.");

        Console.Write("Enter name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter average score (0-10): ");
        double score = double.Parse(Console.ReadLine()!);

        if (score < 0 || score > 10)
            throw new ArgumentOutOfRangeException(
                nameof(score), "Score must be between 0 and 10.");

        students.Add(new Student(id, name, score));
        Console.WriteLine("Student added successfully.");
    }

    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("The student list is empty.");
            return;
        }

        foreach (Student student in students)
            Console.WriteLine(student);
    }

    static Student FindStudent(int id)
    {
        Student? student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            throw new StudentNotFoundException(
                $"Student with ID {id} was not found.");

        return student;
    }

    static void FindStudentById()
    {
        Console.Write("Enter ID to find: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine(FindStudent(id));
    }

    static void RemoveStudent()
    {
        Console.Write("Enter ID to remove: ");
        int id = int.Parse(Console.ReadLine()!);

        Student student = FindStudent(id);
        students.Remove(student);

        Console.WriteLine("Student removed successfully.");
    }

    static void UpdateStudentName()
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine()!);

        Student student = FindStudent(id);

        Console.Write("Enter new name: ");
        string name = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        student.Name = name;
        Console.WriteLine("Student name updated successfully.");
    }

    static void ShowHighestScore()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("The student list is empty.");
            return;
        }

        double highestScore = students.Max(s => s.AverageScore);

        foreach (Student student in students
                     .Where(s => s.AverageScore == highestScore))
        {
            Console.WriteLine(student);
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== STUDENT MANAGEMENT =====");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Display the list");
            Console.WriteLine("3. Find a student by ID");
            Console.WriteLine("4. Remove a student by ID");
            Console.WriteLine("5. Update a student's name");
            Console.WriteLine("6. Show student(s) with highest average score");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            try
            {
                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        FindStudentById();
                        break;
                    case 4:
                        RemoveStudent();
                        break;
                    case 5:
                        UpdateStudentName();
                        break;
                    case 6:
                        ShowHighestScore();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (DuplicateStudentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
