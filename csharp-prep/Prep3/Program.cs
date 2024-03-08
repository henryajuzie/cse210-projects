using System;

class Program
{
    static void Main(string[] args)
    {
         // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 109);

        int guess = -1;
        Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
             Console.WriteLine("You guessed it!");
            
    
 
                
            

    
    }
}