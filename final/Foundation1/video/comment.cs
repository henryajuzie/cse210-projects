using System;
using System.Collections.Generic;

// Class to represent a comment on a YouTube video
public class Comment
{
    // Attributes
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Class to represent a YouTube video
public class Video
{
    // Attributes
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        comments.Add(newComment);
    }

    // Method to return the number of comments on the video
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display details of the video
    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
        Console.WriteLine();
    }
}
