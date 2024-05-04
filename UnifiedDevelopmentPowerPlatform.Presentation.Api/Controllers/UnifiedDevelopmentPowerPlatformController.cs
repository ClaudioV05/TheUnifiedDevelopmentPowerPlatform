using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Controllers;

/// <summary>
/// Controller Unified Development Power Platform - UDPP.
/// </summary>
[ApiController]
[Route(ControllerRouterUnifiedDevelopmentPowerPlatform.RouterController)]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
[ServiceFilter(typeof(FilterActionContextController), IsReusable = false, Order = ControllerOrderExecutationFilter.First)]
[EnableCors()]
public class UnifiedDevelopmentPowerPlatformController : ControllerBase
{
    private readonly IServiceMetadata _serviceMetadata;

    /// <summary>
    /// Constructor of controller unified development power platform.
    /// </summary>
    /// <param name="serviceMetadata"></param>
    public UnifiedDevelopmentPowerPlatformController(IServiceMetadata serviceMetadata)
    {
        _serviceMetadata = serviceMetadata;
    }

    /// <summary>
    /// To receive the schema of database and do the creation of the tables with their fields.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref />
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception></exception>
    /// <seealso href=""></seealso>
    /// <returns>The list of tables with their name(s) and field(s) after extract data of database schema.</returns>
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
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatform.RouterMetadata)]
    [ServiceFilter(typeof(FilterActionContextLog), IsReusable = false, Order = ControllerOrderExecutationFilter.Second)]
    [ServiceFilter(typeof(FilterActionContextMetadata<MetadataOwner>), IsReusable = false, Order = ControllerOrderExecutationFilter.Third)]
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
    public ActionResult<List<Tables>> Metadata([BindRequired] DtoMetadata metadata)
    {
        MetadataOwner metadataOwner = new MetadataOwner()
        {
            DatabaseSchema = metadata.DatabaseSchema,
            FormsView = new List<FormsView>()
            {
                new FormsView()
                {
                    Id = metadata.IdForms
                }},
            Databases = new List<Databases>()
            {
                new Databases()
                {
                    Id = metadata.IdDatabases
                }},
            DatabasesEngine = new List<DatabasesEngine>()
            {
                new DatabasesEngine()
                {
                    Id = metadata.IdDatabasesEngine
                }},
            ArchitecturePatterns = new List<ArchitecturePatterns>()
            {
                new ArchitecturePatterns()
                {
                    Id = metadata.Architecture
                }},
            DevelopmentEnvironments = new List<DevelopmentEnvironments>()
            {
                new DevelopmentEnvironments()
                {
                    Id = metadata.IdDevelopmentEnvironment
                }},
        };

        return Ok(_serviceMetadata.UDPPReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase(metadata: metadataOwner));
    }

    /// <summary>
    /// To receive the table(s) with their field(s) that will generate the magic solution - UDPP.
    /// </summary>
    /// <param name="tablesdata"></param>
    /// <paramref />
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception></exception>
    /// <seealso href=""></seealso>
    /// <returns>The solution in the format specified.</returns>
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
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatform.RouterTablesdata)]
    [ServiceFilter(typeof(FilterActionContextLog), IsReusable = false, Order = ControllerOrderExecutationFilter.Second)]
    [ServiceFilter(typeof(FilterActionContextTablesdata<MetadataOwner>), IsReusable = false, Order = ControllerOrderExecutationFilter.Third)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
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
    public ActionResult Tablesdata([BindRequired] DtoTablesdata tablesdata)
    {
        MetadataOwner metadataOwner = new MetadataOwner()
        {
            Tables = tablesdata.Tables
        };

        return Ok(_serviceMetadata.UDPPReceiveTheTablesdataAndGenerateTheSolution(metadata: metadataOwner));
    }
}