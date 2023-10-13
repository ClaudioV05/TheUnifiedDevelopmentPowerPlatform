using AppSolution.Infraestructure.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Forms.
    /// </summary>
    [ComplexType]
    public class Forms : BaseEntity
    {
        /// <summary>
        /// Id of Types.
        /// </summary>
        public FormTypes Type { get; set; } = 0;
    }
}