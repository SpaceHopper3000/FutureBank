using FutureBank.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestRateController : ControllerBase
    {
        private readonly ILogger<InterestRateController> _logger;

        public InterestRateController(ILogger<InterestRateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-current-rate")]
        public async Task<IActionResult> GetCurrentRateAsync()
        {
            return Ok(new InterestRate { Id = 1, Rate = 2.5 });
        }
    
    }
}