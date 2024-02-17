﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases Engine.
    /// </summary>
    [ComplexType]
    public class DatabasesEngine : IEntity
    {
        /// <summary>
        /// Enum type for entitie Databases Engine.
        /// </summary>
        public enum EnumDatabasesEngine : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("EntityFrameworkCore")]
            EntityFrameworkCore = 1,
            [Description("Dapper")]
            Dapper = 2,
            [Description("SqlClient")]
            SqlClient = 3
        }

        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumDatabasesEngine IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}