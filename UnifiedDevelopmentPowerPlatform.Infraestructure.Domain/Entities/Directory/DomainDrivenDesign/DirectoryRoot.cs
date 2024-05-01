using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

[ComplexType]
/// <summary>
/// Standard is the directory root for UNIFIED DEVELOPMENT PLATFORM.
/// </summary>
public abstract class DirectoryRoot
{
    /// <summary>
    /// Path of directory root.
    /// </summary>
    public static string? DirectoryRootPath { get; set; }

    #region Standard Path.

    /// <summary>
    /// Directory root app.
    /// </summary>
    public static string App => DirectoryStandard.App;

    /// <summary>
    /// Directory root backend.
    /// </summary>
    public static string Backend => DirectoryStandard.Backend;

    /// <summary>
    /// Directory root frontend.
    /// </summary>
    public static string Frontend => DirectoryStandard.Frontend;

    /// <summary>
    /// Directory root configuration.
    /// </summary>
    public static string Configuration => $"{DirectoryStandard.App}{DirectoryStandard.Configuration}";

    /// <summary>
    /// Directory root log.
    /// </summary>
    public static string Log => $"{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Log}";

    #endregion Standard Path.

    #region Presentation.

    /// <summary>
    /// Directory root backend presentation.
    /// </summary>
    public static string BackendPresentation => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}";

    /// <summary>
    /// Directory root backend presentation properties.
    /// </summary>
    public static string BackendPresentationProperties => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}";

    /// <summary>
    /// Directory root backend presentation controllers.
    /// </summary>
    public static string BackendPresentationControllers => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}";

    /// <summary>
    /// Directory root backend presentation extensions.
    /// </summary>
    public static string BackendPresentationExtensions => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}";

    /// <summary>
    /// Directory root backend presentation filters.
    /// </summary>
    public static string BackendPresentationFilters => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}";

    /// <summary>
    /// Directory root backend presentation models.
    /// </summary>
    public static string BackendPresentationModels => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}";

    /// <summary>
    /// Directory root backend presentation swagger.
    /// </summary>
    public static string BackendPresentationSwagger => $"{DirectoryStandard.App}{Backend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}";

    /// <summary>
    /// Directory root frontend presentation.
    /// </summary>
    public static string FrontendPresentation => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}";

    /// <summary>
    /// Directory root frontend presentation properties.
    /// </summary>
    public static string FrontendPresentationProperties => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}";

    /// <summary>
    /// Directory root frontend presentation controllers.
    /// </summary>
    public static string FrontendPresentationControllers => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}";

    /// <summary>
    /// Directory root frontend presentation extensions.
    /// </summary>
    public static string FrontendPresentationExtensions => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}";

    /// <summary>
    /// Directory root frontend presentation filters.
    /// </summary>
    public static string FrontendPresentationFilters => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}";

    /// <summary>
    /// Directory root frontend presentation models.
    /// </summary>
    public static string FrontendPresentationModels => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}";

    /// <summary>
    /// Directory root frontend presentation swagger.
    /// </summary>
    public static string FrontendPresentationSwagger => $"{DirectoryStandard.App}{Frontend}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}";

    #endregion Presentation.

    #region Application.

    /// <summary>
    /// Directory root backend application.
    /// </summary>
    public static string BackendApplication => $"{DirectoryStandard.App}{Backend}{DirectoryApplication.Application}";

    /// <summary>
    /// Directory root backend application properties.
    /// </summary>
    public static string BackendApplicationInterfaces => $"{DirectoryStandard.App}{Backend}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}";

    /// <summary>
    /// Directory root backend application services.
    /// </summary>
    public static string BackendApplicationServices => $"{DirectoryStandard.App}{Backend}{DirectoryApplication.Application}{DirectoryApplication.Services}";

    /// <summary>
    /// Directory root frontend application.
    /// </summary>
    public static string FrontendApplication => $"{DirectoryStandard.App}{Frontend}{DirectoryApplication.Application}";

    /// <summary>
    /// Directory root frontend application properties.
    /// </summary>
    public static string FrontendApplicationInterfaces => $"{DirectoryStandard.App}{Frontend}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}";

    /// <summary>
    /// Directory root frontend application services.
    /// </summary>
    public static string FrontendApplicationServices => $"{DirectoryStandard.App}{Frontend}{DirectoryApplication.Application}{DirectoryApplication.Services}";

    #endregion Application.

    #region Domain.

    /// <summary>
    /// Directory root backend domain.
    /// </summary>
    public static string BackendDomain => $"{DirectoryStandard.App}{Backend}{DirectoryDomain.Domain}";

    /// <summary>
    /// Directory root backend domain properties.
    /// </summary>
    public static string BackendDomainInterfaces => $"{DirectoryStandard.App}{Backend}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}";

    /// <summary>
    /// Directory root backend domain entities.
    /// </summary>
    public static string BackendDomainEntities => $"{DirectoryStandard.App}{Backend}{DirectoryDomain.Domain}{DirectoryDomain.Entities}";

    /// <summary>
    /// Directory root Frontend domain.
    /// </summary>
    public static string FrontendDomain => $"{DirectoryStandard.App}{Frontend}{DirectoryDomain.Domain}";

    /// <summary>
    /// Directory root Frontend domain properties.
    /// </summary>
    public static string FrontendDomainInterfaces => $"{DirectoryStandard.App}{Frontend}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}";

    /// <summary>
    /// Directory root Frontend domain entities.
    /// </summary>
    public static string FrontendDomainEntities => $"{DirectoryStandard.App}{Frontend}{DirectoryDomain.Domain}{DirectoryDomain.Entities}";

    #endregion Domain.

    #region Infrastructure.

    /// <summary>
    /// Directory root backend infrastructure.
    /// </summary>
    public static string BackendInfrastructure => $"{DirectoryStandard.App}{Backend}{DirectoryInfrastructure.Infrastructure}";

    /// <summary>
    /// Directory root backend infrastructure cross cutting.
    /// </summary>
    public static string BackendInfrastructureCrossCutting => $"{DirectoryStandard.App}{Backend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}";

    /// <summary>
    /// Directory root backend infrastructure data.
    /// </summary>
    public static string BackendInfrastructureData => $"{DirectoryStandard.App}{Backend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}";

    /// <summary>
    /// Directory root Frontend infrastructure.
    /// </summary>
    public static string FrontendInfrastructure => $"{DirectoryStandard.App}{Frontend}{DirectoryInfrastructure.Infrastructure}";

    /// <summary>
    /// Directory root Frontend infrastructure cross cutting.
    /// </summary>
    public static string FrontendInfrastructureCrossCutting => $"{DirectoryStandard.App}{Frontend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}";

    /// <summary>
    /// Directory root Frontend infrastructure data.
    /// </summary>
    public static string FrontendInfrastructureData => $"{DirectoryStandard.App}{Frontend}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}";

    #endregion Infrastructure.
}