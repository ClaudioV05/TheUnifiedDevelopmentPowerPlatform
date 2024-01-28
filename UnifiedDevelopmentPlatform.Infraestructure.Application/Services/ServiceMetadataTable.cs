using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
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
        private readonly IServiceLinq _serviceLinq;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Metadata Tables.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceLinq"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncStrings"></param>
        public ServiceMetadataTable(IServiceLog serviceLog, IServiceLinq serviceLinq, IServiceCrypto serviceCrypto, IServiceMessage serviceMessage, IServiceValidation serviceValidation, IServiceFuncString serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceLinq = serviceLinq;
            _serviceCrypto = serviceCrypto;
            _serviceMessage = serviceMessage;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public List<string> UDPMetadataAllTablesName(MetadataOwner? metadata)
        {
            string scriptMetadata = _serviceFuncStrings.Empty;
            List<string> tables = new List<string>();
            try
            {
                if (!_serviceValidation.UDPValidateBase64(metadata?.ScriptMetadata))
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.InvalidBase64));
                    throw new Exception();
                }

                scriptMetadata = _serviceCrypto.UPDDecodeBase64(metadata?.ScriptMetadata);
                scriptMetadata = _serviceFuncStrings.UDPLower(scriptMetadata);

                if (_serviceFuncStrings.UDPNullOrEmpty(scriptMetadata))
                {
                    tables?.Append(_serviceFuncStrings.Empty);
                }
                else
                {
                    tables = ReturnMetadataAllTablesName(scriptMetadata);
                }
            }
            catch (Exception)
            {
                tables?.Append(_serviceFuncStrings.Empty);
            }

            return tables ?? new List<string>();
        }

        #region Private Methods.
        private List<string> ReturnMetadataAllTablesName(string? metadata)
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

                    if (count > SqlConfiguration.CreateTableDefaultPosition && lineCreateTable.EndsWith(_serviceFuncStrings.WhiteSpace))
                    {
                        FindTableList(lineCreateTable, ref tables);
                        count = 0;
                        lineCreateTable = string.Empty;
                    }
                }
            }

            tables = _serviceLinq.UDPDistinct(tables);

            return tables ?? new List<string>();
        }

        private void FindTableList(string? metadata, ref List<string>? tableList)
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

                    if (count > SqlConfiguration.CreateTableDefaultPosition && table.EndsWith(_serviceFuncStrings.WhiteSpace))
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