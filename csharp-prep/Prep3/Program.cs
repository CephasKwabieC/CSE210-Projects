using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        // string input = Console.ReadLine();
        // int magicNumber = int.Parse(input);

    {
        string playAgain;

        do
        {
            int magicNumber = new Random().Next(1, 101);
            int guesses = 0;
            int guess;

            Console.WriteLine("Welcome to the Guessing Game!");

            while (true)
            {
                Console.Write("Enter your guess (1-100): ");
                guess = Convert.ToInt32(Console.ReadLine());
                guesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed it in {0} attempts.", guesses);
                    break;
                }
            }

            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        } while (playAgain.ToLower() == "yes");

        Console.WriteLine("Thanks for playing!");
        }
    }
}