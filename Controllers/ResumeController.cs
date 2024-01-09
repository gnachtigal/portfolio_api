using Microsoft.AspNetCore.Mvc;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<ResumeController> _logger;

        public ResumeController(ILogger<ResumeController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<String>> Get()
        {
            HttpClient client = new HttpClient();
            var url = "https://raw.githubusercontent.com/gnachtigal/portfolio_data/master/cv.tex";
            var content = await client.GetStringAsync(url);

            Resume resume = new Resume() {  Data = content };

            return Ok(resume);
        }
    }

}

class Resume
{
    public String Data { get; set; }
}
