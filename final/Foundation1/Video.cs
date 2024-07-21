using System.Text;
/// <summary>
/// Represents a YouTube video + list of comments
/// </summary>
public class Video 
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    /// <summary>
    /// Create a new Video
    /// </summary>
    /// <param name="title">The title of the video</param>
    /// <param name="author">The author of the video</param>
    /// <param name="length">The length of the video, in seconds</param>
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;

        _comments = new List<Comment>();
    }

    /// <summary>
    /// Get the count of comments on this video
    /// </summary>
    /// <returns>An integer representing the number of comments on this video</returns>
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    /// <summary>
    /// Add a comment to this video
    /// </summary>
    /// <param name="comment">A Comment object representing a comment on this video</param>
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    /// <summary>
    /// Get the single-line description of this video
    /// </summary>
    /// <returns>A string with the title, author, length in seconds, and count of comments</returns>
    public string GetDescription() 
    {
        string description = $"{_title} by {_author}, {_length} seconds, {GetNumberOfComments()} comments.";
        return description;
    }

    /// <summary>
    /// Get the list of comments as a string with newlines
    /// </summary>
    /// <returns>A string with c</returns>
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