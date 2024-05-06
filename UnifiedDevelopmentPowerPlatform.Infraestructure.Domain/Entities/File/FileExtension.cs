using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;

/// <summary>
/// File with extension for the application.
/// </summary>
[ComplexType]
public static class FileExtension
{
    /// <summary>
    /// Text document file - TXT.
    /// </summary>
    public static string Txt => ".txt";

    /// <summary>
    /// Extensible markup language file - XML.
    /// </summary>
    public static string Xml => ".xml";

    /// <summary>
    /// JavaScript object notation file - JSON.
    /// </summary>
    public static string Json => ".json";

    /// <summary>
    /// C Sharp file - CS.
    /// </summary>
    public static string Cs => ".cs";

    /// <summary>
    /// C Sharp Project file - Cs Project.
    /// </summary>
    public static string CSharpProj => ".csproj";

    /// <summary>
    /// Sln file - Solution.
    /// </summary>
    public static string Sln => ".sln";

    /// <summary>
    /// HyperText Markup Language - HTML.
    /// </summary>
    public static string Html => ".html";

    /// <summary>
    /// JavaScript.
    /// </summary>
    public static string JavaScript => ".js";

    /// <summary>
    /// TypeScript.
    /// </summary>
    public static string TypeScript => ".ts";

    /// <summary>
    /// Cascading Style Sheets - Css.
    /// </summary>
    public static string Css => ".css";
}