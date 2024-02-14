using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    internal sealed class FilterActionContextTables<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// Filter action context tables.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncStrings"></param>
        public FilterActionContextTables(IServiceLog serviceLog,
                                         IServiceMessage serviceMessage, 
                                         IServiceDirectory serviceDirectory, 
                                         IServiceValidation serviceValidation, 
                                         IServiceFuncString serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = string.Empty;

            try
            {
                if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabaseSchemaIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPMetadataIsBase64Ok(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDevelopmentEnvironmentIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabasesIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabasesEngineIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPFormIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPArchitectureOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }
            }
            catch (Exception)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorFilterActionContextTables));
                throw new Exception(_serviceFuncStrings.UDPUpper(MessageDescription.ErrorFilterActionContextTables));
            }

            await next();

            try 
            {
                _serviceDirectory.UPDCreateDirectoryProjectOfSolution();
            }
            catch (Exception)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorCreateAllDirectory));
                throw new Exception(_serviceFuncStrings.UDPUpper(MessageDescription.ErrorCreateAllDirectory));
            }
        }

        private static void HasMessage(ActionExecutingContext context, string message)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails() { StatusCode = 1, Message = message });
        }
    }
}