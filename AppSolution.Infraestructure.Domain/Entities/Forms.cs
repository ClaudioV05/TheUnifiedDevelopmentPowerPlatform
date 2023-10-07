using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entitie Forms.
    /// </summary>
    [ComplexType]
    public class Forms
    {
        /// <summary>
        /// Enum type for entitie Forms.
        /// </summary>
        public enum Types : ushort
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
        public Types Type { get; set; } = 0;
    }
}