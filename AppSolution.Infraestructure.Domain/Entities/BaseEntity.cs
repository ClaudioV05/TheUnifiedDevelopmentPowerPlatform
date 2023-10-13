using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity BaseEntity.
    /// </summary>
    [ComplexType]
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}