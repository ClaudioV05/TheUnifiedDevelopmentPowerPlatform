using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Metadata Tables.
    /// </summary>
    public class ServiceMetadataTables : IServiceMetadataTables
    {
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncStrings _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Metadata Tables.
        /// </summary>
        public ServiceMetadataTables(IServiceCrypto serviceCrypto, IServiceValidation serviceValidation, IServiceFuncStrings serviceFuncStrings)
        {
            _serviceCrypto = serviceCrypto;
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
                    throw new Exception("create class with log for it");
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
            var count = 0;
            var lineCreateTable = _serviceFuncStrings.Empty;
            var tables = new List<string>();

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

            tables = tables?.Distinct().ToList();

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