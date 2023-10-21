using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServicesMetadata : IServicesMetadata
    {
        private readonly IServicesCrypto _servicesCrypto;
        private readonly IServicesFuncStrings _servicesFuncStrings;
        private const int CREATE_TABLE_POSITION = 13;
        private const int CREATE_TABLE_DEFAULT_POSITION = 5;
        private const string WITH_SPACE_POSITION = " ";
        private const string CREATE_TABLE_WITH_SPACE = "create table ";

        public ServicesMetadata(IServicesCrypto servicesCrypto,
                                IServicesFuncStrings servicesFuncStrings)
        {
            _servicesCrypto = servicesCrypto;
            _servicesFuncStrings = servicesFuncStrings;
        }

        public List<string> MetadataAllTablesName(Metadata? metadata)
        {
            string scriptMetadata = string.Empty;
            List<string> tables = null;
            try
            {
                scriptMetadata = _servicesCrypto.DecodeBase64(metadata?.ScriptMetadata);
                scriptMetadata = scriptMetadata.ToLowerInvariant();

                if (string.IsNullOrEmpty(scriptMetadata))
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

            return tables;
        }

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
                metadata = _servicesFuncStrings.RemoveSpecialCaracter(metadata);
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

                table = _servicesFuncStrings.RemoveSpecialCaracter(table);
                table = _servicesFuncStrings.RemoveAllWhiteSpace(table);
                table = table.ToUpperInvariant();
            }
            catch (Exception)
            {
                table = string.Empty;
            }

            tableList?.Add(table);
        }
    }
}