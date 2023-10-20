﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Metadata.
    /// </summary>
    [ComplexType]
    public sealed class Metadata
    {
        /// <summary>
        /// Script of Metadata.
        /// </summary>
        [DataMember]
        public string? ScriptMetadata { get; set; }
        
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
        public DevEnvironment? DevEnvironment { get; set; }

        /// <summary>
        /// Fields.
        /// </summary>
        [DataMember]
        public ICollection<Fields>? Fields { get; set; }

        /// <summary>
        /// Tables.
        /// </summary>
        [DataMember]
        public ICollection<Tables>? Tables { get; set; }

        public Metadata()
        {
            try
            {
                var Forms = new Forms();
                var Databases = new Databases();
                var DevEnvironment = new DevEnvironment();
                List<Fields>? Fields = null;
                List<Tables>? Tables = null;
            }
            catch (Exception)
            {
                throw new Exception("Creation with erro in " + this.ToString());
            }
        }
    }
}