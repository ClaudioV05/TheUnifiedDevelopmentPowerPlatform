using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

/// <summary>
/// Directory root type.
/// </summary>
public enum DirectoryRootType : int
{
    [Description("No has directory root")]
    NoDirectoryRoot = 0,

    #region Standard Path.

    [Description("Directory root app")]
    App = 1,

    [Description("Directory root backend")]
    Backend = 2,

    [Description("Directory root frontend")]
    Frontend = 3,

    [Description("Directory root configuration")]
    Configuration = 4,

    [Description("Directory root log")]
    Log = 5,

    #endregion Standard Path.

    #region Presentation.

    [Description("Directory root backend presentation")]
    BackendPresentation = 6,

    [Description("Directory root backend presentation properties")]
    BackendPresentationProperties = 7,

    [Description("Directory root backend presentation controllers")]
    BackendPresentationControllers = 8,

    [Description("Directory root backend presentation extensions")]
    BackendPresentationExtensions = 9,

    [Description("Directory root backend presentation filters")]
    BackendPresentationFilters = 10,

    [Description("Directory root backend presentation models")]
    BackendPresentationModels = 11,

    [Description("Directory root backend presentation swagger")]
    BackendPresentationSwagger = 12,

    [Description("Directory root frontend presentation")]
    FrontendPresentation = 13,

    [Description("Directory root frontend presentation properties")]
    FrontendPresentationProperties = 14,

    [Description("Directory root frontend presentation controllers")]
    FrontendPresentationControllers = 15,

    [Description("Directory root frontend presentation extensions")]
    FrontendPresentationExtensions = 16,

    [Description("Directory root frontend presentation filters")]
    FrontendPresentationFilters = 17,

    [Description("Directory root frontend presentation models")]
    FrontendPresentationModels = 18,

    [Description("Directory root frontend presentation swagger")]
    FrontendPresentationSwagger = 19,

    #endregion Presentation.

    #region Application.

    [Description("Directory root backend application")]
    BackendApplication = 20,

    [Description("Directory root backend application properties")]
    BackendApplicationInterfaces = 21,

    [Description("Directory root backend application services")]
    BackendApplicationServices = 22,

    [Description("Directory root frontend application")]
    FrontendApplication = 23,

    [Description("Directory root frontend application properties")]
    FrontendApplicationInterfaces = 24,

    [Description("Directory root frontend application services")]
    FrontendApplicationServices = 25,

    #endregion Application.

    #region Domain.

    [Description("Directory root backend domain")]
    BackendDomain = 26,

    [Description("Directory root backend domain properties")]
    BackendDomainInterfaces = 27,

    [Description("Directory root backend domain entities")]
    BackendDomainEntities = 28,

    [Description("Directory root Frontend domain")]
    FrontendDomain = 29,

    [Description("Directory root Frontend domain properties")]
    FrontendDomainInterfaces = 30,

    [Description("Directory root Frontend domain entities")]
    FrontendDomainEntities = 31,

    #endregion Domain.

    #region Infrastructure.

    [Description("Directory root backend infrastructure")]
    BackendInfrastructure = 32,

    [Description("Directory root backend infrastructure cross cutting")]
    BackendInfrastructureCrossCutting = 33,

    [Description("Directory root backend infrastructure data")]
    BackendInfrastructureData = 34,

    [Description("Directory root Frontend infrastructure")]
    FrontendInfrastructure = 35,

    [Description("Directory root Frontend infrastructure cross cutting")]
    FrontendInfrastructureCrossCutting = 36,

    [Description("Directory root Frontend infrastructure data")]
    FrontendInfrastructureData = 37

    #endregion Infrastructure.
}