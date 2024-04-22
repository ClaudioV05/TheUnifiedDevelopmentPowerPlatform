﻿using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata Tables.
    /// </summary>
    public class ServiceMetadataTable : IServiceMetadataTable
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceLinq _serviceLinq;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service metadata tables.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceLinq"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceMetadataTable(IServiceLog serviceLog,
                                    IServiceFile serviceFile,
                                    IServiceLinq serviceLinq,
                                    IServiceCrypto serviceCrypto,
                                    IServiceMessage serviceMessage,
                                    IServiceDirectory serviceDirectory,
                                    IServiceFuncString serviceFuncString)
        {
            _serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceLinq = serviceLinq;
            _serviceCrypto = serviceCrypto;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceFuncString = serviceFuncString;
        }

        public List<string> UDPListWithTablesNameOfMetadata(MetadataOwner metadata)
        {
            List<string> listWithTablesName = new List<string>();
            string scriptMetadata = _serviceFuncString.Empty;

            try
            {
                scriptMetadata = _serviceCrypto.UPDDecodeBase64(metadata?.DatabaseSchema);

                if (!_serviceFuncString.UDPNullOrEmpty(scriptMetadata))
                {
                    scriptMetadata = _serviceFuncString.UDPLower(scriptMetadata);
                    listWithTablesName = UtilsReturnMetadataAllTablesName(scriptMetadata);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return listWithTablesName;
        }

        public void UDPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string databaseSchema = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (!_serviceFuncString.UDPNullOrEmpty(metadata.DatabaseSchema))
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
            string directoryConfiguration = _serviceFuncString.Empty;

            _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

            if (_serviceFile.UDPFileExists($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabaseSchema}{FileExtension.Txt}"))
            {
                data = _serviceFile.UDPReadAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabaseSchema}{FileExtension.Txt}");
                data = _serviceCrypto.UPDDecrypt(data);
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheOpenDatabaseSchemaFromMetadata), _serviceFuncString.Empty);
            }

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
            listTables.Add(new Tables()
            {
                Id = idTable,
                Name = text
            });
        }

        #region Private Methods.

        /// <summary>
        /// Return the metadata all tables name.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        private List<string> UtilsReturnMetadataAllTablesName(string? metadata)
        {
            long count = 0;
            string lineCreateTable = _serviceFuncString.Empty;
            List<string> tables = new List<string>();

            for (int i = 0; i < metadata?.Length; i++)
            {
                lineCreateTable += metadata[i];

                if (lineCreateTable.Contains(SqlConfiguration.CreateTableWithSpace))
                {
                    count++;

                    if (count > SqlConfiguration.CreateTableDefaultPosition && lineCreateTable.EndsWith(MetaCharacterSymbols.WhiteSpace))
                    {
                        UtilsFindTableIntoList(lineCreateTable, ref tables);
                        count = 0;
                        lineCreateTable = string.Empty;
                    }
                }
            }

            tables = _serviceLinq.UDPDistinct(tables);

            return tables ?? new List<string>();
        }

        /// <summary>
        /// find table into list.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="tableList"></param>
        private void UtilsFindTableIntoList(string metadata, ref List<string> tableList)
        {
            int count = 0;
            int indexCreateTable = 0;
            string table = _serviceFuncString.Empty;

            try
            {
                metadata = _serviceFuncString.UDPRemoveSpecialCaracter(metadata);
                indexCreateTable = metadata.IndexOf(SqlConfiguration.CreateTableWithSpace);

                for (int i = (indexCreateTable + SqlConfiguration.CreateTablePosition); i < metadata?.Length; i++)
                {
                    count++;
                    table += metadata[i];

                    if (count > SqlConfiguration.CreateTableDefaultPosition && table.EndsWith(MetaCharacterSymbols.WhiteSpace))
                    {
                        break;
                    }
                }

                table = _serviceFuncString.UDPRemoveSpecialCaracter(table);
                table = _serviceFuncString.UDPRemoveAllWhiteSpace(table);
                table = _serviceFuncString.UDPUpper(table);
            }
            catch (Exception)
            {
                table = _serviceFuncString.Empty;
            }

            tableList?.Add(table);
        }

        #endregion Private Methods.
    }
}