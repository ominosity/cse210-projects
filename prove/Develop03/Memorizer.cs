public class Memorizer
{
    private readonly Scripture _scripture;

    public Memorizer(Scripture scripture)
    {
        _scripture = scripture;
    }

    public void MemorizeScripture()
    {
        // Variable to hold the user's choice.
        string choice = "";

        // Create the scripture and the reference for memorization
        Reference reference = _scripture.GetReference();

        // Start a loop that continues until 1) the user types 'quit'
        // or 2) the entire scripture has been hidden. 
        do
        {
            Console.Clear();

            // Display the scripture
            Console.WriteLine($"{reference.GetDisplayText()}\n{_scripture.GetDisplayText()}");

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            choice = Console.ReadLine();
            if (choice.ToLower() != "quit")
            {
                // If the user didn't quit, hide a number of words,
                _scripture.HideRandomWords(5);
            }
        } while (choice.ToLower() != "quit" && !_scripture.IsCompletelyHidden());

        // Display the scripture one last time, with everything hidden
        Console.Clear();
        Console.WriteLine($"{reference.GetDisplayText()} {_scripture.GetDisplayText()}");
        if (_scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Congratulations - you finished!");
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey(true);
        }
        
    }
}