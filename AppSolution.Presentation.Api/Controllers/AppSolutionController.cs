using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public IEnumerable<string> GenerateTablesName([BindRequired] Metadata metadata)
        {
            var tables = new List<string>();

            try
            {
                if (ModelState.IsValid)
                {
                    // Call Services.
                }
                else
                {
                    tables = null;
                }
            }
            catch (Exception ex)
            {
                tables?.Add(ex.Message);
            }

            return tables;
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
            /*
             * Here return 2 list of objects in filters.
             * One contain the name of table and other contain fieldsname.
             */
            return new List<string>() { "Jesus" };
        }
    }
}