using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;
        

        public ProfileController(ILogger<ProfileController> logger, IProfileService profileService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }

        [HttpGet()]
        public async Task<ActionResult<Profile>> Get([FromQuery] string section) 
            => string.IsNullOrEmpty(section) ? BadRequest() 
            : Ok(new Profile { Description = await _profileService.GetSectionHtml(section) });
    }

}