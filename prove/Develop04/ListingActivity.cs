public class ListingActivity : Activity
{
    private int _count;
    private List<Prompt> _prompts;

    /// <summary>
    /// Create a Listing Activity by using base constructor with name, description, and a default timing of 60 seconds
    /// </summary>
    public ListingActivity() :
        base("Listing"
           , "This activity will help you reflect on the good things in your life by having you list as many things as you can that match the given prompt."
           , 60)
    {
        // Generate the prompts
        _prompts = new List<Prompt>{
            new Prompt("Who are people that you appreciate?"),
            new Prompt("What are personal strengths of yours?"),
            new Prompt("Who are people that you have helped this week?"),
            new Prompt("When have you felt the Holy Ghost this month?"),
            new Prompt("Who are some of your personal heroes?"),
        };

        _count = 0;
    }

    public void Run()
    {
        // Reset count
        _count = 0;

        Console.WriteLine("List as many responses as you can to the following prompt: ");

        // Create randomizer
        Random random = new Random();

        // Create a list of remaining (unused) prompts
        List<Prompt> remainingPrompts = Prompt.GetUnused(_prompts);

        // Randomly select a prompt from the remaining list
        int index = random.Next(remainingPrompts.Count);
        string userPrompt = remainingPrompts[index].GetPrompt();

        // Mark prompt as used
        remainingPrompts[index].MarkUsed();

        // Show the prompt to the user
        Console.WriteLine($" --- {userPrompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Write("\n");

        // Determine the ending time of the activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        // While there's time remaining, prompt for a response
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            // Only add to the counter if a response was given
            if (!String.IsNullOrEmpty(response))
            {
                _count++;
            }
        }

        // Respond appropriately if only one item was listed
        if (_count == 1)
        {
            Console.WriteLine($"You listed {_count} item!");
        }
        else
        {
            Console.WriteLine($"You listed {_count} items!");
        }

        // If there was at least one response, congratulate
        if (_count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
        }
        ShowSpinner(5);
    }
}