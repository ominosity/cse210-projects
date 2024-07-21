/// <summary>
/// Represents a comment on a video, with the commenter's name
/// </summary>
public class Comment 
{
    private string _commenter;
    private string _commentText;

    /// <summary>
    /// Create a comment
    /// </summary>
    /// <param name="commenter">The person making the comment</param>
    /// <param name="commentText">The text of the comment</param>
    public Comment(string commenter, string commentText)
    {
        _commenter = commenter;
        _commentText = commentText;
    }

    /// <summary>
    /// Get the details of the comment (commenter and text) with a tabbed line beneath it
    /// </summary>
    /// <returns>A string with the commenter, comment text, and a tabbed-in line beneath to separate it from other comments</returns>
    public string GetCommentDetails() 
    {
        string details = $"{_commenter}: {_commentText}\n";
        details += "\t--------------------------------------\n";
        return details;
    }
}