using System;
using System.Threading;

class ListingActivity : Activity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void PerformActivity()
    {
        Start();
        ListItems();
        End();
    }

    private void ListItems()
    {
        Random random = new Random();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");
            ShowSpinner(3);
            Pause();
        }
    }
}