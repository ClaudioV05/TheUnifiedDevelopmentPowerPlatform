﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
{
    [ComplexType]
    /// <summary>
    /// Presentation is the directory for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryPresentation
    {
        /// <summary>
        /// Presentation.
        /// </summary>
        public static string Presentation { get; } = "\\1-Presentation";

        /// <summary>
        /// Properties.
        /// </summary>
        public static string Properties { get; } = "\\Properties";

        /// <summary>
        /// Controllers.
        /// </summary>
        public static string Controllers { get; } = "\\Controllers";

        /// <summary>
        /// Extensions.
        /// </summary>
        public static string Extensions { get; } = "\\Extensions";

        /// <summary>
        /// Filters.
        /// </summary>
        public static string Filters { get; } = "\\Filters";

        /// <summary>
        /// Models.
        /// </summary>
        public static string Models { get; } = "\\Models";

        /// <summary>
        /// Swagger.
        /// </summary>
        public static string Swagger { get; } = "\\Swagger";
    }
}