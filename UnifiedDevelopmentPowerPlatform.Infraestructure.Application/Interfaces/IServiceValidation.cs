namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service validation.
    /// </summary>
    public interface IServiceValidation
    {
        /// <summary>
        /// Does validation if platform is Windows.
        /// </summary>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPPlatformWindowsIsOk(ref string message);

        /// <summary>
        /// Does Validation if model state are Ok.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPModelStateIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the database schema.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabaseSchemaIsOk(dynamic context, ref string message);

        /// <summary>
        /// Validateing whether string is Base64.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPMetadataIsBase64Ok(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the development environment.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDevelopmentEnvironmentIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the Databases.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabasesIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the databases implemented ok.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabasesImplementedIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the Databases Engine.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabasesEngineIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the forms view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPFormsViewIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the architecture.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
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
        /// <returns>Return true otherwise false.</returns>
        bool UDPValidateBase64(string? text);

        /// <summary>
        /// Does Validation to the tables of metadata.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPTablesMetadataIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation to the directory are.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDirectoryAreOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation tor the tiles are ok.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return true otherwise false.</returns>
        bool UDPFilesAreOk(dynamic context, ref string message);
    }
}