using System.ComponentModel.DataAnnotations;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string DisplayInfo()
    {
        return $"-{_commenterName}: {_commentText}";
    }
}