using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Interface IEntity.
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}