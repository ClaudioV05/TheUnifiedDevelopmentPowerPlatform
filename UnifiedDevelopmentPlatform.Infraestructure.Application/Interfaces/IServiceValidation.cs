namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceValidation
    {
        #region Validation for Filter Action Controller.

        /// <summary>
        /// Does validation if platform is Windows
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool PlatformWindowsIsOk(ref string message);

        #endregion Validation for Filter Action Controller.

        #region Validation for Filters Actions Context Tables and Fields.

        /// <summary>
        /// Does Validation if model state are Ok.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool ModelStateIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Script Metadata.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool ScriptMetadataIsOk(dynamic context, ref string message);

        /// <summary>
        /// Validateing whether string is Base64.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool MetadataIsBase64Ok(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Development Environment.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool DevelopmentEnvironmentIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool DatabasesIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases Engine.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool DatabasesEngineIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Forms.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns>True or false.</returns>
        bool FormIsOk(dynamic context, ref string message);

        #endregion Validation for Filters Actions Context Tables and Fields.

        #region Validation for Files.

        /// <summary>
        /// Method will check if the file is in use generic.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True or false.</returns>
        bool IsFileInUseGeneric(FileInfo file);

        /// <summary>
        /// Method will check if the file is in use.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True or false.</returns>
        bool IsFileInUse(FileInfo file);
        #endregion Validation for Files.

        /// <summary>
        /// Method will check if Base64 is valid.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>True or false.</returns>
        bool ValidateBase64(string? text);
    }
}