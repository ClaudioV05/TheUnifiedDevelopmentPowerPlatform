using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory
{
    /// <summary>
    /// Directory root type build.
    /// </summary>
    public enum DirectoryRootTypeBuild : int
    {
        [Description("Standard of solution")]
        StandardOfSolution = 0,

        [Description("Project of solution")]
        ProjectOfSolution = 1
    }
}