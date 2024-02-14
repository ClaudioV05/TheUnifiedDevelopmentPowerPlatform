using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;

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
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Metadata Tables.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceLinq"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncStrings"></param>
        public ServiceMetadataTable(IServiceLog serviceLog,
                                    IServiceFile serviceFile,
                                    IServiceLinq serviceLinq, 
                                    IServiceCrypto serviceCrypto, 
                                    IServiceMessage serviceMessage,
                                    IServiceDirectory serviceDirectory,
                                    IServiceValidation serviceValidation, 
                                    IServiceFuncString serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceLinq = serviceLinq;
            _serviceCrypto = serviceCrypto;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public List<string> UDPListWithTablesNameOfMetadata(MetadataOwner metadata)
        {
            List<string> listWithTablesName = new List<string>();
            string scriptMetadata = _serviceFuncStrings.Empty;

            try
            {
                if (!_serviceValidation.UDPValidateBase64(metadata?.DatabaseSchema))
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.InvalidBase64));
                }
                else
                {
                    scriptMetadata = _serviceCrypto.UPDDecodeBase64(metadata?.DatabaseSchema);

                    if (!_serviceFuncStrings.UDPNullOrEmpty(scriptMetadata))
                    {
                        scriptMetadata = _serviceFuncStrings.UDPLower(scriptMetadata);
                        listWithTablesName = UtilsReturnMetadataAllTablesName(scriptMetadata);
                    }
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
            string scriptMetadata = _serviceFuncStrings.Empty;
            string directoryConfiguration = _serviceFuncStrings.Empty;

            scriptMetadata = _serviceCrypto.UPDDecodeBase64(metadata?.DatabaseSchema);

            if (!_serviceFuncStrings.UDPNullOrEmpty(scriptMetadata))
            {
                scriptMetadata = _serviceFuncStrings.UDPLower(scriptMetadata);
                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.DatabaseSchema}{FileExtension.Txt}", scriptMetadata);

            }
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
            string lineCreateTable = _serviceFuncStrings.Empty;
            List<string> tables = new List<string>();

            for (int i = 0; i < metadata?.Length; i++)
            {
                lineCreateTable += metadata[i];

                if (lineCreateTable.Contains(SqlConfiguration.CreateTableWithSpace))
                {
                    count++;

                    if (count > SqlConfiguration.CreateTableDefaultPosition && lineCreateTable.EndsWith(_serviceFuncStrings.StringWhiteSpace))
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
        private void UtilsFindTableIntoList(string? metadata, ref List<string>? tableList)
        {
            int count = 0;
            int indexCreateTable = 0;
            string table = _serviceFuncStrings.Empty;

            try
            {
                metadata = _serviceFuncStrings.UDPRemoveSpecialCaracter(metadata ?? string.Empty);
                indexCreateTable = metadata.IndexOf(SqlConfiguration.CreateTableWithSpace);

                for (int i = (indexCreateTable + SqlConfiguration.CreateTablePosition); i < metadata?.Length; i++)
                {
                    count++;
                    table += metadata[i];

                    if (count > SqlConfiguration.CreateTableDefaultPosition && table.EndsWith(_serviceFuncStrings.StringWhiteSpace))
                    {
                        break;
                    }
                }

                table = _serviceFuncStrings.UDPRemoveSpecialCaracter(table);
                table = _serviceFuncStrings.UDPRemoveAllWhiteSpace(table);
                table = _serviceFuncStrings.UDPUpper(table);
            }
            catch (Exception)
            {
                table = _serviceFuncStrings.Empty;
            }

            tableList?.Add(table);
        }

        #endregion Private Methods.
    }
}