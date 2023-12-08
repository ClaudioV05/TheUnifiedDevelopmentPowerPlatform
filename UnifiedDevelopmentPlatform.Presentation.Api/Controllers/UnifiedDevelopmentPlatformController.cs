using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Controllers
{
    [ApiController]
    [Route(ControllerRouter.RouteController)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(FilterActionContextController), Order = ControllerOrderExecutationFilter.First)]
    [EnableCors()]
    public class UnifiedDevelopmentPlatformController : ControllerBase
    {
        private readonly IServiceMetadata _serviceMetadata;

        public UnifiedDevelopmentPlatformController(IServiceMetadata serviceMetadata)
        {
            _serviceMetadata = serviceMetadata;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route(ControllerRouter.RouteMetadataAllTablesName)]
        [ApiExplorerSettings(IgnoreApi = ControllerActionVisible.Yes)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<Metadata>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] AppMetadata metadata)
        {
            Metadata objMddata = new Metadata()
            {
                ScriptMetadata = metadata.ScriptMetadata,
            };

            return Ok(_serviceMetadata.MetadataAllTablesName(metadata: objMddata));
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route(ControllerRouter.RouteMetadataAllFieldsName)]
        [ApiExplorerSettings(IgnoreApi = ControllerActionVisible.Not)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextFields<Metadata>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [DisableCors]
        public ActionResult<List<string>> MetadataAllFieldsName([BindRequired] Metadata metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            return new List<string>() { "Jesus" };
        }
    }
}