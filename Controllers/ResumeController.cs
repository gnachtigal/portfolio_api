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
        public ActionResult<String> Get()
        {
            Resume resume = new Resume() {  Data = "<span> This is a resume data test </span>" };
            return Ok(resume);
        }
    }
}

class Resume
{
    public String Data { get; set; }
}