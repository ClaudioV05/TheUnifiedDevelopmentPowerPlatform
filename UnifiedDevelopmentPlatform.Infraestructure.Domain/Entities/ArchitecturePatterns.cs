﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Architectures.
    /// </summary>
    [ComplexType]
    public class ArchitecturePatterns : IEntity
    {
        /// <summary>
        /// Enum type for entitie architecture patterns.
        /// </summary>
        public enum EnumeratedArchitecturePatterns : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("Domain Driven Design")]
            DDD = 1,
            [Description("Command Query Responsibility Segregation")]
            CQRS = 2
        }

        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumeratedArchitecturePatterns IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}