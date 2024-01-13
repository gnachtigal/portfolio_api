using Octokit;

namespace portfolio_api.Models
{
    public class CommitDTO
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }


        public CommitDTO(string message, string url, DateTime timestamp, string author)
        {
            Message = message;
            Url = url;
            Timestamp = timestamp;
            Author = author;
        }

        public static CommitDTO From(GitHubCommit commit)
        {
            return new CommitDTO(
                commit.Commit.Message, 
                commit.Url, 
                new DateTime(), 
                commit.Commit.Author.Name);
        }
    }
}
