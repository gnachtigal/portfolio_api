using Microsoft.AspNetCore.Mvc;
using portfolio_api.Helpers;
using portfolio_api.Models;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IMarkdownFileProcesser _mdFileProcesser;

        public ProfileController(ILogger<ProfileController> logger, IMarkdownFileProcesser markdownFileProcesser)
        {
            _logger = logger;
            _mdFileProcesser = markdownFileProcesser;
        }

        [HttpGet()]
        public async Task<ActionResult<Profile>> Get([FromQuery] string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                return BadRequest();
            }
            HttpClient client = new HttpClient();
            var url = $"https://raw.githubusercontent.com/gnachtigal/portfolio_data/master/{section}.md";
            var mdContent = await client.GetStringAsync(url);

            var htmlData = _mdFileProcesser.GetHtmlFrom(mdContent);

            var profile = new Profile
            {
                Description = htmlData
            };

            return Ok(profile);
        }
    }

}