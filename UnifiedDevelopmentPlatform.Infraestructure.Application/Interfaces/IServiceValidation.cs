namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceValidation
    {
        #region Validation for FilterActionContextTables.

        /// <summary>
        /// Does Validation for Script Metadata.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool ScriptMetadataIsOk(dynamic context, ref string message);

        /// <summary>
        /// Validateing whether string is Base64.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool MetadataIsBase64Ok(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Development Environment.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DevelopmentEnvironmentIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DatabasesIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Databases Engine.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DatabasesEngineIsOk(dynamic context, ref string message);

        /// <summary>
        /// Does Validation for Forms.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool FormIsOk(dynamic context, ref string message);
        #endregion Validation for FilterActionContextTables.

        #region Validation for Files.

        /// <summary>
        /// Method will check if the file is in use generic.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool IsFileInUseGeneric(FileInfo file);

        /// <summary>
        /// Method will check if the file is in use.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool IsFileInUse(FileInfo file);
        #endregion Validation for Files.

        /// <summary>
        /// Method will check if Base64 is valid.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        bool ValidateBase64(string? text);
    }
}