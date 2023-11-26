using System.ComponentModel.DataAnnotations.Schema;

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
            NotDefined = 0,
            DotnetAspNetMvc = 1,
            DotnetWindowsForm = 2,
            DelphiWindowsDefault = 3,
            DelphiWindowsMdi = 4
        }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public EnumForm Type { get; set; } = 0;
    }
}