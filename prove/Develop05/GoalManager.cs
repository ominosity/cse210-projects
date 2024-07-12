
public class GoalManager
{
    private List<Goal> _goals ;
    private int _score ;

    /// <summary>
    /// Creates a new Goal Manager
    /// </summary>
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0 ;
    }

    /// <summary>
    /// Runs the menu loop
    /// </summary>
    public void Start() 
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Displays the current score to the console
    /// </summary>
    public void DisplayPlayerInfo()
    {
        throw new NotImplementedException();        
    }

    /// <summary>
    /// Outputs a list of the names of each of the goals to the 
    /// console
    /// </summary>
    public void ListGoalNames() 
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Outputs a list of the details of each goal to the 
    /// console, including a completed checkbox. 
    /// </summary>
    public void ListGoalDetails() 
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Prompts the user for information about a new goal on 
    /// the console, creates it, and adds it to the list. 
    /// </summary>
    public void CreateGoal() 
    {
        throw new NotImplementedException();        
    }

    /// <summary>
    /// Asks the user which goal they've completed (on the 
    /// console) and records the event with the goal's 
    /// RecordEvent method
    /// </summary>
    public void RecordEvent() 
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Saves the list of goals and score to a file
    /// </summary>
    public void SaveGoals()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Loads the list of goals and score from a file
    /// </summary>
    public void LoadGoals()
    {
        throw new NotImplementedException();
    }
}