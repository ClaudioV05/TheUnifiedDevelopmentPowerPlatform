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
    /// Controller unified development platform.
    /// </summary>
    [ApiController]
    [Route(ControllerRouterUnifiedDevelopmentPlatform.RouterController)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ServiceFilter(typeof(FilterActionContextController), IsReusable = false, Order = ControllerOrderExecutationFilter.First)]
    [EnableCors()]
    public class UnifiedDevelopmentPlatformController : ControllerBase
    {
        private readonly IServiceMetadata _serviceMetadata;

        /// <summary>
        /// Constructor of controller unified development platform.
        /// </summary>
        /// <param name="serviceMetadata"></param>
        public UnifiedDevelopmentPlatformController(IServiceMetadata serviceMetadata)
        {
            _serviceMetadata = serviceMetadata;
        }

        /// <summary>
        /// Receive and save all table of schema database.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>The list of tables with name(s) and field(s) of schema database.</returns>
        /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
        /// <response code="200">Everything is OK.</response>
        /// <response code="201">Created.</response>
        /// 400 Status Codes: At the 400 level, HTTP status codes start to become problematic. These are error codes specifying that there’s a fault with your browser and/or request.
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized or Authorization Required.</response>
        /// <response code="403">Access to that resource is forbidden.</response>
        /// <response code="404">The requested resource was not found.</response>
        /// 500 Status Codes: 500-level status codes are also considered errors. However, they denote that the problem is on the server’s end. This can make them more difficult to resolve.
        /// <response code="500">There was an error on the server and the request could not be completed.</response>
        /// <response code="502">Bad Gateway.</response>
        /// <response code="503">The server is unavailable to handle this request right now.</response>
        /// <response code="504">The server, acting as a gateway, timed out waiting for another server to respond.</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Route(ControllerRouterUnifiedDevelopmentPlatform.RouterTablesAndFieldsOfMetadata)]
        [ServiceFilter(typeof(FilterActionContextLog), IsReusable = false, Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<MetadataOwner>), IsReusable = false, Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tables>))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        [DisableCors]
        public ActionResult<List<Tables>> TablesAndFieldsOfMetadata([BindRequired] Metadata metadata)
        {
            return Ok(_serviceMetadata.UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(metadata: new MetadataOwner()
            {
                DatabaseSchema = metadata.DatabaseSchema,
                Forms = new List<Forms>() { new Forms() { Id = metadata.IdForms } }
            }));
        }

        /// <summary>
        /// Receive and save all table and fields of schema database.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List of string with fields names of tables</returns>
        /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
        /// <response code="200">Everything is OK.</response>
        /// <response code="201">Created.</response>
        /// 400 Status Codes: At the 400 level, HTTP status codes start to become problematic. These are error codes specifying that there’s a fault with your browser and/or request.
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized or Authorization Required.</response>
        /// <response code="403">Access to that resource is forbidden.</response>
        /// <response code="404">The requested resource was not found.</response>
        /// 500 Status Codes: 500-level status codes are also considered errors. However, they denote that the problem is on the server’s end. This can make them more difficult to resolve.
        /// <response code="500">There was an error on the server and the request could not be completed.</response>
        /// <response code="502">Bad Gateway.</response>
        /// <response code="503">The server is unavailable to handle this request right now.</response>
        /// <response code="504">The server, acting as a gateway, timed out waiting for another server to respond.</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Route(ControllerRouterUnifiedDevelopmentPlatform.RouterMetadataAllFieldsName)]
        [ServiceFilter(typeof(FilterActionContextLog), IsReusable = false, Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextFields<MetadataOwner>), IsReusable = false, Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MetadataOwner))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        [DisableCors]
        public ActionResult<MetadataOwner> MetadataAllFieldsName([BindRequired] Metadata metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            _serviceMetadata.UDPNotImplemented(metadata: new MetadataOwner() { DatabaseSchema = metadata.DatabaseSchema });
            return Ok();
        }
    }
}