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
        public static string App { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}";

        /// <summary>
        /// Directory root backend.
        /// </summary>
        public static string Backend { get; } = DirectoryStandard.Backend;

        /// <summary>
        /// Directory root frontend.
        /// </summary>
        public static string Frontend { get; } = DirectoryStandard.Frontend;

        /// <summary>
        /// Directory root configuration.
        /// </summary>
        public static string Configuration { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}";

        /// <summary>
        /// Directory root json.
        /// </summary>
        public static string Json { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}";

        /// <summary>
        /// Directory root log.
        /// </summary>
        public static string Log { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Log}";

        /// <summary>
        /// Directory root xml.
        /// </summary>
        public static string Xml { get; } = $"{DirectoryRootPath}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Xml}";

        #endregion Standard Path.

        #region Presentation.

        /// <summary>
        /// Directory root backend presentation.
        /// </summary>
        public static string BackendPresentation { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}";

        /// <summary>
        /// Directory root backend presentation properties.
        /// </summary>
        public static string BackendPresentationProperties { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}";

        /// <summary>
        /// Directory root backend presentation controllers.
        /// </summary>
        public static string BackendPresentationControllers { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}";

        /// <summary>
        /// Directory root backend presentation extensions.
        /// </summary>
        public static string BackendPresentationExtensions { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}";

        /// <summary>
        /// Directory root backend presentation filters.
        /// </summary>
        public static string BackendPresentationFilters { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}";

        /// <summary>
        /// Directory root backend presentation models.
        /// </summary>
        public static string BackendPresentationModels { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}";

        /// <summary>
        /// Directory root backend presentation swagger.
        /// </summary>
        public static string BackendPresentationSwagger { get; } = $"{DirectoryRootPath}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}";

        /// <summary>
        /// Directory root frontend presentation.
        /// </summary>
        public static string FrontendPresentation { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}";

        /// <summary>
        /// Directory root frontend presentation properties.
        /// </summary>
        public static string FrontendPresentationProperties { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}";

        /// <summary>
        /// Directory root frontend presentation controllers.
        /// </summary>
        public static string FrontendPresentationControllers { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}";

        /// <summary>
        /// Directory root frontend presentation extensions.
        /// </summary>
        public static string FrontendPresentationExtensions { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}";

        /// <summary>
        /// Directory root frontend presentation filters.
        /// </summary>
        public static string FrontendPresentationFilters { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}";

        /// <summary>
        /// Directory root frontend presentation models.
        /// </summary>
        public static string FrontendPresentationModels { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}";

        /// <summary>
        /// Directory root frontend presentation swagger.
        /// </summary>
        public static string FrontendPresentationSwagger { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}";

        #endregion Presentation.

        #region Application.

        /// <summary>
        /// Directory root backend application.
        /// </summary>
        public static string BackendApplication { get; } = $"{DirectoryRootPath}{Backend}{DirectoryApplication.Application}";

        /// <summary>
        /// Directory root backend application properties.
        /// </summary>
        public static string BackendApplicationInterfaces { get; } = $"{DirectoryRootPath}{Backend}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}";

        /// <summary>
        /// Directory root backend application services.
        /// </summary>
        public static string BackendApplicationServices { get; } = $"{DirectoryRootPath}{Backend}{DirectoryApplication.Application}{DirectoryApplication.Services}";

        /// <summary>
        /// Directory root frontend application.
        /// </summary>
        public static string FrontendApplication { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryApplication.Application}";

        /// <summary>
        /// Directory root frontend application properties.
        /// </summary>
        public static string FrontendApplicationInterfaces { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}";

        /// <summary>
        /// Directory root frontend application services.
        /// </summary>
        public static string FrontendApplicationServices { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryApplication.Application}{DirectoryApplication.Services}";

        #endregion Application.

        #region Domain.

        /// <summary>
        /// Directory root backend domain.
        /// </summary>
        public static string BackendDomain { get; } = $"{DirectoryRootPath}{Backend}{DirectoryDomain.Domain}";

        /// <summary>
        /// Directory root backend domain properties.
        /// </summary>
        public static string BackendDomainInterfaces { get; } = $"{DirectoryRootPath}{Backend}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}";

        /// <summary>
        /// Directory root backend domain entities.
        /// </summary>
        public static string BackendDomainEntities { get; } = $"{DirectoryRootPath}{Backend}{DirectoryDomain.Domain}{DirectoryDomain.Entities}";

        /// <summary>
        /// Directory root Frontend domain.
        /// </summary>
        public static string FrontendDomain { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryDomain.Domain}";

        /// <summary>
        /// Directory root Frontend domain properties.
        /// </summary>
        public static string FrontendDomainInterfaces { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}";

        /// <summary>
        /// Directory root Frontend domain entities.
        /// </summary>
        public static string FrontendDomainEntities { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryDomain.Domain}{DirectoryDomain.Entities}";

        #endregion Domain.

        #region Infrastructure.

        /// <summary>
        /// Directory root backend infrastructure.
        /// </summary>
        public static string BackendInfrastructure { get; } = $"{DirectoryRootPath}{Backend}{DirectoryInfrastructure.Infrastructure}";

        /// <summary>
        /// Directory root backend infrastructure cross cutting.
        /// </summary>
        public static string BackendInfrastructureCrossCutting { get; } = $"{DirectoryRootPath}{Backend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}";

        /// <summary>
        /// Directory root backend infrastructure data.
        /// </summary>
        public static string BackendInfrastructureData { get; } = $"{DirectoryRootPath}{Backend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}";

        /// <summary>
        /// Directory root Frontend infrastructure.
        /// </summary>
        public static string FrontendInfrastructure { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryInfrastructure.Infrastructure}";

        /// <summary>
        /// Directory root Frontend infrastructure cross cutting.
        /// </summary>
        public static string FrontendInfrastructureCrossCutting { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}";

        /// <summary>
        /// Directory root Frontend infrastructure data.
        /// </summary>
        public static string FrontendInfrastructureData { get; } = $"{DirectoryRootPath}{Frontend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}";

        #endregion Infrastructure.
    }
}