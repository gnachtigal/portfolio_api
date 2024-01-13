using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;
        private readonly IGithubService _githubService;
        

        public ProfileController(ILogger<ProfileController> logger, IProfileService profileService, IGithubService githubService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _githubService = githubService ?? throw new ArgumentNullException(nameof(githubService));
        }

        [HttpGet()]
        public async Task<ActionResult<Profile>> Get([FromQuery] string section) 
            => string.IsNullOrEmpty(section) ? BadRequest() 
            : Ok(new Profile { Description = await _profileService.GetSectionHtml(section) });

        [HttpGet("changelog")]
        public async Task<ActionResult<Profile>> Changelog() => Ok(await _githubService.GetUserPublicEvents("gnachtigal"));
    }

}