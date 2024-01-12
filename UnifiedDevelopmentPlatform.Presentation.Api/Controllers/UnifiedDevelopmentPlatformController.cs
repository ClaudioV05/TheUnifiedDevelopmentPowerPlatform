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
    /// <summary>
    /// Unified Development Platform - Controller.
    /// </summary>
    [ApiController]
    [Route(ControllerRouter.RouteController)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(FilterActionContextController), Order = ControllerOrderExecutationFilter.First)]
    [EnableCors()]
    public class UnifiedDevelopmentPlatformController : ControllerBase
    {
        private readonly IServiceMetadataTables _serviceMetadataTables;

        /// <summary>
        /// Constructor Unified Development Platform Controller.
        /// </summary>
        /// <param name="serviceMetadataTables"></param>
        public UnifiedDevelopmentPlatformController(IServiceMetadataTables serviceMetadataTables)
        {
            _serviceMetadataTables = serviceMetadataTables;
        }

        /// <summary>
        /// Generate all tables name of Metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List of string with names of tables</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route(ControllerRouter.RouteMetadataAllTablesName)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<MetadataOwner>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] AppMetadata metadata)
        {
            MetadataOwner objMddata = new MetadataOwner()
            {
                ScriptMetadata = metadata.ScriptMetadata,
            };

            return Ok(_serviceMetadataTables.UDPMetadataAllTablesName(metadata: objMddata));
        }

        /// <summary>
        /// Generate all fields name of Metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List of string with fields names of tables</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Route(ControllerRouter.RouteMetadataAllFieldsName)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextFields<MetadataOwner>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [DisableCors]
        public ActionResult<List<string>> MetadataAllFieldsName([BindRequired] MetadataOwner metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            return Ok(new List<string>() { "Jesus" });
        }
    }
}