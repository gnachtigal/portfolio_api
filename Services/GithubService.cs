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

        public async Task<Object> GetUserPublicEvents(string username)
        {
            var result = await _client.Activity.Events.GetAllUserPerformed(username);
            return result;
        }
    }

    public interface IGithubService
    {
        public Task<Object> GetUserPublicEvents(string username);
    }
}
