using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }

        private List<Comment> comments = new List<Comment>();

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
