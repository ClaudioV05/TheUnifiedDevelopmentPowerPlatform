using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Metadata.
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
        public string? DatabaseSchema { get; set; }
        
        /// <summary>
        /// Forms.
        /// </summary>
        [DataMember]
        public Forms? Forms { get; set; }

        /// <summary>
        /// Databases.
        /// </summary>
        [DataMember]
        public Databases? Databases { get; set; }

        /// <summary>
        /// DevelopmentEnvironment.
        /// </summary>
        [DataMember]
        public DevelopmentEnvironment? DevEnvironment { get; set; }

        /// <summary>
        /// Tables.
        /// </summary>
        [DataMember]
        public List<Tables>? Tables { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MetadataOwner()
        {
            try
            {
                var Forms = new Forms();
                var Databases = new Databases();
                var DevEnvironment = new DevelopmentEnvironment();
                List<Tables>? Tables = null;
            }
            catch (Exception)
            {
                throw new Exception("Creation with erro in " + this.ToString());
            }
        }
    }
}