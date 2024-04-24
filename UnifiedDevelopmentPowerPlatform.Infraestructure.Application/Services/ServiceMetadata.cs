using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFormsView _serviceFormsView;
        private readonly IServiceDatabases _serviceDatabases;
        private readonly IServicePlataform _servicePlataform;
        private readonly IServiceFuncString _serviceFuncString;
        private readonly IServiceMetadataTable _serviceMetadataTable;
        private readonly IServiceMetadataField _serviceMetadataField;
        private readonly IServiceDatabaseEngine _serviceDatabasesEngine;
        private readonly IServiceArchitecturePatterns _serviceArchitecturePatterns;
        private readonly IServiceDevelopmentEnvironments _serviceDevelopmentEnvironments;

        /// <summary>
        /// The constructor of service metadata.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceFormsView"></param>
        /// <param name="serviceDatabases"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceFuncString"></param>
        /// <param name="serviceMetadataTable"></param>
        /// <param name="serviceMetadataField"></param>
        /// <param name="serviceDatabasesEngine"></param>
        /// <param name="serviceArchitecturePatterns"></param>
        /// <param name="serviceDevelopmentEnvironments"></param>
        public ServiceMetadata(IServiceLog serviceLog,
                               IServiceMessage serviceMessage,
                               IServiceFormsView serviceFormsView,
                               IServiceDatabases serviceDatabases,
                               IServicePlataform servicePlataform,
                               IServiceFuncString serviceFuncString,
                               IServiceMetadataTable serviceMetadataTable,
                               IServiceMetadataField serviceMetadataField,
                               IServiceDatabaseEngine serviceDatabasesEngine,
                               IServiceArchitecturePatterns serviceArchitecturePatterns,
                               IServiceDevelopmentEnvironments serviceDevelopmentEnvironments)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceFormsView = serviceFormsView;
            _serviceDatabases = serviceDatabases;
            _servicePlataform = servicePlataform;
            _serviceFuncString = serviceFuncString;
            _serviceMetadataTable = serviceMetadataTable;
            _serviceMetadataField = serviceMetadataField;
            _serviceDatabasesEngine = serviceDatabasesEngine;
            _serviceArchitecturePatterns = serviceArchitecturePatterns;
            _serviceDevelopmentEnvironments = serviceDevelopmentEnvironments;
        }

        public List<Tables> UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            int counter = 0;
            int idTable = 0;
            bool newNameTable = true;
            string tablesName = _serviceFuncString.Empty;
            string databaseSchemaDecrypt = _serviceFuncString.Empty;
            List<Tables> listOfTables = new List<Tables>();
            List<string> listDatabaseSchemas = new List<string>();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
                _serviceFormsView.UDPSaveIdentifierToTheFormsViewFromMetadata(metadata);
                _serviceDevelopmentEnvironments.UDPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(metadata);
                _serviceDatabases.UDPSaveIdentifierToTheDatabasesFromMetadata(metadata);
                _serviceDatabasesEngine.UDPSaveIdentifierToTheDatabasesEngineFromMetadata(metadata);
                _serviceArchitecturePatterns.UDPSaveIdentifierToTheArchitecturePatternsFromMetadata(metadata);

                databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

                if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
                    _serviceMetadataTable.UDPLoadTheDatabaseSchema(ref listDatabaseSchemas, _serviceFuncString.UDPParseLine(new[] { $"{MetaCharacterSymbols.CarriageReturn}{MetaCharacterSymbols.NewLine}", MetaCharacterSymbols.CarriageReturn, MetaCharacterSymbols.NewLine }, databaseSchemaDecrypt));

                    if (listDatabaseSchemas is not null && listDatabaseSchemas.Any())
                    {
                        _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.LoadAllOfTheTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                        for (int i = counter; counter < listDatabaseSchemas.Count; counter++)
                        {
                            if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                            {
                                idTable++;
                                newNameTable = true;
                                tablesName = _serviceMetadataTable.UDPGetTableName(listDatabaseSchemas[counter]);
                                listDatabaseSchemas.Remove(listDatabaseSchemas[counter]);
                            }

                            for (int j = counter; counter < listDatabaseSchemas.Count; counter++)
                            {
                                if (_serviceFuncString.UDPStringEnds(listDatabaseSchemas[counter], MetaCharacterSymbols.Comma) &&
                                   !_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.PrimaryKey) &&
                                   !_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.KeyIndex))
                                {
                                    if (newNameTable)
                                    {
                                        _serviceMetadataTable.UDPAddAndSaveTheTable(ref listOfTables, idTable, tablesName);
                                        _serviceMetadataField.UDPLoadTheFieldsAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                        newNameTable = false;
                                    }
                                    else if (!newNameTable)
                                    {
                                        _serviceMetadataField.UDPLoadTheFieldsAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                    }
                                }
                                else if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.PrimaryKey))
                                {
                                    _serviceMetadataField.UDPLoadTheFieldsPrimarykeyAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                    continue;
                                }
                                else if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                                {
                                    counter--;
                                    break;
                                }
                            }
                        }
                    }

                    _serviceDatabases.UDPSaveMetricsOfTheGenerationOfTablesAndFields(listOfTables);
                }
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeDatabases.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), ex.Message);
                throw new Exception(TextInformations.TheGlobalErrorMessage);
            }

            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

            return listOfTables;
        }

        public void UDPNotImplemented(MetadataOwner metadata)
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeInformations.DoNotSpecified), _serviceFuncString.Empty);

            throw new NotImplementedException();
        }

        public List<FormsView> UDPSelectParametersTheKindsOfForms()
        {
            return _serviceFormsView.UDPSelectParametersTheKindsOfFormsView();
        }

        public List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            return _serviceDevelopmentEnvironments.UDPSelectParametersTheKindsOfDevelopmentEnviroment();
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases()
        {
            return _serviceDatabases.UDPSelectParametersTheKindsOfDatabases();
        }

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine()
        {
            return _serviceDatabasesEngine.UDPSelectParametersTheKindsOfDatabasesEngine();
        }

        public List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns()
        {
            return _serviceArchitecturePatterns.UDPSelectParametersTheKindsOfArchitecturePatterns();
        }

        public UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPowerPlatform()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

            UnifiedDevelopmentParameters unifiedDevelopmentParameters = new UnifiedDevelopmentParameters()
            {
                BuildPlatformVersion = _servicePlataform.UPDGetOperationalSystemVersion(),
                Authors = new List<string>() { "Jesus Cristo", "Claudio Fernandes Rodrigues Ventura", "Claudiomildo Ventura" }
            };

            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

            return unifiedDevelopmentParameters;
        }
    }
}