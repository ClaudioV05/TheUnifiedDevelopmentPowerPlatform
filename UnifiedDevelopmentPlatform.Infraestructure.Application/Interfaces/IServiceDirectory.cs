namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceDirectory
    {
        #region App.
        /// <summary>
        /// Create directory App.
        /// </summary>
        /// <returns></returns>
        bool CreateAppDirectory();

        /// <summary>
        /// Read directory App.
        /// </summary>
        /// <returns></returns>
        string? ReadAppDirectory();
        #endregion App.

        #region Config.
        /// <summary>
        /// Create directory Config.
        /// </summary>
        /// <returns></returns>
        bool CreateConfigDirectory();

        /// <summary>
        /// Read directory Config.
        /// </summary>
        /// <returns></returns>
        string? ReadConfigDirectory();
        #endregion Config.

        #region Presentation.
        /// <summary>
        /// Create directory Presentation.
        /// </summary>
        /// <returns></returns>
        bool CreatePresentationDirectory();

        /// <summary>
        /// Read directory Presentation.
        /// </summary>
        /// <returns></returns>
        string? ReadPresentationDirectory();
        #endregion Presentation.
    }
}