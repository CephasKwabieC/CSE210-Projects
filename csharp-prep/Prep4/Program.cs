using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int userInput;

        while (userInput != 0)
        {
            Console.WriteLine("Enter a number: ");
            
            int userInput = int.Parse(Console.ReadLine());
            
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        //computing the sum
        int sum = 0;
        foreach (int  number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        
        
        // Part 3: Find the max
        int max = numbers[0];

        foreach(int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }

    
}