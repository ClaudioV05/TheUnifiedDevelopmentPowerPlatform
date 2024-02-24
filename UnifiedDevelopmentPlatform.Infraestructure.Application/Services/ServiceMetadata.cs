using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceForm _serviceForm;
        private readonly IServiceDatabase _serviceDatabase;
        private readonly IServicePlataform _servicePlataform;
        private readonly IServiceMetadataTable _serviceMetadataTables;
        private readonly IServiceDatabaseEngine _serviceDatabaseEngine;
        private readonly IServiceArchitecturePatterns _serviceArchitecturePatterns;
        private readonly IServiceDevelopmentEnvironment _serviceDevelopmentEnvironment;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceForm"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceMetadataTables"></param>
        /// <param name="serviceDatabaseEngine"></param>
        /// <param name="serviceArchitecturePatterns"></param>
        /// <param name="serviceDevelopmentEnvironment"></param>
        public ServiceMetadata(IServiceForm serviceForm,
                               IServiceDatabase serviceDatabase,
                               IServicePlataform servicePlataform,
                               IServiceMetadataTable serviceMetadataTables,
                               IServiceDatabaseEngine serviceDatabaseEngine,
                               IServiceArchitecturePatterns serviceArchitecturePatterns,
                               IServiceDevelopmentEnvironment serviceDevelopmentEnvironment)
        {
            _serviceForm = serviceForm;
            _serviceDatabase = serviceDatabase;
            _servicePlataform = servicePlataform;
            _serviceMetadataTables = serviceMetadataTables;
            _serviceDatabaseEngine = serviceDatabaseEngine;
            _serviceArchitecturePatterns = serviceArchitecturePatterns;
            _serviceDevelopmentEnvironment = serviceDevelopmentEnvironment;
        }

        public MetadataOwner UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            MetadataOwner metadataOwner = new MetadataOwner();

            List<string> result = _serviceMetadataTables.UDPListWithTablesNameOfMetadata(metadata);

            if (result != null && result.Any())
            {
                _serviceMetadataTables.UDPSaveDatabaseSchemaFromMetadata(metadata);

                metadataOwner?.Tables?.Add(new Tables() { Names = result });
            }

            return metadataOwner;
        }

        public void UDPNotImplemented(MetadataOwner metadata)
        {
            throw new NotImplementedException();
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases() => _serviceDatabase.UDPSelectParametersTheKindsOfDatabases();

        public List<Forms> UDPSelectParametersTheKindsOfForms() => _serviceForm.UDPSelectParametersTheKindsOfForms();

        public List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment() => _serviceDevelopmentEnvironment.UDPSelectParametersTheKindsOfDevelopmentEnviroment();

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine() => _serviceDatabaseEngine.UDPSelectParametersTheKindsOfDatabasesEngine();

        public List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns() => _serviceArchitecturePatterns.UDPSelectParametersTheKindsOfArchitecturePatterns();

        public UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPlatform()
        {
            return new UnifiedDevelopmentParameters()
            {
                BuildPlatformVersion = _servicePlataform.UPDGetOperationalSystemVersion()
            };
        }
    }
}