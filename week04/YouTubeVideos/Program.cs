using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTubeVideos Project Output\n");

        List<Video> videos = new List<Video>();

        // Create and populate videos
        Video video1 = new Video("Exploring the Ocean", "MarineLife", 540);
        video1.AddComment(new Comment("Alice", "Amazing creatures!"));
        video1.AddComment(new Comment("Bob", "Learned so much!"));
        video1.AddComment(new Comment("Cathy", "I love dolphins!"));

        Video video2 = new Video("Top 10 Coding Tips", "CodeMaster", 300);
        video2.AddComment(new Comment("Dave", "Tip #3 saved my life."));
        video2.AddComment(new Comment("Eve", "Very useful tips, thanks!"));
        video2.AddComment(new Comment("Frank", "More like this please."));

        Video video3 = new Video("Epic Mountain Biking", "TrailRider", 480);
        video3.AddComment(new Comment("Grace", "That jump was insane!"));
        video3.AddComment(new Comment("Henry", "What camera do you use?"));
        video3.AddComment(new Comment("Isla", "Makes me want to ride."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
