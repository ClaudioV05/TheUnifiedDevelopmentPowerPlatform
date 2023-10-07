﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entitie Databases.
    /// </summary>
    [ComplexType]
    public class Databases
    {
        /// <summary>
        /// Enum type for entitie Databases.
        /// </summary>
        public enum Types : ushort
        {
            NotDefined = 0,
            SqlServer = 1,
            MySql = 2,
            Firebird = 3
        }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public Types Type { get; set; } = 0;

        /// <summary>
        /// Id of fields.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public string? Name { get; set; }
    }
}