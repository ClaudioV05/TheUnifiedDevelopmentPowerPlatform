﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    internal sealed class FilterActionContextController : IAsyncActionFilter
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// Filter action context controller.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncStrings"></param>
        public FilterActionContextController(IServiceLog serviceLog,
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

        /// <summary>
        /// On Action Execution Async.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = _serviceFuncStrings.Empty;

            try
            {
                if (!_serviceValidation.UDPPlatformWindowsIsOk(ref message))
                {
                    _serviceLog.UDPLogReport(message, _serviceFuncStrings.Empty);
                    HasMessage(context, message);
                    return;
                }

                _serviceDirectory.UPDBuildDirectoryStandardOfSolution();

                _serviceLog.UDPLogReport(_serviceMessage.UDPMessage(MessageType.TheInitialMessage), _serviceFuncStrings.Empty);
                _serviceLog.UDPLogReport(_serviceMessage.UDPMessage(MessageType.ThePlatformWindowsIsOk), _serviceFuncStrings.Empty);
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport($"{_serviceMessage.UDPMessage(MessageType.ErrorFilterActionContextController)}", ex.Message);
                throw new Exception(_serviceFuncStrings.UDPUpper(MessageText.TheGlobalErrorMessage));
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
            context.Result = new BadRequestObjectResult(new ErrorDetails() { StatusCode = 1, Message = message });
        }
    }
}