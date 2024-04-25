using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters
{
    /// <summary>
    /// Filter action context to tables data.
    /// </summary>
    internal sealed class FilterActionContextTablesdata<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// Filter action context to tables data.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncString"></param>
        public FilterActionContextTablesdata(IServiceLog serviceLog,
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
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeGlobal.CallStartToTheFilterActionContextTablesdata), _serviceFuncString.Empty);

                if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
                {
                    _serviceLog.UDPRegisterLog(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPTablesMetadataIsOk(context, ref message))
                {
                    _serviceLog.UDPRegisterLog(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPDirectoryAreOk(context, ref message))
                {
                    _serviceLog.UDPRegisterLog(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                if (!_serviceValidation.UDPFilesAreOk(context, ref message))
                {
                    _serviceLog.UDPRegisterLog(message, _serviceFuncString.Empty);
                    HasMessage(context, message);
                    return;
                }

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeGlobal.SuccessToTheFilterActionContextTablesdata), _serviceFuncString.Empty);
            }
            catch (Exception ex)
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeGlobal.ErrorFilterActionContextTablesdata), ex.Message);
                throw new Exception(_serviceMessage.UDPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
            }

            await next();
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