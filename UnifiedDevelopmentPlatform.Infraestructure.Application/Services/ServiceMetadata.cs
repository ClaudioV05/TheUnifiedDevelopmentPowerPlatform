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

            return result ?? new List<string>();
        }

        public void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            throw new NotImplementedException();
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases() => _serviceDatabase.UDPSelectParametersTheKindsOfDatabases();

        public List<Forms> UDPSelectParametersTheKindsOfForms() => _serviceForm.UDPSelectParametersTheKindsOfForms();

        public List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment() => _serviceDevelopmentEnvironment.UDPSelectParametersTheKindsOfDevelopmentEnviroment();

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine() => _serviceDatabaseEngine.UDPSelectParametersTheKindsOfDatabasesEngine();

        public List<Architectures> UDPSelectParametersTheKindsOfArchitectures() => _serviceArchitecture.UDPSelectParametersTheKindsOfArchitectures();

        public UnifiedDevelopmentPlatformInformation UDPSelectParametersInformationUnifiedDevelopmentPlatform() => new UnifiedDevelopmentPlatformInformation() { };
    }
}