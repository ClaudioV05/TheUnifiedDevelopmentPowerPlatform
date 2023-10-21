using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Filters;
using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Metadata = AppSolution.Infraestructure.Domain.Entities.Metadata;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    public class AppSolutionController : ControllerBase
    {
        private readonly IServicesDirectory _servicesDirectory;
        private readonly IServicesMetadata _servicesMetadata;

        public AppSolutionController(IServicesDirectory servicesDirectory,
                                     IServicesMetadata servicesMetadata)
        {
            _servicesDirectory = servicesDirectory;
            _servicesMetadata = servicesMetadata;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MetadataAllTablesName")]
        [Produces("application/json")]
        [ServiceFilter(typeof(AppSolutionFilter))]
        [ApiExplorerSettings(IgnoreApi = false)]
        public ActionResult<List<string>> MetadataAllTablesName([BindRequired] Metadata metadata)
        {
            List<string> returnTables = new List<string>();
            try
            {
                if (ModelState.IsValid)
                {
                    returnTables = _servicesMetadata.MetadataAllTablesName(metadata);

                    if (returnTables != null && returnTables.Count > 0)
                    {
                        _servicesDirectory.CreateDefaultDirectory();
                    }
                }
            }
            catch (Exception ex)
            {
                returnTables?.Append(ex.Message);
            }

            return returnTables ?? new List<string>();
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MetadataAllFieldsName")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public List<string> MetadataAllFieldsName()
        {
            
            /*
             * Here return 2 list of objects in filters.
             * One contain the name of table and other contain fieldsname.
             */
            return new List<string>() { "Jesus" };
        }
    }
}