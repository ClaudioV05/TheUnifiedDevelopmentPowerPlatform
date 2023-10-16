using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Filters;
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
        private readonly IServicesDirectory _servicesDirectory;
        private readonly IServicesGenerateTablesName _generateTablesName;

        public AppSolutionController(IServicesDirectory servicesDirectory, IServicesGenerateTablesName generateTablesName)
        {
            _servicesDirectory = servicesDirectory;
            _generateTablesName = generateTablesName;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateAllTablesName")]
        [Produces("application/json")]
        [ServiceFilter(typeof(AppSolutionFilter))]
        [ApiExplorerSettings(IgnoreApi = false)]
        public ActionResult<List<string>> GenerateAllTablesName([BindRequired] Metadata metadata)
        {

            throw new Exception("Erro teste");
            List<string> returnTables = null;
            var generateClass = new GenerateClass();
            var tables = new Tables();
            try
            {
                if (ModelState.IsValid)
                {
                    generateClass.Metadata = metadata.ScriptMetadata;

                    returnTables = _generateTablesName.returnListTables(generateClass);

                    if (returnTables != null && returnTables?.Count > 0)
                    {
                        _servicesDirectory.CreateDefaultDirectory();
                    }
                }
                else
                {
                    returnTables = null;
                }
            }
            catch (Exception ex)
            {
                returnTables?.Add(ex.Message);
            }

            return returnTables;
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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