public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    /// <summary>
    /// Create a Listing Activity by using base constructor with name, description, and a default timing of 60 seconds
    /// </summary>
    public ListingActivity() :
        base("Listing"
           , "This activity will help you reflect on the good things in your life by having you list as many things as you can that match the given prompt."
           , 60)
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _count = 0;
    }

    public void Run()
    {
        Console.WriteLine("List as many responses as you can to the following prompt: ");

        // Create randomizer and randomly select a prompt
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine($" --- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
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

        Console.WriteLine($"You listed {_count} items!");

        // If there was at least one response, congratulate
        if (_count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
        }
        ShowSpinner(5);
    }


}