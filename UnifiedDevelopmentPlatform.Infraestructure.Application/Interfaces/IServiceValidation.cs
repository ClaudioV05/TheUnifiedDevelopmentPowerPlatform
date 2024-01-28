namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Validation.
    /// </summary>
    public interface IServiceValidation
    {
        #region Validation for Filter Action Controller.

        /// <summary>
        /// Does validation if platform is Windows
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPPlatformWindowsIsOk(ref string message);

        #endregion Validation for Filter Action Controller.

        #region Validation for Filters Actions Context Tables and Fields.

        /// <summary>
        /// Does Validation if model state are Ok.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPModelStateIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Database Schema.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabaseSchemaIsOk(dynamic context, ref string message);

        /// <summary>
        /// Validateing whether string is Base64.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPMetadataIsBase64Ok(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Development Environment.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDevelopmentEnvironmentIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabasesIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases Engine.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPDatabasesEngineIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Forms.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPFormIsOk(dynamic context, ref string message);

        #endregion Validation for Filters Actions Context Tables and Fields.

        #region Validation for Files.

        /// <summary>
        /// Method will check if the file is in use generic.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Return true otherwise false.</returns>
        bool IsFileInUseGeneric(FileInfo file);

        /// <summary>
        /// Method will check if the file is in use.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Return true otherwise false.</returns>
        bool IsFileInUse(FileInfo file);
        #endregion Validation for Files.

        /// <summary>
        /// Method will check if Base64 is valid.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPValidateBase64(string? text);
    }
}