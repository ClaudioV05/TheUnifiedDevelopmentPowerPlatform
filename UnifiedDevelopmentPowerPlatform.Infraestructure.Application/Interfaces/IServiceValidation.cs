namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service validation.
/// </summary>
public interface IServiceValidation
{
    /// <summary>
    /// It does validation if platform is Windows.
    /// </summary>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPlatformWindowsIsOk(ref string message);

    /// <summary>
    /// It does validation if model state are Ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPModelStateIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the database schema.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDatabaseSchemaIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation if string is Base64.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPMetadataIsBase64Ok(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the development environment.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDevelopmentEnvironmentIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDatabasesIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases implemented ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDatabasesImplementedIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases engine.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDatabasesEngineIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the forms view.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPFormsViewIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the architecture.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPArchitectureOk(dynamic context, ref string message);

    /// <summary>
    /// Method will check if Base64 is valid.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPValidateBase64(string? text);

    /// <summary>
    /// It does validation to the tables data.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPTablesdataIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the tables data has fields content.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPTablesdataHasFieldsContent(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the all directories are ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDirectoriesOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the files are ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPFilesOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the files has content.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPFilesHasContent(dynamic context, ref string message);
}