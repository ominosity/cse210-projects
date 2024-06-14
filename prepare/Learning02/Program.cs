using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "HLP, Inc";
        job1._startYear = 2014;
        job1._endYear = 2024;

        // Console.WriteLine($"Job title: {job1._company}");
        // job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "PetHealthInc";
        job2._startYear = 2024;
        job2._endYear = 2034;

        // Console.WriteLine($"Job title: {job2._company}");
        // job2.DisplayJobDetails();

        Resume resume= new Resume();
        resume._applicantName = "Richard Burgener";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Console.WriteLine($"{resume._jobs[0]._jobTitle}");
        resume.DisplayDetails();
    }
}