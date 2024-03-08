using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPlatform.Application.Services
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
            _serviceFormsView = serviceFormsView;
            _serviceMessage = serviceMessage;
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
            int tableOrder = 0;
            bool newNameTable = true;
            string tablesName = _serviceFuncString.Empty;
            string databaseSchemaDecrypt = _serviceFuncString.Empty;
            List<Tables> listTables = new List<Tables>();
            List<string> listDatabaseSchemas = new List<string>();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
                _serviceFormsView.UDPSaveIdentifierToTheFormsViewFromMetadata(metadata);
                _serviceDevelopmentEnvironments.UDPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(metadata);
                _serviceDatabases.UDPSaveIdentifierToTheDatabasesFromMetadata(metadata);
                _serviceDatabasesEngine.UDPSaveIdentifierToTheDatabasesEngineFromMetadata(metadata);
                _serviceArchitecturePatterns.UDPSaveIdentifierToTheArchitecturePatternsFromMetadata(metadata);

                databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

                if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
                    var results = databaseSchemaDecrypt.Split(new[] { $"{MetaCharacterSymbols.CarriageReturn}{MetaCharacterSymbols.NewLine}", MetaCharacterSymbols.CarriageReturn, MetaCharacterSymbols.NewLine }, StringSplitOptions.None);

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
                                        listTables.Add(new Tables()
                                        {
                                            Id = tableOrder,
                                            Name = tablesName
                                        });

                                        newNameTable = false;
                                    }
                                    else if (!newNameTable)
                                    {
                                        listTables.Where(element => element.Id.Equals(tableOrder)).First().Fields.Add(new Fields()
                                        {
                                            IdTables = tableOrder,
                                            Name = _serviceMetadataField.UDPGetFieldName(listDatabaseSchemas[counter]),
                                            IsNull = _serviceMetadataField.UDPFieldIsNotNull(listDatabaseSchemas[counter]),
                                            IsPrimaryKey = false, // Create method here.
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
                throw new Exception(MessageText.TheGlobalErrorMessage);
            }

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
            return listTables;
        }

        public void UDPNotImplemented(MetadataOwner metadata)
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.NoHasMessageSpecifield), _serviceFuncString.Empty);

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

        public UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPlatform()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform), _serviceFuncString.Empty);

            UnifiedDevelopmentParameters unifiedDevelopmentParameters = new UnifiedDevelopmentParameters()
            {
                BuildPlatformVersion = _servicePlataform.UPDGetOperationalSystemVersion()
            };

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform), _serviceFuncString.Empty);

            return unifiedDevelopmentParameters;
        }
    }
}