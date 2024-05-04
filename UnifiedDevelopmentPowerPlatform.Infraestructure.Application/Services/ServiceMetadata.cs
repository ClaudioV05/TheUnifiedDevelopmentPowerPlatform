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

    public List<Tables> UDPReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase(MetadataOwner metadata)
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
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

            _serviceMetadataTable.UDPSaveDatabaseSchemaFromMetadata(metadata);
            _serviceFormsView.UDPSaveIdentifierToTheFormsViewFromMetadata(metadata);
            _serviceDevelopmentEnvironments.UDPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(metadata);
            _serviceDatabases.UDPSaveIdentifierToTheDatabasesFromMetadata(metadata);
            _serviceDatabasesEngine.UDPSaveIdentifierToTheDatabasesEngineFromMetadata(metadata);
            _serviceArchitecturePatterns.UDPToSaveIdentifierToTheArchitecturePatternsFromMetadata(metadata);

            databaseSchemaDecrypt = _serviceMetadataTable.UDPOpenDatabaseSchemaFromMetadata();

            if (!_serviceFuncString.UDPNullOrEmpty(databaseSchemaDecrypt))
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
                _serviceMetadataTable.UDPLoadTheDatabaseSchema(ref listDatabaseSchemas, _serviceFuncString.UDPParseLine(new[] { $"{MetaCharacterSymbols.CarriageReturn}{MetaCharacterSymbols.NewLine}", MetaCharacterSymbols.CarriageReturn, MetaCharacterSymbols.NewLine }, databaseSchemaDecrypt));

                if (listDatabaseSchemas is not null && listDatabaseSchemas.Any())
                {
                    _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.LoadAllOfTheTablesAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);

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

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase), _serviceFuncString.Empty);
            return listOfTables;
        }
        catch (Exception ex)
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.ErrorReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase), ex.Message);
            throw new Exception(_serviceMessage.UDPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }
    }

    public MetadataOwner UDPReceiveTheTablesdataAndGenerateTheSolution(MetadataOwner metadata)
    {
        try
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.CallStartToTheReceiveTheTablesdataAndGenerateTheSolution), _serviceFuncString.Empty);

            _serviceArchitecturePatterns.UDPGenerateBackendProject(metadata.Tables);
            _serviceArchitecturePatterns.UDPGenerateFrontEndProject(metadata.Tables);

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.SuccessToTheReceiveTheTablesdataAndGenerateTheSolution), _serviceFuncString.Empty);

            return new();
        }
        catch (Exception ex)
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.ErroToTheReceiveTheTablesdataAndGenerateTheSolution), ex.Message);
            throw new Exception(_serviceMessage.UDPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }
    }

    public void UDPNotImplemented(MetadataOwner metadata)
    {
        _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeGlobal.DoNotSpecified), _serviceFuncString.Empty);

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
        return _serviceArchitecturePatterns.UDPToSelectParametersTheKindsOfArchitecturePatterns();
    }

    public UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPowerPlatform()
    {
        _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

        UnifiedDevelopmentParameters unifiedDevelopmentParameters = new UnifiedDevelopmentParameters()
        {
            BuildPlatformVersion = _servicePlataform.UPDGetOperationalSystemVersion(),
            Authors = new List<string>() { "Jesus Cristo", "Claudio Fernandes Rodrigues Ventura", "Claudiomildo Ventura" }
        };

        _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);

        return unifiedDevelopmentParameters;
    }
}