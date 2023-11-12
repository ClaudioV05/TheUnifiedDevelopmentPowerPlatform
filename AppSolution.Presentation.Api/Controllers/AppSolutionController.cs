using AppSolution.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Filters;
using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using System.Numerics;
using Mddata = AppSolution.Infraestructure.Domain.Entities.Metadata;

namespace AppSolution.Presentation.Api.Controllers
{
    public record DirectionRouter
    {
        public const string RouteController = "[Controller]";
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }

    public record OrderFilterExecutation
    {
        public const int First = 1;
        public const int Second = 2;
        public const int Third = 3;
    }

    public record MethodVisible
    {
        public const bool Visible = true;
        public const bool NotVisible = false;
    }

    [ApiController]
    [Route(DirectionRouter.RouteController)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(FilterActionContextController), Order = OrderFilterExecutation.First)]
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
        [Route(DirectionRouter.RouteMetadataAllTablesName)]
        [ApiExplorerSettings(IgnoreApi = MethodVisible.Visible)]
        [ServiceFilter(typeof(FilterActionContextLog), Order = OrderFilterExecutation.Second)]
        [ServiceFilter(typeof(FilterActionContextTables<Metadata>), Order = OrderFilterExecutation.Third)]
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
        [Route(DirectionRouter.RouteMetadataAllFieldsName)]
        [ApiExplorerSettings(IgnoreApi = MethodVisible.Visible)]
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