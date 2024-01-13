using Octokit;
using portfolio_api.Models;

namespace portfolio_api.Services
{
    public class GithubService : IGithubService
    {
        private readonly GitHubClient _client;

        public GithubService()
        {
            _client = new GitHubClient(new ProductHeaderValue("portfolio-api"));
        }

        public async Task<List<CommitDTO>> GetRepositoryLastCommits(string username, string repository)
        {
            var result = await _client.Repository.Commit.GetAll(username, repository);
            return result.Select(c => CommitDTO.From(c)).ToList();
        }
    }

    public interface IGithubService
    {
        public Task<List<CommitDTO>> GetRepositoryLastCommits(string username, string repository);
    }
}
