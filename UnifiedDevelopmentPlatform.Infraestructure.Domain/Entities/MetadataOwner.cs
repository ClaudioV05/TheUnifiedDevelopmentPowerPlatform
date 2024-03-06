using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Metadata owner.
    /// </summary>
    [ComplexType]
    public sealed class MetadataOwner : IEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Database schema.
        /// </summary>
        [DataMember]
        public string DatabaseSchema { get; set; }

        /// <summary>
        /// The architecture patterns.
        /// </summary>
        [DataMember]
        public List<ArchitecturePatterns>? ArchitecturePatterns { get; set; }

        /// <summary>
        /// The Databases.
        /// </summary>
        [DataMember]
        public List<Databases>? Databases { get; set; }

        /// <summary>
        /// The databases engine.
        /// </summary>
        [DataMember]
        public List<DatabasesEngine>? DatabasesEngine { get; set; }

        /// <summary>
        /// The development environments.
        /// </summary>
        [DataMember]
        public List<DevelopmentEnvironments>? DevelopmentEnvironments { get; set; }

        /// <summary>
        /// The forms view.
        /// </summary>
        [DataMember]
        public List<FormsView>? FormsView { get; set; }

        /// <summary>
        /// The tables.
        /// </summary>
        [DataMember]
        public List<Tables> Tables { get; set; }

        /// <summary>
        /// The constructor of Metadata owner.
        /// </summary>
        /// <param name=""></param>
        /// <exception cref="Exception"></exception>
        public MetadataOwner()
        {
            try
            {
                Id = 0;
                Name = string.Empty;
                DatabaseSchema = string.Empty;
            }
            catch (Exception)
            {
                throw new Exception("The creation of " + typeof(MetadataOwner).Name + " is with erro.");
            }
        }
    }
}