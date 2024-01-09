﻿using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for Metadata Fields.
    /// </summary>
    public interface IServiceMetadataFields
    {
        /// <summary>
        /// Return all tables name and all fields.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names and fields of table.</returns>
        List<string> UDPMetadataTableAndAllFields(MetadataOwner? metadata);
    }
}