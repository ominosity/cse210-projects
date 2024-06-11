using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine());
        string playAgain = "yes";
        do
        {
            Random random = new();
            int magicNumber = random.Next(1, 100);

            int guess = -1;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (magicNumber != guess);

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine();
        } while (playAgain.ToLower() == "yes");
    }
}