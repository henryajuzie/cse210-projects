using System.Collections.Generic; // Importing the namespace for List<T>

public class Resume
{
    // Member variable for the person's name
    public string PersonName { get; set; }

    // Member variable for the list of jobs
    public List<Job> Jobs { get; set; } = new List<Job>(); // Initializing to a new list
}

