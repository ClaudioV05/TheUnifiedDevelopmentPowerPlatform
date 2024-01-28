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
        private readonly IServiceMetadata _serviceMetadata;

        /// <summary>
        /// Constructor Unified Development Platform Controller.
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
        /// <returns>List of string with names of tables</returns>
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
        [Route(ControllerRouter.RouteMetadataAllTablesName)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<MetadataOwner>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] AppMetadata metadata)
        {
            return Ok(_serviceMetadata.UDPReceiveAndSaveAllTableOfSchemaDatabase(metadata: new MetadataOwner() { DatabaseSchema = metadata.DatabaseSchema }));
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
        [Route(ControllerRouter.RouteMetadataAllFieldsName)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = ControllerOrderExecutationFilter.Second)]
        [ServiceFilter(typeof(FilterActionContextFields<MetadataOwner>), Order = ControllerOrderExecutationFilter.Third)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        public ActionResult<List<string>> MetadataAllFieldsName([BindRequired] MetadataOwner metadata)
        {
            // Here enter with field name only. Load the property [Fields].
            // Return the table name and your fields.

            _serviceMetadata.UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(metadata: new MetadataOwner() { DatabaseSchema = metadata.DatabaseSchema });
            return Ok();
        }
    }
}