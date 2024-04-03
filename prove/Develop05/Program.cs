// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test Square class
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square color: {square.Color}");
        Console.WriteLine($"Square area: {square.GetArea()}");

        // Continue with Rectangle and Circle classes as described in the instructions
    }
}
