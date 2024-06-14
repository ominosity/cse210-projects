public class Resume
{
    public string _applicantName;
    public List<Job> _jobs = new List<Job>();

    public void DisplayDetails() 
    {
        Console.WriteLine($"Name: {_applicantName}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}