using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter the score: ");
            int score = Convert.ToInt32(Console.ReadLine());

            string grade = CalculateGrade(score);
            Console.WriteLine($"Grade: {grade}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string CalculateGrade(int score)
    {
        if (score == 0)
        {
            throw new ArgumentException("Score cannot be zero.");
        }
        if (score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException("Score must be between 1 and 100.");
        }
        if (score >= 90 && score <= 100)
        {
            return "A";
        }
        else if (score >= 70 && score < 90)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }
}
