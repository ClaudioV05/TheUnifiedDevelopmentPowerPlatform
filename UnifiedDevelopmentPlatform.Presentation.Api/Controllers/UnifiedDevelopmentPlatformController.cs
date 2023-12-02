using UnifiedDevelopmentPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Controllers
{
    /// <summary>
    /// Direction Router.
    /// </summary>
    public record DirectionRouter
    {
        public const string RouteController = "[Controller]";
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }

    /// <summary>
    /// Order Filter Executation.
    /// </summary>
    public record OrderFilterExecutation
    {
        public const int First = 1;
        public const int Second = 2;
        public const int Third = 3;
    }

    /// <summary>
    /// Method Visible in API.
    /// </summary>
    public record MethodVisibleInApi
    {
        public const bool Yes = false;
        public const bool Not = true;
    }

    [ApiController]
    [Route(DirectionRouter.RouteController)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(FilterActionContextController), Order = OrderFilterExecutation.First)]
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
        [Route(DirectionRouter.RouteMetadataAllTablesName)]
        [ApiExplorerSettings(IgnoreApi = MethodVisibleInApi.Yes)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = OrderFilterExecutation.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<Metadata>), Order = OrderFilterExecutation.Third)]
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
        [Route(DirectionRouter.RouteMetadataAllFieldsName)]
        [ApiExplorerSettings(IgnoreApi = MethodVisibleInApi.Not)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = OrderFilterExecutation.Second)]
        [ServiceFilter(typeof(FilterActionContextFields<Metadata>), Order = OrderFilterExecutation.Third)]
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