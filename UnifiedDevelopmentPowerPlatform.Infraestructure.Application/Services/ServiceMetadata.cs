using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public List<Tables> UDPPReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase(MetadataOwner metadata)
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
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

            _serviceMetadataTable.UDPPSaveDatabaseSchemaFromMetadata(metadata);
            _serviceFormsView.UDPPSaveIdentifierToTheFormsViewFromMetadata(metadata);
            _serviceDevelopmentEnvironments.UDPPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(metadata);
            _serviceDatabases.UDPPSaveIdentifierToTheDatabasesFromMetadata(metadata);
            _serviceDatabasesEngine.UDPPSaveIdentifierToTheDatabasesEngineFromMetadata(metadata);
            _serviceArchitecturePatterns.UDPPToSaveIdentifierToTheArchitecturePatternsFromMetadata(metadata);

            databaseSchemaDecrypt = _serviceMetadataTable.UDPPOpenDatabaseSchemaFromMetadata();

            if (!_serviceFuncString.UDPPNullOrEmpty(databaseSchemaDecrypt))
            {
                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
                _serviceMetadataTable.UDPPLoadTheDatabaseSchema(ref listDatabaseSchemas, _serviceFuncString.UDPPParseLine(new[] { $"{MetaCharacterSymbols.CarriageReturn}{MetaCharacterSymbols.NewLine}", MetaCharacterSymbols.CarriageReturn, MetaCharacterSymbols.NewLine }, databaseSchemaDecrypt));

                if (listDatabaseSchemas is not null && listDatabaseSchemas.Any())
                {
                    _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.LoadAllOfTheTablesAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

                    for (int i = counter; counter < listDatabaseSchemas.Count; counter++)
                    {
                        if (_serviceFuncString.UDPPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                        {
                            idTable++;
                            newNameTable = true;
                            tablesName = _serviceMetadataTable.UDPPGetTableName(listDatabaseSchemas[counter]);
                            listDatabaseSchemas.Remove(listDatabaseSchemas[counter]);
                        }

                        for (int j = counter; counter < listDatabaseSchemas.Count; counter++)
                        {
                            if (_serviceFuncString.UDPPStringEnds(listDatabaseSchemas[counter], MetaCharacterSymbols.Comma) &&
                               !_serviceFuncString.UDPPContains(listDatabaseSchemas[counter], SqlConfiguration.PrimaryKey) &&
                               !_serviceFuncString.UDPPContains(listDatabaseSchemas[counter], SqlConfiguration.KeyIndex))
                            {
                                if (newNameTable)
                                {
                                    _serviceMetadataTable.UDPPAddAndSaveTheTable(ref listOfTables, idTable, tablesName);
                                    _serviceMetadataField.UDPPLoadTheFieldsAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                    newNameTable = false;
                                }
                                else if (!newNameTable)
                                {
                                    _serviceMetadataField.UDPPLoadTheFieldsAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                }
                            }
                            else if (_serviceFuncString.UDPPContains(listDatabaseSchemas[counter], SqlConfiguration.PrimaryKey))
                            {
                                _serviceMetadataField.UDPPLoadTheFieldsPrimarykeyAtTable(ref listOfTables, idTable, listDatabaseSchemas[counter]);
                                continue;
                            }
                            else if (_serviceFuncString.UDPPContains(listDatabaseSchemas[counter], SqlConfiguration.CreateTableWithSpace))
                            {
                                counter--;
                                break;
                            }
                        }
                    }
                }
                _serviceDatabases.UDPPSaveMetricsOfTheGenerationOfTablesAndFields(listOfTables);
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
            return listOfTables;
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeDatabases.ErrorReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase), ex.Message);
            throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }
    }

    public MetadataOwner UDPPReceiveTheTablesdataAndGenerateTheSolution(MetadataOwner metadata)
    {
        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.CallStartToTheReceiveTheTablesdataAndGenerateTheSolution), _serviceFuncString.Empty);

            _serviceArchitecturePatterns.UDPPGeneratesBackendSolution(metadata.Tables);
            _serviceArchitecturePatterns.UDPPGeneratesFrontendSolution(metadata.Tables);

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.SuccessToTheReceiveTheTablesdataAndGenerateTheSolution), _serviceFuncString.Empty);

            return new();
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.ErroToTheReceiveTheTablesdataAndGenerateTheSolution), ex.Message);
            throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }
    }

    public void UDPPNotImplemented(MetadataOwner metadata)
    {
        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.DoNotSpecified), _serviceFuncString.Empty);

        throw new NotImplementedException();
    }

    public List<FormsView> UDPPSelectParametersTheKindsOfForms()
    {
        return _serviceFormsView.UDPPSelectParametersTheKindsOfFormsView();
    }

    public List<DevelopmentEnvironments> UDPPSelectParametersTheKindsOfDevelopmentEnviroment()
    {
        return _serviceDevelopmentEnvironments.UDPPSelectParametersTheKindsOfDevelopmentEnviroment();
    }

    public List<Databases> UDPPSelectParametersTheKindsOfDatabases()
    {
        return _serviceDatabases.UDPPSelectParametersTheKindsOfDatabases();
    }

    public List<DatabasesEngine> UDPPSelectParametersTheKindsOfDatabasesEngine()
    {
        return _serviceDatabasesEngine.UDPPSelectParametersTheKindsOfDatabasesEngine();
    }

    public List<ArchitecturePatterns> UDPPSelectParametersTheKindsOfArchitecturePatterns()
    {
        return _serviceArchitecturePatterns.UDPPToSelectParametersTheKindsOfArchitecturePatterns();
    }

    public UnifiedDevelopmentParameters UDPPSelectParametersInformationUnifiedDevelopmentPowerPlatform()
    {
        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

        UnifiedDevelopmentParameters unifiedDevelopmentParameters = new UnifiedDevelopmentParameters()
        {
            BuildPlatformVersion = _servicePlataform.UDPPGetOperationalSystemVersion(),
            Authors = new List<string>() { "Jesus Cristo", "Claudio Fernandes Rodrigues Ventura", "Claudiomildo Ventura" }
        };

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

        return unifiedDevelopmentParameters;
    }
}