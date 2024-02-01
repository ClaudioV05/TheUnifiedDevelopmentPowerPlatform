using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Databases;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Forms.
    /// </summary>
    [ComplexType]
    public class Forms
    {
        /// <summary>
        /// Enum type for entitie Forms.
        /// </summary>
        public enum EnumForm : ushort
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

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumForm IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}