using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();

        string UserName = PromptUserName();

        string UserNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(UserNumber);

        DisplayResult(UserName, squaredNumber);
    }

    static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Enter your favorite number: ");
            int UserNumber = Console.ReadLine();

            return UserNumber;
        }

        static int SquareNumber(int UserNumber)
        {
            int square = UserNumber * UserNumber;
            return square; 
        }

        static void DisplayResult(string userName, int square)
        {
            Console.WriteLine($"{UserName}, the square of your number is {square}");
        }
}