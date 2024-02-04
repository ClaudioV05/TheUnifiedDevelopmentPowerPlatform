using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
{
    [ComplexType]
    /// <summary>
    /// Standard is the directory root for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryRoot
    {
        /// <summary>
        /// Path of directory root.
        /// </summary>
        public static string? DirectoryRootPath { get; set; }

        #region Standard Path.

        /// <summary>
        /// Directory root app.
        /// </summary>
        public static string DirectoryRootApp { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}";

        /// <summary>
        /// Directory root backend.
        /// </summary>
        public static string DirectoryRootBackend { get; } = DirectoryStandard.Backend;

        /// <summary>
        /// Directory root frontend.
        /// </summary>
        public static string DirectoryRootFrontend { get; } = DirectoryStandard.Frontend;

        /// <summary>
        /// Directory root configuration.
        /// </summary>
        public static string DirectoryRootConfiguration { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}";

        /// <summary>
        /// Directory root json.
        /// </summary>
        public static string DirectoryRootJson { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}";

        /// <summary>
        /// Directory root log.
        /// </summary>
        public static string DirectoryRootLog { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Log}";


        /// <summary>
        /// Directory root xml.
        /// </summary>
        public static string DirectoryRootXml { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Xml}";

      
        #endregion Standard Path.

        #region Presentation.
        #endregion Presentation.

        #region Application.
        #endregion Application.

        #region Domain.
        #endregion Domain.

        #region Infrastructure.
        #endregion Infrastructure.
    }
}