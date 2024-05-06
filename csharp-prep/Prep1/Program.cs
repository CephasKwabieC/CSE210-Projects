using System;

class Program
{
    static void Main(string[] args)
    { 
        Console.Write("What is the magic number? ");
        string answer = Console.ReadLine();
        int magicNumber = int.Parse(answer);

        Console.Write("What is your guess? ");
        string answer = Console.ReadLine();
        int guessNumber = int.Parse(answer);

        if (guessNumber == magicNumber)
        {
            Console.WriteLine("You guessed right!");
        }
        else if (guessNumber > magicNumber)
        {
            Console.WriteLine("A little lower");
        }
        else if (guessNumber < magicNumber)
        {
            Console.WriteLine("A little higher");
        }

    }
}