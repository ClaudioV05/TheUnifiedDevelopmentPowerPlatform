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
        public List<Forms>? Forms { get; set; }

        /// <summary>
        /// Tables.
        /// </summary>
        [DataMember]
        public List<Tables>? Tables { get; set; }

        /// <summary>
        /// Databases.
        /// </summary>
        [DataMember]
        public List<Databases>? Databases { get; set; }

        /// <summary>
        /// Development environment.
        /// </summary>
        [DataMember]
        public List<DevelopmentEnvironment>? DevelopmentEnvironment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MetadataOwner()
        {
            try
            {
                Id = 0;
                Name = string.Empty;
                DatabaseSchema = string.Empty;
                this.Forms = new List<Forms>();
                this.Tables = new List<Tables>();
                this.Databases = new List<Databases>();
                this.DevelopmentEnvironment = new List<DevelopmentEnvironment>();
            }
            catch (Exception)
            {
                throw new Exception("The creation of MetadataOwner is with erro in " + this.ToString());
            }
        }
    }
}