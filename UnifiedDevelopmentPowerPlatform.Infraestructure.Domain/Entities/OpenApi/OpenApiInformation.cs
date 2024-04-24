﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi
{
    [ComplexType]
    /// <summary>
    /// Documentation about the informations of API.
    /// </summary>
    public static class OpenApiInformation
    {
        /// <summary>
        /// The version.
        /// </summary>
        public static string Version => "v1";

        /// <summary>
        /// The title.
        /// </summary>
        public static string Title => "UNIFIED DEVELOPMENT POWER PLATFORM";

        /// <summary>
        /// The description.
        /// </summary>
        public static string Description => "The solution generator to C#";

        /// <summary>
        /// The terms of service.
        /// </summary>
        public static string TermsOfService => "https://claudiomildo.net/terms";
    }
}