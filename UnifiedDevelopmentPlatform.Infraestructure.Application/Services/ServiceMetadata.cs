﻿using UnifiedDevelopmentPlatform.Application.Interfaces;
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

        public List<Tables> UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata)
        {
            int counter = 0;
            int counterOrderTable = 0;
            bool firstPassenger = true;
            string tablesName = _serviceFuncString.Empty;
            string databaseSchemaDecrypt = _serviceFuncString.Empty;
            List<string> listDatabaseSchemas = new List<string>();
            List<Tables> listTables = new List<Tables>();

            try
            {
                _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
                databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

                if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
                {
                    var results = databaseSchemaDecrypt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    if (results.Any())
                    {
                        foreach (string result in results)
                        {
                            if (_serviceFuncString.UDPContains(result, SqlConfiguration.CreateTableWithSpace) || _serviceFuncString.UDPContains(result, SqlConfiguration.KeyPrimaryKey) || _serviceFuncString.UDPStringEnds(result, Symbols.Comma))
                            {
                                listDatabaseSchemas.Add(_serviceFuncString.UDPRemoveWhitespaceOnStart(_serviceFuncString.UDPLower(result)));
                            }
                        }

                        for (int i = counter; counter < listDatabaseSchemas.Count; counter++)
                        {
                            if (_serviceFuncString.UDPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                            {
                                counterOrderTable++;
                                firstPassenger = true;
                                tablesName = _serviceMetadataTable.UDPGetTableName(listDatabaseSchemas[counter]);
                                listDatabaseSchemas.Remove(listDatabaseSchemas[counter]);
                            }

                            for (int j = counter; counter < listDatabaseSchemas.Count; counter++)
                            {
                                if (_serviceFuncString.UDPStringEnds(listDatabaseSchemas[counter], Symbols.Comma))
                                {
                                    if (firstPassenger)
                                    {
                                        listTables.Add(new Tables { Id = counterOrderTable, Name = tablesName });
                                        firstPassenger = false;
                                    }
                                    else if (!firstPassenger)
                                    {
                                        listTables.Where(e => e.Id.Equals(counterOrderTable)).First().Fields.Add(new Fields
                                        {
                                            IdTables = counterOrderTable,
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
            catch (Exception)
            {
                // Insert msg of log hre.
                throw;
            }

            return listTables;
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