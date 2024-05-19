using System;

class Program
{
    static void Main(string[] args)
    {
        Activity[] activities = {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        Console.WriteLine("Welcome to the Activity Center!");

        while (true)
        {
            Console.WriteLine("\nPlease select an activity:");
            for (int i = 0; i < activities.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].Name}");
            }
            Console.WriteLine("0. Exit");

            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 0 && choice <= activities.Length)
                        break;
                }
                Console.WriteLine("Invalid choice. Please try again.");
            }

            if (choice == 0)
            {
                Console.WriteLine("Thank you for using the Activity Center. Goodbye!");
                break;
            }

            Activity selectedActivity = activities[choice - 1];
            Console.WriteLine($"\n[{selectedActivity.Name}]");
            Console.WriteLine(selectedActivity.Description);

            Console.WriteLine("\nPress any key to start the activity...");
            Console.ReadKey();

            Console.WriteLine("\nThe activity will now begin.");
            selectedActivity.PerformActivity();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}