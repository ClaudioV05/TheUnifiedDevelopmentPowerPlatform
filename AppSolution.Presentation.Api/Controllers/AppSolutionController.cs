using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Presentation.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using Metadata = AppSolution.Infraestructure.Domain.Entities.Metadata;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(AppSolutionControllerFilter), Order = 1)]
    public class AppSolutionController : ControllerBase
    {
        private readonly IServiceMetadata _serviceMetadata;

        public AppSolutionController(IServiceMetadata serviceMetadata)
        {
            _serviceMetadata = serviceMetadata;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("/MetadataAllTablesName")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ServiceFilter(typeof(LogRegisterFilter), Order = 2)]
        [ServiceFilter(typeof(ValidateEntityMetadataTablesFilter<Metadata>), Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] Metadata metadata)
        {
            return _serviceMetadata.MetadataAllTablesName(metadata);
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("/MetadataAllFieldsName")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ServiceFilter(typeof(LogRegisterFilter), Order = 2)]
        [ServiceFilter(typeof(ValidateEntityMetadataFieldsFilter<Metadata>), Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> MetadataAllFieldsName([BindRequired] Metadata metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            return new List<string>() { "Jesus" };
        }
    }
}