using System;
using System.Collections.Generic;
using System.IO;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
    public string Location { get; set; }
    public string Weather { get; set; }

    public JournalEntry(string prompt, string response, DateTime date, int rating, string location, string weather)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Rating = rating;
        Location = location;
        Weather = weather;
    }

    // Method to display the journal entry
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Rating: {Rating}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Weather: {Weather}\n");
    }
}

public class JournalManager
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    // Method to write a new entry
    public void WriteNewEntry()
    {
        string prompt = PromptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("Rate your day (1-5): ");
        int rating = int.Parse(Console.ReadLine());
        Console.Write("Location: ");
        string location = Console.ReadLine();
        Console.Write("Weather: ");
        string weather = Console.ReadLine();
        DateTime date = DateTime.Now;

        JournalEntry entry = new JournalEntry(prompt, response, date, rating, location, weather);
        entries.Add(entry);
        Console.WriteLine("Entry added to journal.");
    }

    // Method to display the entire journal
    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    // Method to save the journal to a CSV file
    public void SaveJournalToCsv(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Date,Prompt,Response,Rating,Location,Weather");
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response},{entry.Rating},{entry.Location},{entry.Weather}");
            }
        }
        Console.WriteLine("Journal saved to CSV file successfully.");
    }

    // Method to load the journal from a CSV file
    public void LoadJournalFromCsv(string fileName)
    {
        entries.Clear(); // Clear existing entries before loading from file
        using (StreamReader reader = new StreamReader(fileName))
        {
            // Skip header line
            reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                DateTime date = DateTime.Parse(fields[0]);
                string prompt = fields[1];
                string response = fields[2];
                int rating = int.Parse(fields[3]);
                string location = fields[4];
                string weather = fields[5];

                JournalEntry entry = new JournalEntry(prompt, response, date, rating, location, weather);
                entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded from CSV file successfully.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        JournalManager journalManager = new JournalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    journalManager.WriteNewEntry();
                    break;
                case "2":
                    journalManager.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    journalManager.SaveJournalToCsv(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    journalManager.LoadJournalFromCsv(loadFileName);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}

public class PromptGenerator
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the most unexpected thing that happened to me today?",
        "What is one thing I learned today?",
        "What made me smile today?",
        "What is one thing I'm grateful for today?",
        "What challenged me the most today?"
    };

    public static string GetRandomPrompt()
    {
        Random random = new Random();
        return Prompts[random.Next(Prompts.Count)];
        // This program is a journal application that allows users to write entries, display the journal, and save/load entries to/from a CSV file.
// Advancements beyond the core requirements:
// - Users can rate their day, provide their location, and describe the weather conditions when writing a new journal entry.
// - Journal entries are saved and loaded in a CSV format, allowing users to open and analyze their journal in spreadsheet software like Excel.
// These enhancements provide users with more flexibility and context when journaling, and improve the functionality and usability of the program.

    }
}
