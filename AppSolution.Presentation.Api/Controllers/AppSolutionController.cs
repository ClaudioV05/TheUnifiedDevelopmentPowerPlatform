using AppSolution.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Filters;
using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using Mddata = AppSolution.Infraestructure.Domain.Entities.Metadata;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(FilterActionContextController), Order = 1)]
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
        [Produces(MediaTypeNames.Application.Json)]
        [Route("/MetadataAllTablesName")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
        [ServiceFilter(typeof(FilterActionContextTables<Metadata>), Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] AppMetadata metadata)
        {
            Mddata objMddata = new Mddata()
            {
                ScriptMetadata = metadata.ScriptMetadata,
            };

            return _serviceMetadata.MetadataAllTablesName(metadata: objMddata);
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("/MetadataAllFieldsName")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
        [ServiceFilter(typeof(FilterActionContextFields<Metadata>), Order = 3)]
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