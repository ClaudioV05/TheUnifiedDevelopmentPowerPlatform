using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the directory.
    /// </summary>
    public enum TypeDirectory : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Directory root is empty")] DirectoryRootIsEmpty = 1,
        [Description("Error to create all directory")] ErrorCreateAllDirectory = 2,
        [Description("Build of all directory standard of solution")] BuildDirectoryStandardOfSolution = 3,
        [Description("Call start to the create directory project of solution")] CallStartToTheCreateDirectoryProjectOfSolution = 4,
        [Description("Success to the create directory project of solution")] SuccessToTheCreateDirectoryProjectOfSolution = 5
    }
}