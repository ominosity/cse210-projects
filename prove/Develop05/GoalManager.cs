public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    /// <summary>
    /// Creates a new Goal Manager
    /// </summary>
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    /// <summary>
    /// Runs the menu loop
    /// </summary>
    public void Start()
    {
        // Initialize choice variable and start menu loop
        int choice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Goals Program!");
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");

            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 6)
                {
                    throw new Exception("Invalid choice");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please choose an option between 1 and 6.");
                // Pause before we clear the console for the menu
                Pause();
            }

            switch (choice)
            {
                case 1:
                    // Create a goal
                    CreateGoal();
                    break;
                case 2:
                    // Show list of goals and progress (checkbox, checklist progress)
                    ListGoalDetails();
                    break;
                case 3:
                    // Save goals to a file
                    SaveGoals();
                    break;
                case 4:
                    // Load goals from a file
                    LoadGoals();
                    break;
                case 5:
                    // Mark a goal as completed
                    RecordEvent();
                    break;
                case 6:
                    // Break out of switch to end the loop and exit the program
                    break;
            }
        } while (choice != 6);
    }

    /// <summary>
    /// Displays the current score to the console
    /// </summary>
    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
    }

    /// <summary>
    /// Outputs a list of the names of each of the goals to the 
    /// console (to choose for completion)
    /// </summary>
    public void ListGoalNames()
    {
        Console.WriteLine("Your goals are:");
        int counter = 1;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                Console.WriteLine($"\t{counter}. {goal.GetName()} (completed)");
            }
            else
            {
                Console.WriteLine($"\t{counter}. {goal.GetName()}");
            }
            counter++;
        }
    }

    /// <summary>
    /// Outputs a list of the details of each goal to the 
    /// console, including a completed checkbox. 
    /// </summary>
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  -- No goals on file. Please add a goal or load goals from a file. --");
        }
        else
        {
            Console.WriteLine("The goals are:");
            int goalcount = 1;
            foreach (Goal goal in _goals)
            {
                string completed;
                if (goal.IsComplete())
                {
                    completed = "[X]";
                }
                else
                {
                    completed = "[ ]";
                }

                Console.WriteLine($"\t{goalcount}. {completed} {goal.GetDetailsString()}");
                goalcount++;
            }
        }
        // Pause before we clear the console for the menu
        Pause();
    }

    /// <summary>
    /// Prompts the user for information about a new goal on 
    /// the console, creates it, and adds it to the list. 
    /// </summary>
    public void CreateGoal()
    {
        int choice = 0;
        while (choice < 1 || choice > 3)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("\t1. Simple Goal");
            Console.WriteLine("\t2. Eternal Goal");
            Console.WriteLine("\t3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3)
                {
                    throw new Exception("Invalid choice");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please choose an option between 1 and 3");
                Console.WriteLine();
                continue;
            }

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();

            switch (choice)
            {
                // Simple goal
                case 1:
                    int points = GetPointValue("How many points is this goal worth upon completion (max 1000)?", 1, 1000);
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    _goals.Add(simpleGoal);
                    break;
                // Eternal Goal
                case 2:
                    points = GetPointValue("How many point is this goal worth each time it's completed (max 1000)?", 1, 1000);
                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal);
                    break;
                // Checklist Goal
                case 3:
                    points = GetPointValue("How many point is this goal worth each time it's completed (max 1000)?", 1, 1000);
                    int target = GetPointValue("How many times does this goal need to be completed to earn a bonus (up to 1000)?", 0, 1000);
                    int bonus = GetPointValue("How many bonus points is this goal worth when target is reached (max 1000)?", 0, 1000);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(checklistGoal);
                    break;
            }
        }
    }

    /// <summary>
    /// Get a point value from the user via the console
    /// </summary>
    /// <param name="isSimple">Whether or not the goal is a Simple (one-time) goal</param>
    /// <returns>An integer between 1 and 1000</returns>
    private static int GetPointValue(string prompt, int min, int max)
    {
        int points = min - 1;
        while (points < min || points > max)
        {
            Console.Write($"{prompt} ");
            try
            {
                points = int.Parse(Console.ReadLine());
                if (points <= min || points > max)
                {
                    throw new Exception("Invalid choice");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Please enter a number between {min} and {max}");
            }
        }
        return points;
    }

    /// <summary>
    /// Asks the user which goal they've completed (on the 
    /// console) and records the event with the goal's 
    /// RecordEvent method
    /// </summary>
    public void RecordEvent()
    {
        // If there are no goals to record, return 
        if (_goals.Count == 0)
        {
            Console.WriteLine("  -- You don't have any goals! --");
            Pause();
            return;
        }

        int choice = 0;
        while (choice <= 0 || choice > _goals.Count)
        {
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");

            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice > _goals.Count)
                {
                    throw new Exception("Invalid choice");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Please choose an option between 1 and {_goals.Count}");
            }
        }
        // Menu is 1-based, List is 0-based
        Goal goal = _goals[choice - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("  -- That goal has already been completed! Please create or complete another goal. --");
        }
        else
        {
            // Record the event
            goal.RecordEvent();

            // Add points to score
            _score += goal.GetPointValue();

            Console.WriteLine($"Congratulations! You have earned {goal.GetPointValue()} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        Pause();
    }

    /// <summary>
    /// Saves the list of goals and score to a file
    /// </summary>
    public void SaveGoals()
    {
        // Bail on the save if there aren't any goals and a score
        // Allow to save if there are any goals or any points on the board
        if (_goals.Count == 0 && _score == 0)
        {
            Console.WriteLine("  -- No goals to save. Please add a goal and try again. --");
            Pause();
            return;
        }
        Console.Write("Please enter a filename to save your goals to: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    sw.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved to {filename}.");
            Pause();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            Pause();
        }
    }

    /// <summary>
    /// Loads the list of goals and score from a file
    /// </summary>
    public void LoadGoals()
    {
        if (_goals.Count > 0 || _score > 0)
        {
            Console.WriteLine($"{_goals.Count} goals currently active, with {_score} points.");
            Console.WriteLine("Continue to overwrite goals and score with info from a file (y/n)? ");
            string choice = Console.ReadLine();
            if (choice.Trim().ToLower() != "y")
            {
                Console.WriteLine("Save operation aborted.");
                Pause();
                return;
            }
        }

        Console.Write("Please enter the filename for the goals file: ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {

                _score = int.Parse(sr.ReadLine());

                // Reset the goals in preparation for loading the new ones
                _goals.Clear();

                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] attributes = line.Split(Goal.GetDelimiter());

                    // All goals have first three parts - name, description, points
                    string name = attributes[1];
                    string description = attributes[2];
                    int points = int.Parse(attributes[3]);

                    // The first data point in the files is the type of goal
                    switch (attributes[0])
                    {
                        case "SimpleGoal":
                            bool completed = false;
                            string stringCompleted = attributes[4];
                            if (stringCompleted.ToLower() == "true")
                            {
                                completed = true;
                            }
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points, completed);
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            EternalGoal eternalGoal = new EternalGoal(name, description, points);
                            _goals.Add(eternalGoal);
                            break;
                        case "ChecklistGoal":
                            int bonus = int.Parse(attributes[4]);
                            int target = int.Parse(attributes[5]);
                            int amountCompleted = int.Parse(attributes[6]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
                Console.WriteLine($"Goals loaded from {filename} file.");
                Pause();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine("Aborting load.");
            Pause();
            return;
        }
    }

    /// <summary>
    /// Tell the user to press any key to continue, then wait for them to do so
    /// </summary>
    private void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey(true);
    }
}