using Microsoft.AspNetCore.Mvc;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {

        }

        [Produces("application/json", "application/xml")]
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>() { "Jesus" };
        }
    }
}