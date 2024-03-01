using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Tables.
    /// </summary>
    [ComplexType]
    public class Tables : IEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Fields.
        /// </summary>
        [DataMember]
        public List<Fields> Fields { get; set; }

        public Tables()
        {
            try
            {
                Id = 0;
                Name = string.Empty;
                this.Fields = new List<Fields>();
            }
            catch (Exception)
            {
                throw new Exception("The creation of " + typeof(Tables).Name + " is with erro.");
            }
        }
    }
}