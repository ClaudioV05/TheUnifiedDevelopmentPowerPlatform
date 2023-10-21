using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Filters;
using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Metadata = AppSolution.Infraestructure.Domain.Entities.Metadata;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    [ServiceFilter(typeof(AppSolutionControllerFilter), Order = 1)]
    public class AppSolutionController : ControllerBase
    {
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceMetadata _serviceMetadata;

        public AppSolutionController(IServiceDirectory serviceDirectory,
                                     IServiceMetadata serviceMetadata)
        {
            _serviceDirectory = serviceDirectory;
            _serviceMetadata = serviceMetadata;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("MetadataAllTablesName")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ServiceFilter(typeof(LogRegisterFilter), Order = 2)]
        [ServiceFilter(typeof(ValidateEntityFilter), Order = 3)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] Metadata metadata)
        {
            List<string> returnTables = new List<string>();
            try
            {
                if (ModelState.IsValid)
                {
                    returnTables = _serviceMetadata.MetadataAllTablesName(metadata);

                    if (returnTables is not null && returnTables.Count > 0)
                    {
                        _serviceDirectory.CreateDefaultDirectory();
                    }
                }
            }
            catch (Exception ex)
            {
                returnTables?.Append(ex.Message);
            }

            return returnTables ?? new List<string>();
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("MetadataAllFieldsName")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ServiceFilter(typeof(LogRegisterFilter), Order = 2)]
        [ServiceFilter(typeof(ValidateEntityFilter), Order = 3)]
        public ActionResult<List<string>> MetadataAllFieldsName([BindRequired] Metadata metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            return new List<string>() { "Jesus" };
        }
    }
}