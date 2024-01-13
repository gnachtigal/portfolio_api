using Octokit;

namespace portfolio_api.Services
{
    public class GithubService : IGithubService
    {
        private readonly GitHubClient _client;

        public GithubService()
        {
            _client = new GitHubClient(new ProductHeaderValue("portfolio-api"));
        }

        public async Task<Object> GetRepositoryLastCommits(string username, string repository)
        {
            var result = await _client.Repository.Commit.GetAll(username, repository);
            return result;
        }
    }

    public interface IGithubService
    {
        public Task<Object> GetRepositoryLastCommits(string username, string repository);
    }
}
