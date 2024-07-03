public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation() 
    {
        string writingInformation = $"{_title} by {base.GetStudentName()}";
        return writingInformation;
    }
}