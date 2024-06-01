using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Controllers;

/// <summary>
/// Controller unified development platform parameters.
/// </summary>
[ApiController]
[Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterController)]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
[ServiceFilter(typeof(FilterActionContextControllerInformation), IsReusable = false, Order = ControllerOrderExecutationFilter.First)]
[EnableCors()]
public class UnifiedDevelopmentPowerPlatformParametersController : ControllerBase
{
    private readonly IServiceMetadata _serviceMetadata;

    /// <summary>
    /// Constructor of controller unified development platform parameters.
    /// </summary>
    /// <param name="serviceMetadata"></param>
    public UnifiedDevelopmentPowerPlatformParametersController(IServiceMetadata serviceMetadata)
    {
        _serviceMetadata = serviceMetadata;
    }

    /// <summary>
    /// Return the complete list of databases.
    /// </summary>
    /// <returns>List of databases with ids and names.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfDatabases)]
    [ProducesResponseType(typeof(IEnumerable<Databases>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<IEnumerable<Databases>> ParametersTheKindsOfDatabases()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersTheKindsOfDatabases());
    }

    /// <summary>
    /// Return the complete list of forms.
    /// </summary>
    /// <returns>List of forms with ids and names.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfForms)]
    [ProducesResponseType(typeof(IEnumerable<FormsView>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<IEnumerable<FormsView>> ParametersTheKindsOfForms()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersTheKindsOfForms());
    }

    /// <summary>
    /// Return the complete list of development environment.
    /// </summary>
    /// <returns>List of development environment with ids and names.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfDevelopmentEnviroment)]
    [ProducesResponseType(typeof(IEnumerable<DevelopmentEnvironments>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<IEnumerable<DevelopmentEnvironments>> ParametersTheKindsOfDevelopmentEnvironment()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersTheKindsOfDevelopmentEnviroment());
    }

    /// <summary>
    /// Return the complete list of databases engine.
    /// </summary>
    /// <returns>List of databases engine with ids and names.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfDatabasesEngine)]
    [ProducesResponseType(typeof(IEnumerable<DatabasesEngine>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<IEnumerable<DatabasesEngine>> ParametersTheKindsOfDatabasesEngine()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersTheKindsOfDatabasesEngine());
    }

    /// <summary>
    /// Return the complete list of architecture patterns.
    /// </summary>
    /// <returns>List of architecture patterns with ids and names.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfArchitecturePatterns)]
    [ProducesResponseType(typeof(IEnumerable<ArchitecturePatterns>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<IEnumerable<ArchitecturePatterns>> ParametersTheKindsOfArchitecturePatterns()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersTheKindsOfArchitecturePatterns());
    }

    /// <summary>
    /// Return the parameters about Unified development platform.
    /// </summary>
    /// <returns>Information about Unified development platform.</returns>
    /// 200 Status Codes: This is the best kind of HTTP status code to receive. A 200-level response means that everything is working exactly as it should.
    /// <response code="200">Everything is OK.</response>
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
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Route(ControllerRouterUnifiedDevelopmentPowerPlatformParameters.RouterParametersOfInformation)]
    [ProducesResponseType(typeof(UnifiedDevelopmentParameters), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    [EnableCors("AllowOrigin")]
    public ActionResult<UnifiedDevelopmentParameters> Informations()
    {
        return Ok(_serviceMetadata.UDPPSelectParametersInformationUnifiedDevelopmentPowerPlatform());
    }
}