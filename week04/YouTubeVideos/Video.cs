using System;

public class Video
{
    public string Title;
    public string Author;
    public int Length; 
    public List<Comment> Comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public string GetDetails()
    {
        string details = $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of Comments: {GetNumberOfComments()}\nComments:\n";
        foreach (var comment in Comments)
        {
            details += $"- {comment.CommenterName}: {comment.Text}\n";
        }
        return details;
    }
}