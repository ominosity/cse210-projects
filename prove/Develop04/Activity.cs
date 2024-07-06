public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    /// <summary>
    /// Construct the activity with the three required components
    /// </summary>
    /// <param name="name">The name of the activity (don't add "activity" to the end)</param>
    /// <param name="description">A brief description of what the activity entails</param>
    /// <param name="duration">How many seconds the activity should go</param>
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    /// <summary>
    /// Introduce the activity and get the duration
    /// </summary>
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write($"How long, in seconds, would you like for your session? ");

        // Solicit the duration, in seconds. If unparsable values are entered, display a message and use default timing
        try
        {
            _duration = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine($"Invalid entry. Defaulting to {_duration} seconds.");
            ShowSpinner(3);
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    /// <summary>
    /// Show the ending message with the elapsed time
    /// </summary>
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity");
    }

    /// <summary>
    /// Print an ASCII spinner to the console
    /// </summary>
    /// <param name="seconds">The number of seconds to show the spinner</param>
    public void ShowSpinner(int seconds)
    {
        // Sequential characters in the spinner
        List<string> animationStrings = new List<string>
        {
            "|",
            "/",
            "-",
            "\\",
            "|",
            "/",
            "-",
            "\\"
        };

        // Hide cursor during animation 
        Console.CursorVisible = false;

        // Repeat based on the number of seconds given
        for (int i = 0; i < seconds; i++)
        {
            // Loop through the spinner characters. Sleeping for 125 ms means it will cycle through all 
            // 8 characters in exactly 1 second
            foreach (string animation in animationStrings)
            {
                Console.Write(animation);
                Thread.Sleep(125);
                Console.Write("\b \b");
            }
        }

        // Animation over - show cursor
        Console.CursorVisible = true;
    }


    /// <summary>
    /// Print a countdown to the console
    /// </summary>
    /// <param name="seconds">The number of seconds to count down from</param>
    public void ShowCountDown(int seconds)
    {
        // Hide the cursor during the countdown
        Console.CursorVisible = false;

        for (int i = seconds; i > 0; i--)
        {
            // Determine how many characters are in the second count
            int secondsLength = i.ToString().Length;

            // Backspace and overwrite spaces for the number of characters in the second count
            string backspaces = new string ('\b', secondsLength);
            string spaces = new string(' ', secondsLength);

            // Write and overwrite seconds remaining
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write($"{backspaces}{spaces}{backspaces}");
        }

        // Countdown complete - show cursor 
        Console.CursorVisible = true;
    }

    /// <summary>
    /// Return the duration of the activity, in seconds
    /// </summary>
    /// <returns>The number of seconds the activity is scheduled to last</returns>
    protected int GetDuration()
    {
        return _duration;
    }
}