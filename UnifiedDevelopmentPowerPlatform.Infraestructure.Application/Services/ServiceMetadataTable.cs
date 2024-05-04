using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service metadata table.
/// </summary>
public class ServiceMetadataTable : IServiceMetadataTable
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceFile _serviceFile;
    private readonly IServiceCrypto _serviceCrypto;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service metadata table.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceFile"></param>
    /// <param name="serviceCrypto"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceFuncString"></param>
    public ServiceMetadataTable(IServiceLog serviceLog,
                                IServiceFile serviceFile,
                                IServiceCrypto serviceCrypto,
                                IServiceMessage serviceMessage,
                                IServiceDirectory serviceDirectory,
                                IServiceFuncString serviceFuncString)
    {
        _serviceLog = serviceLog;
        _serviceFile = serviceFile;
        _serviceCrypto = serviceCrypto;
        _serviceMessage = serviceMessage;
        _serviceDirectory = serviceDirectory;
        _serviceFuncString = serviceFuncString;
    }

    public void UDPPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata)
    {
        string data = _serviceFuncString.Empty;
        string databaseSchema = _serviceFuncString.Empty;
        string directoryConfiguration = _serviceFuncString.Empty;

        if (!_serviceFuncString.UDPPNullOrEmpty(metadata?.DatabaseSchema))
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheSaveDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

            databaseSchema = _serviceCrypto.UDPPDecodeFromBase64(metadata?.DatabaseSchema);
            databaseSchema = _serviceFuncString.UDPPLower(databaseSchema);
            directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);
            data = _serviceCrypto.UDPPEncryptData(databaseSchema);
            _serviceFile.UDPPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabaseSchema}{FileExtension.Txt}", data);

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheSaveDatabaseSchemaFromMetadata), _serviceFuncString.Empty);
        }
    }

    public string UDPPOpenDatabaseSchemaFromMetadata()
    {
        string data = _serviceFuncString.Empty;

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

        data = _serviceFile.UDPPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdDatabaseSchema}{FileExtension.Txt}");
        data = _serviceCrypto.UDPPDecryptData(data);

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

        return data;
    }

    public string UDPPGetTableName(string text)
    {
        string data = _serviceFuncString.Empty;

        data = _serviceFuncString.UDPPLower(_serviceFuncString.UDPPRemoveWhitespace(text));
        data = _serviceFuncString.UDPPReplace(data, SqlConfiguration.CreateTableWithSpace, _serviceFuncString.Empty);
        data = _serviceFuncString.UDPPReplace(data, MetaCharacterSymbols.LeftParenthese, _serviceFuncString.Empty);
        data = _serviceFuncString.UDPPReplace(data, SqlConfiguration.DatabaseObject, _serviceFuncString.Empty);
        data = _serviceFuncString.UDPPRemoveSpecialCaracter(data);
        return _serviceFuncString.UDPPUpper(_serviceFuncString.UDPPRemoveWhitespace(data));
    }

    public void UDPPLoadTheDatabaseSchema(ref List<string> listDatabaseSchema, string[]? databaseSchema)
    {
        if (databaseSchema is not null && databaseSchema.Any())
        {
            foreach (string result in databaseSchema)
            {
                if (_serviceFuncString.UDPPContains(result, SqlConfiguration.CreateTableWithSpace) || _serviceFuncString.UDPPContains(result, SqlConfiguration.PrimaryKey) || _serviceFuncString.UDPPStringEnds(result, MetaCharacterSymbols.Comma))
                {
                    listDatabaseSchema.Add(_serviceFuncString.UDPPRemoveWhitespaceAtStart(_serviceFuncString.UDPPLower(result)));
                }
            }
        }
    }

    public void UDPPAddAndSaveTheTable(ref List<Tables> listTables, int idTable, string text)
    {
        Tables tables = new Tables()
        {
            Id = idTable,
            Name = text,
            AutoCreate = true,
        };

        listTables.Add(tables);
    }
}