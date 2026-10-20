
using System;

public class Student
{
    // Properties
    public string StudentId { get; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string ClassName { get; set; }

    public double MathScore { get; set; }
    public double PhysicsScore { get; set; }
    public double ChemistryScore { get; set; }

    // Constructor
    public Student(
        string studentId,
        string fullName,
        int birthYear,
        string className,
        double mathScore,
        double physicsScore,
        double chemistryScore)
    {
        if (string.IsNullOrWhiteSpace(studentId))
            throw new ArgumentException("Student ID cannot be empty.");

        StudentId = studentId;

        FullName = fullName;
        BirthYear = birthYear;
        ClassName = className;

        ValidateScore(mathScore, nameof(mathScore));
        ValidateScore(physicsScore, nameof(physicsScore));
        ValidateScore(chemistryScore, nameof(chemistryScore));

        MathScore = mathScore;
        PhysicsScore = physicsScore;
        ChemistryScore = chemistryScore;
    }

    // Validate scores from 0 to 10
    private static void ValidateScore(double score, string name)
    {
        if (double.IsNaN(score) ||
            double.IsInfinity(score) ||
            score < 0 || score > 10)
        {
            throw new ArgumentOutOfRangeException(
                name, "Score must be between 0 and 10.");
        }
    }

    // Calculate age
    public int GetAge()
    {
        return DateTime.Now.Year - BirthYear;
    }

    // Calculate average score
    public double GetAverageScore()
    {
        return (MathScore + PhysicsScore + ChemistryScore) / 3.0;
    }

    // Classify academic rank
    public string GetRank()
    {
        double average = GetAverageScore();

        if (average >= 8.0)
            return "Excellent";
        else if (average >= 6.5)
            return "Good";
        else if (average >= 5.0)
            return "Average";
        else
            return "Below Average";
    }

    // Print student information
    public void PrintInfo()
    {
        Console.WriteLine(ToString());
    }

    // Convert student information to string
    public override string ToString()
    {
        return
            "===== STUDENT INFORMATION =====\n" +
            $"Student ID     : {StudentId}\n" +
            $"Full Name      : {FullName}\n" +
            $"Birth Year     : {BirthYear}\n" +
            $"Age            : {GetAge()}\n" +
            $"Class          : {ClassName}\n" +
            $"Math Score     : {MathScore:F2}\n" +
            $"Physics Score  : {PhysicsScore:F2}\n" +
            $"Chemistry Score: {ChemistryScore:F2}\n" +
            $"Average Score  : {GetAverageScore():F2}\n" +
            $"Rank           : {GetRank()}\n" +
            "===============================";
    }
}
