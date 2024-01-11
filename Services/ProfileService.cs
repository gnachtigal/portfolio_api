using portfolio_api.Helpers;

namespace portfolio_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMarkdownFileProcesser _mdFileProcesser;
        private readonly HttpClient _client;

        public ProfileService(IMarkdownFileProcesser mdFileProcesser, HttpClient client)
        {
            _mdFileProcesser = mdFileProcesser ?? throw new ArgumentNullException(nameof(mdFileProcesser));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetSectionData(string section)
        {
            try
            {
                if (string.IsNullOrEmpty(section))
                {
                    throw new ArgumentNullException(nameof(section));
                }

                var mdContent = await _client.GetStringAsync($"{_client.BaseAddress}/{section}.md");
                return mdContent;
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting section data {section}", e);
            }
        }

        public async Task<string> GetSectionHtml(string section)
        {
            try
            {
                if (string.IsNullOrEmpty(section))
                {
                    throw new ArgumentNullException(nameof(section));
                }

                var mdContent = await GetSectionData(section);
                var htmlData = _mdFileProcesser.GetHtmlFrom(mdContent);
                return htmlData;
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting section html {section}", e);
            }
        }

    }
    public interface IProfileService
    {
        public Task<string> GetSectionData(string section);

        public Task<string> GetSectionHtml(string section);
    }
}
