using System;

class Program
{
    static void Main(string[] args)
    { 
        Console.Write("what is your grade percentage? ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);

        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A"; 
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else if (gradePercentage < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed! Congratulations!");
        }
        else if (gradePercentage < 70)
        {
            Console.WriteLine("You failed! Better luck next time.");
        }

    }
}