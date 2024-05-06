﻿namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service json.
/// </summary>
public interface IServiceJson
{
    /// <summary>
    /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPSerializerJson(object obj);
}