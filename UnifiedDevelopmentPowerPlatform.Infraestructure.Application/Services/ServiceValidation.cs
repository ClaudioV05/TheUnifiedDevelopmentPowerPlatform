using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service validation.
/// </summary>
public class ServiceValidation : IServiceValidation
{
    private readonly IServiceFile _serviceFile;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServicePlataform _servicePlataform;
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service validation.
    /// </summary>
    /// <param name="serviceFile"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="servicePlataform "></param>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceFuncString"></param>
    public ServiceValidation(IServiceFile serviceFile,
                             IServiceMessage serviceMessage,
                             IServicePlataform servicePlataform,
                             IServiceDirectory serviceDirectory,
                             IServiceFuncString serviceFuncString)
    {
        _serviceFile = serviceFile;
        _serviceMessage = serviceMessage;
        _servicePlataform = servicePlataform;
        _serviceDirectory = serviceDirectory;
        _serviceFuncString = serviceFuncString;
    }

    public bool UDPPlatformWindowsIsOk(ref string message)
    {
        message = !_servicePlataform.UDPPPlataformIsWindows() ? _serviceMessage.UDPPGetMessage(TypeValidation.ThePlatformWindowsIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPModelStateIsOk(dynamic context, ref string message)
    {
        message = !context.ModelState.IsValid ? _serviceMessage.UDPPGetMessage(TypeValidation.TheModelStateIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDatabaseSchemaIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = _serviceFuncString.UDPPNullOrEmpty(values?.DatabaseSchema) ? _serviceMessage.UDPPGetMessage(TypeValidation.TheScriptMetadataIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPMetadataIsBase64Ok(dynamic context, ref string message)
    {
        dynamic? values = null;
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out values);
        message = !this.UDPPValidateBase64(values?.DatabaseSchema) ? _serviceMessage.UDPPGetMessage(TypeValidation.TheMetadataIsNotInBase64Ok) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDevelopmentEnvironmentIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.IdDevelopmentEnvironment <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheDevelopmentEnvironmentIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDatabasesIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.IdDatabases <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheDatabasesIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDatabasesImplementedIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.IdDatabases <= 0 || values?.IdDatabases == 1 || values?.IdDatabases == 4 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheDatabasesImplementedIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDatabasesEngineIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.IdDatabasesEngine <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheDatabasesEngineIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPFormsViewIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.IdForms <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheFormsViewIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPArchitectureOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Metadata, out dynamic? values);
        message = values?.Architecture is not 1 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheArchitecturePatternsIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPTablesdataIsOk(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Tablesdata, out dynamic? values);
        message = values?.Tables[0]?.Id <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheTablesdataIsNotOk) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPTablesdataHasFieldsContent(dynamic context, ref string message)
    {
        context.ActionArguments.TryGetValue(ControllerActionArgumentsKey.Tablesdata, out dynamic? values);
        message = values?.Tables[0]?.Fields?.Count <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheTablesdataHasNoFieldsContent) : _serviceFuncString.Empty;
        return _serviceFuncString.UDPPNullOrEmpty(message);
    }

    public bool UDPPDirectoriesOk(dynamic context, ref string message)
    {
        try
        {
            string directoryApp = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.App);
            message = !_serviceDirectory.UDPPDirectoryExists(directoryApp) ? _serviceMessage.UDPPGetMessage(TypeValidation.TheDirectoriesIsNotOk) : _serviceFuncString.Empty;
            return _serviceFuncString.UDPPNullOrEmpty(message);
        }
        catch (Exception)
        {
            _serviceMessage.UDPPGetMessage(TypeValidation.DoNotSpecified);
            return false;
        }
    }

    public bool UDPPFilesOk(dynamic context, ref string message)
    {
        try
        {
            message = _serviceFuncString.UDPPNullOrEmpty(_serviceFile.UDPPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdDatabaseSchema}{FileExtension.Txt}")) ? _serviceMessage.UDPPGetMessage(TypeValidation.TheFilesIsNotOk) : _serviceFuncString.Empty;
            return _serviceFuncString.UDPPNullOrEmpty(message);
        }
        catch (Exception)
        {
            _serviceMessage.UDPPGetMessage(TypeValidation.DoNotSpecified);
            return false;
        }
    }

    public bool UDPPFilesHasContent(dynamic context, ref string message)
    {
        string directoryConfiguration = _serviceFuncString.Empty;
        string fileDatabaseSchema = _serviceFuncString.Empty;

        try
        {
            directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);
            fileDatabaseSchema = $"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabaseSchema}{FileExtension.Txt}";
            message = _serviceFile.UDPPCountLines(fileDatabaseSchema) <= 0 ? _serviceMessage.UDPPGetMessage(TypeValidation.TheFilesIsNotOk) : _serviceFuncString.Empty;
            return _serviceFuncString.UDPPNullOrEmpty(message);
        }
        catch (Exception)
        {
            _serviceMessage.UDPPGetMessage(TypeValidation.DoNotSpecified);
            return false;
        }
    }

    public bool UDPPValidateBase64(string? text)
    {
        int positionIndexBase64 = 0;
        bool validBase64 = true;

        try
        {
            // The quickest test. If the value is null or empty string or is equal to 0 it is not base64
            // Base64 string's length is always divisible by four, i.e. 8, 16, 20 etc. 
            // If it is not you can return false. Quite effective
            // Further, if it meets the above criterias, then test for spaces.
            // If it contains spaces, it is not base64.
            if (_serviceFuncString.UDPPNullOrEmpty(text ?? _serviceFuncString.Empty) ||
            text?.Length == 0 ||
            text?.Length % 4 != 0 ||
            text.Contains(' ') ||
            text.Contains('\t') ||
            text.Contains('\r') ||
            text.Contains('\n'))
            {
                validBase64 = false;
            }
            else
            {
                // 98% of all non base64 values are invalidated by this time.
                positionIndexBase64 = text.Length - 1;

                // If there is padding step back.
                if (text[positionIndexBase64].Equals('='))
                {
                    positionIndexBase64--;
                }

                // If there are two padding chars step back a second time.
                if (text[positionIndexBase64].Equals('='))
                {
                    positionIndexBase64--;
                }

                // Now traverse over characters.
                // You should note that I'm not creating any copy of the existing strings,
                // assuming that they may be quite large.
                for (var i = 0; i <= positionIndexBase64; i++)
                {
                    // If any of the character is not from the allowed list.
                    if (!_serviceFuncString.Base64Chars.Contains(text[i]))
                    {
                        validBase64 = false;
                        break;
                    }
                }
            }
        }
        catch (Exception)
        {
            validBase64 = false;
        }

        return validBase64;
    }
}