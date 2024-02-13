using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentPlatformInformation;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceForm _serviceForm;
        private readonly IServiceDatabase _serviceDatabase;
        private readonly IServiceArchitecture _serviceArchitecture;
        private readonly IServiceMetadataTable _serviceMetadataTables;
        private readonly IServiceDatabaseEngine _serviceDatabaseEngine;
        private readonly IServiceDevelopmentEnvironment _serviceDevelopmentEnvironment;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceForm"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="serviceArchitecture"></param>
        /// <param name="serviceMetadataTables"></param>
        /// <param name="serviceDatabaseEngine"></param>
        /// <param name="serviceDevelopmentEnvironment"></param>
        public ServiceMetadata(IServiceForm serviceForm,
                               IServiceDatabase serviceDatabase,
                               IServiceArchitecture serviceArchitecture,
                               IServiceMetadataTable serviceMetadataTables,
                               IServiceDatabaseEngine serviceDatabaseEngine,
                               IServiceDevelopmentEnvironment serviceDevelopmentEnvironment)
        {
            _serviceForm = serviceForm;
            _serviceArchitecture = serviceArchitecture;
            _serviceDatabase = serviceDatabase;
            _serviceDatabaseEngine = serviceDatabaseEngine;
            _serviceMetadataTables = serviceMetadataTables;
            _serviceDevelopmentEnvironment = serviceDevelopmentEnvironment;
        }

        public List<string> UDPReceiveAndSaveAllTableOfSchemaDatabase(MetadataOwner metadata)
        {
            List<string> result = _serviceMetadataTables.UDPListWithTablesNameOfMetadata(metadata);

            if (result != null && result.Any())
            {
                _serviceMetadataTables.UDPSaveDatabaseSchemaFromMetadata(metadata);
            }

            return result;
        }

        public void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
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

        public List<Architectures> UDPObtainTheListOfArchitectures()
        {
            return _serviceArchitecture.UDPObtainTheListOfArchitectures();
        }

        public UnifiedDevelopmentPlatformInformation UDPObtainInformationUnifiedDevelopmentPlatform()
        {
            return new UnifiedDevelopmentPlatformInformation() { };
        }
    }
}