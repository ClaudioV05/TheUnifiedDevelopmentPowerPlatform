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
    /// <returns></returns>
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
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPModelStateIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the database schema.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDatabaseSchemaIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation if string is Base64.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPMetadataIsBase64Ok(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the development environment.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDevelopmentEnvironmentIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDatabasesIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases implemented ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDatabasesImplementedIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the databases engine.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDatabasesEngineIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the forms view.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPFormsViewIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the architecture.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPArchitectureOk(dynamic context, ref string message);

    /// <summary>
    /// Method will check if Base64 is valid.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPValidateBase64(string? text);

    /// <summary>
    /// It does validation to the tables data.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPTablesdataIsOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the tables data has fields content.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPTablesdataHasFieldsContent(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the all directories are ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPDirectoriesOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the files are ok.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPFilesOk(dynamic context, ref string message);

    /// <summary>
    /// It does validation to the files has content.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPFilesHasContent(dynamic context, ref string message);
}