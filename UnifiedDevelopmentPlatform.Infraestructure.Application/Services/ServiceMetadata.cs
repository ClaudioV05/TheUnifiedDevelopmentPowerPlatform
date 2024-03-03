using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceForm _serviceForm;
        private readonly IServiceMessage _serviceMessage;
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
        /// <param name="serviceLog"></param>
        /// <param name="serviceForm"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceFuncString"></param>
        /// <param name="serviceMetadataTable"></param>
        /// <param name="serviceMetadataField"></param>
        /// <param name="serviceDatabaseEngine"></param>
        /// <param name="serviceArchitecturePatterns"></param>
        /// <param name="serviceDevelopmentEnvironment"></param>
        public ServiceMetadata(IServiceLog serviceLog,
                               IServiceForm serviceForm,
                               IServiceMessage serviceMessage,
                               IServiceDatabase serviceDatabase,
                               IServicePlataform servicePlataform,
                               IServiceFuncString serviceFuncString,
                               IServiceMetadataTable serviceMetadataTable,
                               IServiceMetadataField serviceMetadataField,
                               IServiceDatabaseEngine serviceDatabaseEngine,
                               IServiceArchitecturePatterns serviceArchitecturePatterns,
                               IServiceDevelopmentEnvironment serviceDevelopmentEnvironment)
        {
            _serviceLog = serviceLog;
            _serviceForm = serviceForm;
            _serviceMessage = serviceMessage;
            _serviceDatabase = serviceDatabase;
            _servicePlataform = servicePlataform;
            _serviceFuncString = serviceFuncString;
            _serviceMetadataTable = serviceMetadataTable;
            _serviceMetadataField = serviceMetadataField;
            _serviceDatabaseEngine = serviceDatabaseEngine;
            _serviceArchitecturePatterns = serviceArchitecturePatterns;
            _serviceDevelopmentEnvironment = serviceDevelopmentEnvironment;
        }

        public List<Tables> UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            int counter = 0;
            int tableOrder = 0;
            bool newNameTable = true;
            string tablesName = _serviceFuncString.Empty;
            string databaseSchemaDecrypt = _serviceFuncString.Empty;
            List<Tables> listTables = new List<Tables>();
            List<string> listDatabaseSchemas = new List<string>();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                // >> Will includ log in methods below.
                _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
                _serviceForm.UDPSaveIdentifierToTheFormFromMetadata(metadata);
                _serviceDevelopmentEnvironment.UDPSaveIdentifierToTheDevelopmentEnviromentFromMetadata(metadata);

                databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

                if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
                    var results = databaseSchemaDecrypt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    if (results.Any())
                    {
                        foreach (string result in results)
                        {
                            if (_serviceFuncString.UDPContains(result, SqlConfiguration.CreateTableWithSpace) || _serviceFuncString.UDPContains(result, SqlConfiguration.KeyPrimaryKey) || _serviceFuncString.UDPStringEnds(result, MetaCharacterSymbols.Comma))
                            {
                                listDatabaseSchemas.Add(_serviceFuncString.UDPRemoveWhitespaceOnStart(_serviceFuncString.UDPLower(result)));
                            }
                        }

                        _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.LoadAllOfTheTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                        for (int i = counter; counter < listDatabaseSchemas.Count; counter++)
                        {
                            if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                            {
                                tableOrder++;
                                newNameTable = true;
                                tablesName = _serviceMetadataTable.UDPGetTableName(listDatabaseSchemas[counter]);
                                listDatabaseSchemas.Remove(listDatabaseSchemas[counter]);
                            }

                            for (int j = counter; counter < listDatabaseSchemas.Count; counter++)
                            {
                                if (_serviceFuncString.UDPStringEnds(listDatabaseSchemas[counter], MetaCharacterSymbols.Comma))
                                {
                                    if (newNameTable)
                                    {
                                        listTables.Add(new Tables { Id = tableOrder, Name = tablesName });
                                        newNameTable = false;
                                    }
                                    else if (!newNameTable)
                                    {
                                        listTables.Where(element => element.Id.Equals(tableOrder)).First().Fields.Add(new Fields
                                        {
                                            IdTables = tableOrder,
                                            Name = _serviceMetadataField.UDPGetFieldName(listDatabaseSchemas[counter]),
                                            IsNull = _serviceMetadataField.UDPFieldIsNotNull(listDatabaseSchemas[counter]),
                                            TypeField = _serviceMetadataField.UDPGetTypeFieldName(listDatabaseSchemas[counter])
                                        });
                                    }
                                }
                                else if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.KeyPrimaryKey))
                                {
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
                }
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), ex.Message);
                throw;
            }

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
            return listTables;
        }

        public void UDPNotImplemented(MetadataOwner metadata) => throw new NotImplementedException();

        public List<Databases> UDPSelectParametersTheKindsOfDatabases()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDatabases), _serviceFuncString.Empty);
            return _serviceDatabase.UDPSelectParametersTheKindsOfDatabases();
        }

        public List<Forms> UDPSelectParametersTheKindsOfForms()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfForms), _serviceFuncString.Empty);
            return _serviceForm.UDPSelectParametersTheKindsOfForms();
        }

        public List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);
            return _serviceDevelopmentEnvironment.UDPSelectParametersTheKindsOfDevelopmentEnviroment();
        }

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDatabasesEngine), _serviceFuncString.Empty);
            return _serviceDatabaseEngine.UDPSelectParametersTheKindsOfDatabasesEngine();
        }

        public List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns), _serviceFuncString.Empty);
            return _serviceArchitecturePatterns.UDPSelectParametersTheKindsOfArchitecturePatterns();
        }

        public UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPlatform()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform), _serviceFuncString.Empty);
            return new UnifiedDevelopmentParameters() { BuildPlatformVersion = _servicePlataform.UPDGetOperationalSystemVersion() };
        }
    }
}