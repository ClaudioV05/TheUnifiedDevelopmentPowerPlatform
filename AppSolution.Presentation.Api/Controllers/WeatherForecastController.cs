using Microsoft.AspNetCore.Mvc;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Produces("application/json" , "application/xml")]
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>() { "Jesus" };
        }
    }
}