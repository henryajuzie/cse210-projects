using System;
using System.Collections.Generic; // Include the namespace for List<T>

class Program
{
    static void Main(string[] args)
    {
        // Create job instances
        Job job1 = new Job();
        job1.JobTitle = "Customer Representative";
        job1.Company = "LaBenz";
        job1.StartYear = 2010;
        job1.EndYear = 2022;

        Job job2 = new Job();
        job2.JobTitle = "Manager";
        job2.Company = "HumbleStone";
        job2.StartYear = 2019;
        job2.EndYear = 2023;

        // Create a new instance of the Resume class
        Resume myResume = new Resume();
        myResume.Name = "Henry Ajuzie";

        // Add the jobs to the list of jobs in the Resume object
        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        // Display the resume details
        myResume.Display();
    }
}

public class Job
{
    // Properties
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    // Method to display job details
    public void DisplayJobDetails()
    {
        Console.WriteLine($"Job Title: {JobTitle}");
        Console.WriteLine($"Company: {Company}");
        Console.WriteLine($"Start Year: {StartYear}");
        Console.WriteLine($"End Year: {EndYear}");
        Console.WriteLine();
    }
}

