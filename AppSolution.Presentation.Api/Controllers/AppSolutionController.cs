using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Infraestructure.Domain.Enums;
using AppSolution.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppSolution.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    public class AppSolutionController : ControllerBase
    {
        private readonly IGenerateTablesName _generateTablesName;

        public AppSolutionController(IGenerateTablesName generateTablesName)
        {
            _generateTablesName = generateTablesName;
        }

        /// <summary>
        /// Generate tables name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateTablesName")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public List<string> GenerateTablesName([BindRequired] Metadata metadata)
        {
            List<string> returnTables = null;
            var generateClass = new GenerateClass();
            var tables = new Tables();
            try
            {
                if (ModelState.IsValid)
                {
                    generateClass.Metadata = metadata.ScriptMetadata;
                    generateClass.Databases.Type = (DatabasesType)metadata.IdDatabases;
                    generateClass.Forms.Type = (FormTypes)metadata.IdForms;
                    generateClass.DevEnvironment.Type = (DevEnvironmentTypes)metadata.IdDevelopmentEnvironment;

                    returnTables = _generateTablesName.TablesName(generateClass);
                    
                    tables?.Name.Append(returnTables.ToString());

                    // persist metadata with entitie framework.
                }
                else
                {
                    returnTables = null;
                }
            }
            catch (Exception ex)
            {
                returnTables?.Append(ex.Message);
            }

            return returnTables;
        }

        /// <summary>
        ///  Generate fields name of Metadata.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateFieldsName")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<string> GenerateFieldsName()
        {
            /*
             * Here return 2 list of objects in filters.
             * One contain the name of table and other contain fieldsname.
             */
            return new List<string>() { "Jesus" };
        }
    }
}