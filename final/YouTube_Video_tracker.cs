using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video()
    {
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video { Title = "Video 1", Author = "Author 1", LengthInSeconds = 120, Comments = new List<Comment> {
                new Comment { CommenterName = "User 1", Text = "Great video!" },
                new Comment { CommenterName = "User 2", Text = "Very informative." }
            }},
            new Video { Title = "Video 2", Author = "Author 2", LengthInSeconds = 240, Comments = new List<Comment> {
                new Comment { CommenterName = "User 3", Text = "Awesome content!" },
                new Comment { CommenterName = "User 4", Text = "Thanks for sharing." }
            }},

        };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.LengthInSeconds} seconds, Number of comments: {video.GetNumberOfComments()}");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}


