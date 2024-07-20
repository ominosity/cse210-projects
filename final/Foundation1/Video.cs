using System.Runtime.Versioning;
using System.Text;

public class Video 
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;

        _comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public string GetDescription() 
    {
        string description = $"{_title} by {_author}, {_length} seconds, {GetNumberOfComments()} comments.";
        return description;
    }

    public string GetCommentList()
    {
        StringBuilder sb = new StringBuilder();
        foreach(Comment comment in _comments)
        {
            sb.Append(comment.GetCommentDetails());
        }
        return sb.ToString();
    }
}