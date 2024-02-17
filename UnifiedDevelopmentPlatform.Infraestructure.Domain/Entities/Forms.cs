using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Forms.
    /// </summary>
    [ComplexType]
    public class Forms : IEntity
    {
        /// <summary>
        /// Enum type for entitie Forms.
        /// </summary>
        public enum EnumForm : int
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
        public EnumForm IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}