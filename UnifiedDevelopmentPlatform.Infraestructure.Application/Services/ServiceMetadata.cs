using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceMetadata : IServiceMetadata
    {

        struct MyStruct
        {
            public MyStruct()
            {
            }

            public int MyProperty { get; set; } = 10;
        }

        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncStrings _serviceFuncStrings;

        private const int CREATE_TABLE_POSITION = 13;
        private const int CREATE_TABLE_DEFAULT_POSITION = 5;
        private const string WITH_SPACE_POSITION = " ";
        private const string CREATE_TABLE_WITH_SPACE = "create table ";

        public ServiceMetadata(IServiceCrypto serviceCrypto,
                               IServiceValidation serviceValidation,
                               IServiceFuncStrings serviceFuncStrings)
        {
            _serviceCrypto = serviceCrypto;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public List<string> MetadataAllTablesName(Metadata? metadata)
        {
            string scriptMetadata = string.Empty;
            List<string> tables = new List<string>();
            try
            {
                if (!_serviceValidation.ValidateBase64(metadata?.ScriptMetadata))
                    throw new Exception("create class with log for it");

                scriptMetadata = _serviceCrypto.DecodeBase64(metadata?.ScriptMetadata);
                scriptMetadata = scriptMetadata.ToLowerInvariant();

                if (_serviceFuncStrings.NullOrEmpty(scriptMetadata))
                {
                    tables?.Append(string.Empty);
                }
                else
                {
                    tables = ReturnMetadataAllTablesName(scriptMetadata);
                }
            }
            catch (Exception)
            {
                tables?.Append(string.Empty);
            }

            return tables ?? new List<string>();
        }

        public List<string> MetadataTableAndAllFields(Metadata? metadata)
        {
            throw new NotImplementedException();
        }

        #region Private Methods.
        private List<string> ReturnMetadataAllTablesName(string? metadata)
        {
            var count = 0;
            var lineCreateTable = string.Empty;
            var tables = new List<string>();

            for (int i = 0; i < metadata?.Length; i++)
            {
                lineCreateTable += metadata[i];

                if (lineCreateTable.Contains(CREATE_TABLE_WITH_SPACE))
                {
                    count++;

                    if (count > CREATE_TABLE_DEFAULT_POSITION && lineCreateTable.EndsWith(WITH_SPACE_POSITION))
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
            string table = string.Empty;
            try
            {
                metadata = _serviceFuncStrings.RemoveSpecialCaracter(metadata ?? string.Empty);
                indexCreateTable = metadata.IndexOf(CREATE_TABLE_WITH_SPACE);

                for (int i = (indexCreateTable + CREATE_TABLE_POSITION); i < metadata?.Length; i++)
                {
                    count++;
                    table += metadata[i];

                    if (count > CREATE_TABLE_DEFAULT_POSITION && table.EndsWith(WITH_SPACE_POSITION))
                    {
                        break;
                    }
                }

                table = _serviceFuncStrings.RemoveSpecialCaracter(table);
                table = _serviceFuncStrings.RemoveAllWhiteSpace(table);
                table = table.ToUpperInvariant();
            }
            catch (Exception)
            {
                table = string.Empty;
            }

            tableList?.Add(table);
        }
        #endregion Private Methods.
    }
}