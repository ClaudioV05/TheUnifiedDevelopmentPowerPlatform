using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory
{
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

        [Description("Directory root json")]
        Json = 5,

        [Description("Directory root log")]
        Log = 6,

        [Description("Directory root xml")]
        Xml = 7,

        #endregion Standard Path.

        #region Presentation.

        [Description("Directory root backend presentation")]
        BackendPresentation = 8,

        [Description("Directory root backend presentation properties")]
        BackendPresentationProperties = 9,

        [Description("Directory root backend presentation controllers")]
        BackendPresentationControllers = 10,

        [Description("Directory root backend presentation extensions")]
        BackendPresentationExtensions = 11,

        [Description("Directory root backend presentation filters")]
        BackendPresentationFilters = 12,

        [Description("Directory root backend presentation models")]
        BackendPresentationModels = 13,

        [Description("Directory root backend presentation swagger")]
        BackendPresentationSwagger = 14,

        [Description("Directory root frontend presentation")]
        FrontendPresentation = 15,

        [Description("Directory root frontend presentation properties")]
        FrontendPresentationProperties = 17,

        [Description("Directory root frontend presentation controllers")]
        FrontendPresentationControllers = 18,

        [Description("Directory root frontend presentation extensions")]
        FrontendPresentationExtensions = 19,

        [Description("Directory root frontend presentation filters")]
        FrontendPresentationFilters = 20,

        [Description("Directory root frontend presentation models")]
        FrontendPresentationModels = 21,

        [Description("Directory root frontend presentation swagger")]
        FrontendPresentationSwagger = 22,

        #endregion Presentation.

        #region Application.

        [Description("Directory root backend application")]
        BackendApplication = 23,

        [Description("Directory root backend application properties")]
        BackendApplicationInterfaces = 24,

        [Description("Directory root backend application services")]
        BackendApplicationServices = 25,

        [Description("Directory root frontend application")]
        FrontendApplication = 26,

        [Description("Directory root frontend application properties")]
        FrontendApplicationInterfaces = 27,

        [Description("Directory root frontend application services")]
        FrontendApplicationServices = 28,

        #endregion Application.

        #region Domain.

        [Description("Directory root backend domain")]
        BackendDomain = 29,

        [Description("Directory root backend domain properties")]
        BackendDomainInterfaces = 30,

        [Description("Directory root backend domain entities")]
        BackendDomainEntities = 31,

        [Description("Directory root Frontend domain")]
        FrontendDomain = 32,

        [Description("Directory root Frontend domain properties")]
        FrontendDomainInterfaces = 33,

        [Description("Directory root Frontend domain entities")]
        FrontendDomainEntities = 34,

        #endregion Domain.

        #region Infrastructure.

        [Description("Directory root backend infrastructure")]
        BackendInfrastructure = 35,

        [Description("Directory root backend infrastructure cross cutting")]
        BackendInfrastructureCrossCutting = 36,

        [Description("Directory root backend infrastructure data")]
        BackendInfrastructureData = 37,

        [Description("Directory root Frontend infrastructure")]
        FrontendInfrastructure = 38,

        [Description("Directory root Frontend infrastructure cross cutting")]
        FrontendInfrastructureCrossCutting = 39,

        [Description("Directory root Frontend infrastructure data")]
        FrontendInfrastructureData = 40

        #endregion Infrastructure.
    }
}