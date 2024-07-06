public class ReflectingActivity : Activity
{
    private List<Prompt> _prompts;
    private List<Prompt> _questions;

    /// <summary>
    /// Create a Reflecting Activity by using base constructor with name, description, and a default timing of 60 seconds.
    /// 
    /// </summary>
    public ReflectingActivity() :
        base("Reflecting"
           , "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
           , 60)
    {
        _prompts = new List<Prompt>
        {
            new Prompt("Think of a time when you stood up for someone else."),
            new Prompt("Think of a time when you did something really difficult."),
            new Prompt("Think of a time when you helped someone in need."),
            new Prompt("Think of a time when you did something truly selfless.")
        };

        _questions = new List<Prompt>
        {
            new Prompt("Why was this experience meaningful to you?"),
            new Prompt("Have you ever done anything like this before?"),
            new Prompt("How did you get started?"),
            new Prompt("How did you feel when it was complete?"),
            new Prompt("What made this time different than other times when you were not as successful?"),
            new Prompt("What is your favorite thing about this experience?"),
            new Prompt("What could you learn from this experience that applies to other situations?"),
            new Prompt("What did you learn about yourself through this experience?"),
            new Prompt("How can you keep this experience in mind in the future?")
        };
    }

    public void Run()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        // Randomly select a prompt
        Random random = new Random();

        // Create a list of remaining (unused) prompts
        List<Prompt> remainingPrompts = Prompt.GetUnused(_prompts);

        // Randomly select a prompt from the remaining list
        int index = random.Next(remainingPrompts.Count);
        string userPrompt = remainingPrompts[index].GetPrompt();

        // Mark prompt as used
        remainingPrompts[index].MarkUsed();

        // Show prompt to user in preparation for questions
        Console.WriteLine($" --- {userPrompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        // Each question lasts 15 seconds. Determine the number of questions and max time for the last question. 
        int duration = GetDuration();
        // int questionCount = duration / 15;
        // int lastQuestionTime = duration % 15;


        while (duration > 0)
        {
            // Create a list of remaining (unused) question prompts
            List<Prompt> remainingQuestions = Prompt.GetUnused(_questions);

            // Randomly select a question prompt from the remaining list
            index = random.Next(remainingQuestions.Count);
            string question = remainingQuestions[index].GetPrompt();

            // Mark prompt as used
            remainingQuestions[index].MarkUsed();

            // Ask the question and show the spinner for 15 seconds, or what time is left (if less than 15)
            Console.WriteLine();
            Console.Write($"> {question} ");
            if (duration < 15)
            {
                ShowSpinner(duration);
                duration = 0;
            }
            else
            {
                ShowSpinner(15);
                duration -= 15;
            }
        }
        Console.WriteLine();
    }
}