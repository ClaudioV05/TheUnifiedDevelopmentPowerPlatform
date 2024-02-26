using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Symbol;
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
        private readonly IServiceFuncString _serviceFuncString;
        private readonly IServiceMetadataTable _serviceMetadataTable;
        private readonly IServiceMetadataField _serviceMetadataField;
        private readonly IServiceDatabaseEngine _serviceDatabaseEngine;
        private readonly IServiceArchitecturePatterns _serviceArchitecturePatterns;
        private readonly IServiceDevelopmentEnvironment _serviceDevelopmentEnvironment;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceForm"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceFuncString"></param>
        /// <param name="serviceMetadataTable"></param>
        /// <param name="serviceMetadataField"></param>
        /// <param name="serviceDatabaseEngine"></param>
        /// <param name="serviceArchitecturePatterns"></param>
        /// <param name="serviceDevelopmentEnvironment"></param>
        public ServiceMetadata(IServiceForm serviceForm,
                               IServiceDatabase serviceDatabase,
                               IServicePlataform servicePlataform,
                               IServiceFuncString serviceFuncString,
                               IServiceMetadataTable serviceMetadataTable,
                               IServiceMetadataField serviceMetadataField,
                               IServiceDatabaseEngine serviceDatabaseEngine,
                               IServiceArchitecturePatterns serviceArchitecturePatterns,
                               IServiceDevelopmentEnvironment serviceDevelopmentEnvironment)
        {
            _serviceForm = serviceForm;
            _serviceDatabase = serviceDatabase;
            _servicePlataform = servicePlataform;
            _serviceFuncString = serviceFuncString;
            _serviceMetadataTable = serviceMetadataTable;
            _serviceMetadataField = serviceMetadataField;
            _serviceDatabaseEngine = serviceDatabaseEngine;
            _serviceArchitecturePatterns = serviceArchitecturePatterns;
            _serviceDevelopmentEnvironment = serviceDevelopmentEnvironment;
        }

        public MetadataOwner UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            int counter = 0;
            string databaseSchemaDecrypt = _serviceFuncString.Empty;
            List<string> listDatabaseSchemas = new List<string>();
            MetadataOwner metadataOwner = new MetadataOwner();
            Tables tables = new Tables();
            Fields fields = new Fields();

            _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
            databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

            if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
            {
                var results = databaseSchemaDecrypt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                if (results.Any())
                {
                    foreach (string result in results)
                    {
                        if (result.Contains(SqlConfiguration.CreateTableWithSpace) || result.Contains(SqlConfiguration.KeyPrimaryKey) || result.EndsWith(Symbols.Comma))
                        {
                            listDatabaseSchemas.Add(result.ToLowerInvariant().TrimStart());
                        }
                    }

                    for (int i = counter; counter < listDatabaseSchemas.Count; counter++)
                    {
                        if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                        {
                            tables.Name = _serviceMetadataTable.UDPGetTableName(listDatabaseSchemas[counter]);
                            listDatabaseSchemas.Remove(listDatabaseSchemas[counter]);
                        }

                        for (int j = counter; counter < listDatabaseSchemas.Count; counter++)
                        {
                            if (listDatabaseSchemas[counter].EndsWith(Symbols.Comma))
                            {
                                var fieldName = _serviceMetadataField.UDPGetFieldName(listDatabaseSchemas[counter]);
                                var typeFieldName = _serviceMetadataField.UDPGetTypeFieldName(listDatabaseSchemas[counter]);
                                var isnull = _serviceMetadataField.UDPFieldIsNotNull(listDatabaseSchemas[counter]);
                            }
                            else if (listDatabaseSchemas[counter].Contains(SqlConfiguration.KeyPrimaryKey))
                            {
                                continue;
                            }
                            else if (listDatabaseSchemas[counter].Contains(SqlConfiguration.CreateTableWithSpace))
                            {
                                counter--;
                                break;
                            }
                        }
                    }
                }
            }

            return metadataOwner;
        }

        public void UDPNotImplemented(MetadataOwner metadata) => throw new NotImplementedException();

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