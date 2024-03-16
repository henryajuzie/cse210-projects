using System; // Using directive placed at the top of the file

public class Job
{
    // Properties
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public decimal Salary { get; set; }

    // Method to display job details
    public void DisplayJobDetails()
    {
        Console.WriteLine("Job Title: " + JobTitle);
        Console.WriteLine("Company Name: " + CompanyName);
        Console.WriteLine("Salary: " + Salary);
    }
}
