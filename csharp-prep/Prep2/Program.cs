using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // This is prep 2
        Console.Write("What is your grade percentage (as a whole number)? ");
        float grade = int.Parse(Console.ReadLine());
        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }
        
        string sign = "";

        // Add + or -, depending on the grade and percentage
        // Avoid adding + to A or F, and avoid adding - to F
        if (grade % 10 >= 7 && !(grade >= 97) && !(grade <= 60))
            sign = "+";
        else if (grade % 10 <= 3 && !(grade <= 60))
            sign = "-";

        Console.WriteLine($"You got a(n) {letter}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("You passed the course!");
        }
        else 
        {
            Console.WriteLine("You didn't quite pass the course. Please try again - you're sure to pass it next time!");
        }
     }
}