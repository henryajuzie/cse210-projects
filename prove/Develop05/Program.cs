using System;
using System.Collections.Generic;

// Base class for goals
public abstract class Goal
{
    protected string name;
    protected int value;
    protected bool completed;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
        completed = false;
    }

    public virtual void RecordEvent()
    {
        completed = true;
        Console.WriteLine($"Congratulations! You've completed the goal: {name}. You've gained {value} points.");
    }

    public virtual string DisplayStatus()
    {
        return completed ? "[X]" : "[ ]";
    }

    public abstract void DisplayDetails();
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name} | Value: {value} | Status: {DisplayStatus()}");
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name} | Value: {value} | Status: {DisplayStatus()}");
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        this.targetCount = targetCount;
        currentCount = 0;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        currentCount++;
        if (currentCount == targetCount)
        {
            Console.WriteLine($"Congratulations! You've achieved the target for goal: {name}. You've gained a bonus of {value} points.");
        }
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name} | Value: {value} | Target Count: {targetCount} | Current Count: {currentCount}/{targetCount} | Status: {DisplayStatus()}");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Sample usage
        Goal simpleGoal = new SimpleGoal("Run a Marathon", 1000);
        Goal eternalGoal = new EternalGoal("Read Scriptures", 100);
        Goal checklistGoal = new ChecklistGoal("Attend Temple", 50, 10);

        simpleGoal.RecordEvent();
        eternalGoal.RecordEvent();
        checklistGoal.RecordEvent();

        // Display goal details
        simpleGoal.DisplayDetails();
        eternalGoal.DisplayDetails();
        checklistGoal.DisplayDetails();
         // Sample usage
        Goal simpleGoal = new SimpleGoal("Run a Marathon", 1000);
        Goal eternalGoal = new EternalGoal("Read Scriptures", 100);
        Goal checklistGoal = new ChecklistGoal("Attend Temple", 50, 10);

        // Record events for goals
        simpleGoal.RecordEvent();
        eternalGoal.RecordEvent();
        checklistGoal.RecordEvent();

        // Display goal details
        simpleGoal.DisplayDetails();
        eternalGoal.DisplayDetails();
        checklistGoal.DisplayDetails();
    }
}
    
