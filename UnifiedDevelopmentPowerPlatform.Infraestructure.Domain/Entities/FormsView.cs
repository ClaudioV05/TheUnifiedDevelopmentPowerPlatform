using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

/// <summary>
/// Entity forms view.
/// </summary>
[ComplexType]
public class FormsView : IEntity
{
    /// <summary>
    /// Enum type for entitie forms view.
    /// </summary>
    [Flags]
    public enum EnumeratedFormsView : int
    {
        [Description("Not Defined")]
        NotDefined = 0,
        [Description("Dotnet Asp Net Mvc")]
        DotnetAspNetMvc = 1,
        [Description("Dotnet Windows Form")]
        DotnetWindowsForm = 2,
        [Description("Delphi Windows Default")]
        DelphiWindowsDefault = 3,
        [Description("Delphi Windows Mdi")]
        DelphiWindowsMdi = 4
    }

    public long Id { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Id Enumeration.
    /// </summary>
    public EnumeratedFormsView IdEnumeration { get; set; } = 0;

    /// <summary>
    /// Name of enumeration.
    /// </summary>
    public string? NameEnumeration { get; set; }
}