namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces
{
    /// <summary>
    /// Interface IEntity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// IEntity identifier.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// IEntity name.
        /// </summary>
        string Name { get; set; }
    }
}