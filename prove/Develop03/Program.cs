/// <summary>
///     Name: Richard Burgener
///     Project: Scripture Memorizer
///     
/// 
/// </summary>

class Program
{
    static void Main(string[] args)
    {
        // Variable to hold the user's choice.
        string choice = "";

        // Create the scripture and the reference for memorization
        Reference reference = new Reference("John", 1, 1);
        string text = "In the beginning was the Word, and the Word was with God, and the Word was God.";
        Scripture scripture= new Scripture(reference, text);

        // Start a loop that continues until 1) the user types 'quit'
        // or 2) the entire scripture has been hidden. 
        do 
        {
            Console.Clear();

            // Display the scripture
            Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}");

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            choice = Console.ReadLine();

            // If the user didn't quit, hide a number of words,
            scripture.HideRandomWords(5);
        } while (choice.ToLower() != "quit" && !scripture.IsCompletelyHidden());

        // Display the scripture one last time, with everything hidden
        Console.Clear();
        Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}");
    }
}