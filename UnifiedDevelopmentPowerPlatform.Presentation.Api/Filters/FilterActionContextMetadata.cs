using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters
{
    /// <summary>
    /// Filter action context tables and fields of metadata.
    /// </summary>
    internal sealed class FilterActionContextMetadata<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// Filter action context tables and fields of metadata.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncString"></param>
        public FilterActionContextMetadata(IServiceLog serviceLog,
                                           IServiceMessage serviceMessage,
                                           IServiceDirectory serviceDirectory,
                                           IServiceValidation serviceValidation,
                                           IServiceFuncString serviceFuncString)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
            _serviceFuncString = serviceFuncString;
        }

        /// <summary>
        /// On Action Execution Async.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = _serviceFuncString.Empty;

            try
            {
                if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabaseSchemaIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPMetadataIsBase64Ok(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDevelopmentEnvironmentIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabasesIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabasesImplementedIsntOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDatabasesEngineIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPFormsViewIsOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPArchitectureOk(context, ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeInformations.ErrorFilterActionContextTables), ex.Message);
                throw new Exception(_serviceFuncString.UDPUpper(TextInformations.TheGlobalErrorMessage));
            }

            await next();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeDirectory.CallStartToTheCreateDirectoryProjectOfSolution), _serviceFuncString.Empty);
                _serviceDirectory.UPDCreateDirectoryProjectOfSolution();
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeDirectory.SuccessToTheCreateDirectoryProjectOfSolution), _serviceFuncString.Empty);
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeDirectory.ErrorCreateAllDirectory), ex.Message);
                throw new Exception(_serviceFuncString.UDPUpper(TextInformations.TheGlobalErrorMessage));
            }
        }

        /// <summary>
        /// Has Message.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        private static void HasMessage(ActionExecutingContext context, string message)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails()
            {
                StatusCode = 1,
                Message = message
            });
        }
    }
}