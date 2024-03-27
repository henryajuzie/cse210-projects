using System;
using System.Threading;

public class Activity
{
    protected string name;
    protected string description;
    protected int durationInSeconds;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {name} activity:");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public virtual void End()
    {
        Console.WriteLine("Well done! You've completed the activity.");
        Console.WriteLine($"You've completed {name} activity for {durationInSeconds} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected virtual void SetDuration()
    {
        Console.Write("Enter duration (in seconds): ");
        durationInSeconds = Convert.ToInt32(Console.ReadLine());
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Starting breathing activity...");
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(2); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(2); // Pause for 2 seconds
        }
        End();
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Starting reflection activity...");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            PauseWithAnimation(3); // Pause for 3 seconds
        }
        End();
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Starting listing activity...");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Start listing...");
        PauseWithAnimation(durationInSeconds); // Pause for the specified duration
        Console.WriteLine("End of listing.");
        End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
            activity.Start();
        }
    }
}
