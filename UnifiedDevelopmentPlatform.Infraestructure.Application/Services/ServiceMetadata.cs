﻿using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceForm _serviceForm;
        private readonly IServiceDatabase _serviceDatabase;
        private readonly IServiceDatabaseEngine _serviceDatabaseEngine;
        private readonly IServiceMetadataTable _serviceMetadataTables;
        private readonly IServiceDevelopmentEnvironment _serviceDevelopmentEnvironment;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceForm"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="serviceMetadataTables"></param>
        /// <param name="serviceDevelopmentEnvironment"></param>
        public ServiceMetadata(IServiceForm serviceForm, IServiceDatabase serviceDatabase, IServiceDatabaseEngine serviceDatabaseEngine, IServiceMetadataTable serviceMetadataTables, IServiceDevelopmentEnvironment serviceDevelopmentEnvironment)
        {
            _serviceForm = serviceForm;
            _serviceDatabase = serviceDatabase;
            _serviceDatabaseEngine = serviceDatabaseEngine;
            _serviceMetadataTables = serviceMetadataTables;
            _serviceDevelopmentEnvironment = serviceDevelopmentEnvironment;
        }

        public List<string> UDPReceiveAndSaveAllTableOfSchemaDatabase(MetadataOwner? metadata)
        {
            return _serviceMetadataTables.UDPMetadataAllTablesName(metadata);
        }

        public void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner? metadata)
        {
            throw new NotImplementedException();
        }

        public List<Databases> UDPObtainTheListOfDatabases()
        {
            return _serviceDatabase.UDPObtainTheListOfDatabases();
        }

        public List<Forms> UDPObtainTheListOfForms()
        {
            return _serviceForm.UDPObtainTheListOfForms();
        }

        public List<DevelopmentEnvironment> UDPObtainTheListOfDevelopmentEnviroment()
        {
            return _serviceDevelopmentEnvironment.UDPObtainTheListOfDevelopmentEnviroment();
        }

        public List<DatabasesEngine> UDPObtainTheListOfDatabasesEngine()
        {
            return _serviceDatabaseEngine.UDPObtainTheListOfDatabasesEngine();
        }
    }
}