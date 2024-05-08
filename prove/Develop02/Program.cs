using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Get Random Prompt");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry newEntry = new Entry();

                    Console.Write("Enter the date: ");
                    newEntry._date = Console.ReadLine();

                    Console.Write("Enter the prompt: ");
                    newEntry._promptText = Console.ReadLine();

                    Console.Write("Enter the entry text: ");
                    newEntry._entryText = Console.ReadLine();

                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added.");
                    Console.WriteLine();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the file name to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter the file name to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine("Random Prompt: " + randomPrompt);
                    Console.WriteLine();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}