using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the user's numbers
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Init variables for loop
        int number = -1;
        int sum = 0;
        int count = 0;
        int minimum = 99999;
        int maximum = -99999;

        while (number != 0)
        {

            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);

                // Update variables
                sum += number;
                count++;

                if (number < minimum && number > 0)
                {
                    minimum = number;
                }

                if (number > maximum)
                {
                    maximum = number;
                }
            }

        }
        float average = (float)sum / count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {maximum}");
        Console.WriteLine($"The smallest positive number is: {minimum}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }

    }
}