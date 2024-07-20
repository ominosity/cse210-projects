public class Comment 
{
    private string _commenter;
    private string _commentText;

    public Comment(string commenter, string commentText)
    {
        _commenter = commenter;
        _commentText = commentText;
    }

    public string GetCommentDetails() 
    {
        string details = $"{_commenter}: {_commentText}\n";
        details += "\t--------------------------------------\n";
        return details;
    }
}