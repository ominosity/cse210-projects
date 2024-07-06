public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    /// <summary>
    /// Create a Reflecting Activity by using base constructor with name, description, and a default timing of 60 seconds.
    /// 
    /// </summary>
    public ReflectingActivity() :
        base("Reflecting"
           , "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
           , 60)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        // Randomly select a prompt
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine($" --- {_prompts[index]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Clear();

        // Each question lasts 15 seconds. Determine the number of questions and max time for the last question. 
        int duration = GetDuration();
        int questionCount = duration / 15;
        int lastQuestionTime = duration % 15;

        // Select a random question, reusing the existing randomizer
        for (int i = 0; i < questionCount; i++)
        {
        index = random.Next(_questions.Count);
            Console.Write($"> {_questions[index]} ");
            ShowSpinner(15);
        }
        // Last question with truncated timing (if time chosen is not a multiple of 15)
        if (lastQuestionTime > 0)
        {
            Console.Write($"> {_questions[index]} ");
            ShowSpinner(lastQuestionTime);
        }
    }
}