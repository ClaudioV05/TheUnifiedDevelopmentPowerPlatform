﻿using System.Text.Json;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Application.Services;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

/// <summary>
/// ErrorDetails.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Status code.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Stack trace.
    /// </summary>
    public string? StackTrace { get; set; }

    /// <summary>
    /// Source.
    /// </summary>
    public string? Source { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}