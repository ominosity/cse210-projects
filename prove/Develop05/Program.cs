/// <summary>
///     Name: Richard Burgener
///     Project: Eternal Quest Program
///     
///     Exceeds: I implemented a protected variable in the goal class to set the file IO 
///              delimiter. It's also exposed to the outside world with a GetDelimiter() 
///              method (so the GoalManager can see it for loading);
///              
///              I changed the menu system a bit so it clears the console each time and there
///              is a pause for the user to acknowledge any results and then press a key to 
///              continue. 
///              
///              I created a private method in the Goal manager to handle this pausing, so 
///              it's consistent across the program. 
///              
///              I created try...catch loops for any time user input is required to select
///              a menu item. If they type anything but an item number on the menu, they are
///              told so and prompted to try again (rather than crashing the program). 
///              
///              I moved all Console interaction to the GoalManager so the other classes
///              could be used in a GUI or web application in the future. 
///              
///              I added blocks to prevent the user from completing a simple goal again or 
///              a checklist goal that's already completed. 
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager= new GoalManager();
        goalManager.Start();
    }
}