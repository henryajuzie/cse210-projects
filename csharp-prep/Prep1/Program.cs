
class Program
{
    static void Main()
    {
        // Prompting the user for their first name
        Console.Write("Enter your first name: ");
        string first= Console.ReadLine();
{
        // Prompting the user for their last name
        Console.Write("Enter your last name: ");
        string last= Console.ReadLine();

        // displaying the full name in the desired format
        Console.WriteLine($"Your name is {last}, {first} {last}.");
}

    }
}