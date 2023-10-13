﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Fields.
    /// </summary>
    [ComplexType]
    public class Fields
    {
        /// <summary>
        /// Id of fields.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public List<string>? Name { get; set; }
    }
}