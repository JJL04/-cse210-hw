using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video { Title = "Video 1", Author = "Author A", Length = 300 };
            video1.AddComment(new Comment("Alice", "Great video!"));
            video1.AddComment(new Comment("Bob", "I learned a lot."));
            video1.AddComment(new Comment("Carol", "Awesome content!"));

            Video video2 = new Video { Title = "Video 2", Author = "Author B", Length = 180 };
            video2.AddComment(new Comment("Dave", "Interesting approach."));
            video2.AddComment(new Comment("Eve", "Very helpful."));
            video2.AddComment(new Comment("Frank", "Clear and concise."));

            List<Video> videos = new List<Video> { video1, video2 };

            foreach (Video v in videos)
            {
                Console.WriteLine($"\nTitle: {v.Title}");
                Console.WriteLine($"Author: {v.Author}");
                Console.WriteLine($"Length: {v.Length} seconds");
                Console.WriteLine($"Number of comments: {v.GetCommentCount()}");

                foreach (Comment c in v.GetComments())
                {
                    Console.WriteLine($"- {c.CommenterName}: {c.CommentText}");
                }
            }
        }
    }
}
