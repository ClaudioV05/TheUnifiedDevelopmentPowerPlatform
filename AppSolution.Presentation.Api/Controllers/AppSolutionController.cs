using Microsoft.AspNetCore.Mvc;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    public class AppSolutionController : ControllerBase
    {
        public AppSolutionController()
        {

        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateTablesName")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public List<string> GenerateTablesName()
        {
            return new List<string>() { "Jesus" };
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateFieldsName")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<string> GenerateFieldsName()
        {
            return new List<string>() { "Jesus" };
        }
    }
}