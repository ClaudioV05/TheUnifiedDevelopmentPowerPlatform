using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

[ComplexType]
/// <summary>
/// Unified development platform with information about the parameters.
/// </summary>
public class UnifiedDevelopmentParameters
{
    /// <summary>
    /// Title.
    /// </summary>
    public string Title => "UNIFIED DEVELOPMENT PLATFORM";

    /// <summary>
    /// Name.
    /// </summary>
    public string Name => "UnifiedDevelopmentPowerPlatformParameters";

    /// <summary>
    /// Abreviation.
    /// </summary>
    public string Abreviation => "UDP";

    /// <summary>
    /// Version.
    /// </summary>
    public string Version => "v1";

    /// <summary>
    /// Information.
    /// </summary>
    public string Information => "This program generates 'MVC' standard class files for the 'Delphi', 'Lazarus' and '.NET' Development Ide, from a text file containing the metadata of one or more tables.\n" +
               "It is based on GeraClasseDelphi version 6.0. The difference is that it generates the files according to the 'MVC' project pattern,\n" +
               "generating the Dao, Model, Controller and View files in corresponding folders.Views, Normal and Mdi style forms are created.\n\n" +

               "Important:\n\n" +

               "01. Font formatting obeys Delphis automatic formatter with default values, except:\n" +
               "Right margin = 135\n" +
               "Indent case contents = True\n\n" +

               "02. For Views, there is a problem with accentuation in the display of dialog messages in Lazarus\n" +
               "Adjust the Encoding of the code editor.\n" +
               "Right click in code editor > File Settings > Encoding > select UTF-8 with BOM\n\n" +

               "03. Version for Visual Studio in date 30.07.2022\n\n" +

               "04. New version generate class Web in 12.10.2022\n\n" +

               "05. New version Unified development platform in 12.10.2023";

    public List<string>? Authors { get; set; }

    /// <summary>
    /// Build platform version.
    /// </summary>
    public string? BuildPlatformVersion { get; set; }
}