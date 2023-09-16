using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercent = int.Parse(Console.ReadLine());
        string gradeLetter = "";
        string letterModifier = "";

        if (gradePercent >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercent >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercent >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercent >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        if((gradePercent % 10) >= 7 && 90 > gradePercent && gradePercent > 60)
        {
            letterModifier = "+";
        }
        else if((gradePercent % 10) < 3 && gradePercent > 60)
        {
            letterModifier = "-";
        }

        Console.WriteLine($"Your grade is {gradeLetter}{letterModifier}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("You didn't pass. Try again next time.");
        }
    }
}