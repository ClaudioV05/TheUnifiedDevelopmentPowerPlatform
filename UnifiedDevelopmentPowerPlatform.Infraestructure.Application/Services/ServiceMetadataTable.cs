using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
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

        public void UDPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string databaseSchema = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (!_serviceFuncString.UDPNullOrEmpty(metadata?.DatabaseSchema))
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheSaveDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

                databaseSchema = _serviceCrypto.UPDDecodeBase64(metadata?.DatabaseSchema);
                databaseSchema = _serviceFuncString.UDPLower(databaseSchema);
                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(databaseSchema);
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabaseSchema}{FileExtension.Txt}", data);

                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheSaveDatabaseSchemaFromMetadata), _serviceFuncString.Empty);
            }
        }

        public string UDPOpenDatabaseSchemaFromMetadata()
        {
            string data = _serviceFuncString.Empty;

            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

            data = _serviceFile.UDPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdDatabaseSchema}{FileExtension.Txt}");
            data = _serviceCrypto.UPDDecrypt(data);

            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

            return data;
        }

        public string UDPGetTableName(string text)
        {
            string tableName = _serviceFuncString.Empty;

            tableName = _serviceFuncString.UDPLower(_serviceFuncString.UDPRemoveWhitespace(text));
            tableName = _serviceFuncString.UDPReplace(tableName, SqlConfiguration.CreateTableWithSpace, _serviceFuncString.Empty);
            tableName = _serviceFuncString.UDPReplace(tableName, MetaCharacterSymbols.LeftParenthese, _serviceFuncString.Empty);
            tableName = _serviceFuncString.UDPReplace(tableName, SqlConfiguration.DatabaseObject, _serviceFuncString.Empty);
            tableName = _serviceFuncString.UDPRemoveSpecialCaracter(tableName);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveWhitespace(tableName));
        }

        public void UDPLoadTheDatabaseSchema(ref List<string> listDatabaseSchema, string[]? databaseSchema)
        {
            if (databaseSchema is not null && databaseSchema.Any())
            {
                foreach (string result in databaseSchema)
                {
                    if (_serviceFuncString.UDPContains(result, SqlConfiguration.CreateTableWithSpace) || _serviceFuncString.UDPContains(result, SqlConfiguration.PrimaryKey) || _serviceFuncString.UDPStringEnds(result, MetaCharacterSymbols.Comma))
                    {
                        listDatabaseSchema.Add(_serviceFuncString.UDPRemoveWhitespaceAtStart(_serviceFuncString.UDPLower(result)));
                    }
                }
            }
        }

        public void UDPAddAndSaveTheTable(ref List<Tables> listTables, int idTable, string text)
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
}