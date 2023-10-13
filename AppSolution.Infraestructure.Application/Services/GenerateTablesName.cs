using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Services
{
    public class GenerateTablesName : IGenerateTablesName
    {
        const int CREATE_TABLE_POSITION = 14;
        const int CREATE_TABLE_START_POSITION = 0;
        const string WITH_SPACE_POSITION = " ";
        const string CREATE_TABLE_WITH_SPACE = "create table ";
        private readonly IFuncStrings _funcStrings;
        private readonly ICrypto _crypto;

        public GenerateTablesName(IFuncStrings funcStrings, ICrypto crypto)
        {
            _funcStrings = funcStrings;
            _crypto = crypto;
        }

        public IEnumerable<string> TablesName(GenerateClass? generateClass)
        {
            string metadata = string.Empty;
            IEnumerable<string> tables = null;
            try
            {
                metadata = _crypto.DecodeBase64(generateClass?.Metadata);

                metadata = metadata.ToLowerInvariant();

                if (string.IsNullOrEmpty(metadata))
                {
                    tables?.Append(string.Empty);
                }
                else
                {
                    tables = ReturnTablesName(metadata);
                }
            }
            catch (Exception)
            {
                tables?.Append(string.Empty);
            }

            return tables;
        }

        private IEnumerable<string> ReturnTablesName(string? metadata)
        {
            var counter = 0;
            var lineCreateTable = string.Empty;
            var tableList = new List<string>();

            if (!string.IsNullOrEmpty(metadata))
            {
                for (int i = 0; i < metadata?.Length; i++)
                {
                    lineCreateTable += metadata[i];

                    if (!string.IsNullOrEmpty(lineCreateTable) && lineCreateTable.Contains(CREATE_TABLE_WITH_SPACE))
                        counter++;

                    if (counter >= 20)
                    {
                        ReturnTablesName(lineCreateTable, ref tableList);
                        counter = 0;
                        lineCreateTable = string.Empty;
                    }
                }
                tableList = tableList?.Distinct().ToList();
            }
            else
            {
                tableList?.Append(string.Empty);
            }

            return tableList;
        }

        private void ReturnTablesName(string? metadata, ref List<string>? tableList)
        {
            if (!string.IsNullOrEmpty(metadata) && metadata.IndexOf(CREATE_TABLE_WITH_SPACE) != -1)
            {
                try
                {
                    metadata = _funcStrings.RemoveSpecialCaracter(metadata);

                    #region Find first position of create table.
                    var positionExactOfCreateTable = 0;
                    positionExactOfCreateTable = metadata.IndexOf(CREATE_TABLE_WITH_SPACE);

                    for (int i = 0; i < metadata?.Length; i++)
                    {
                        var aux =+ metadata[i];
                    }
                    

                    metadata = metadata.Substring(positionExactOfCreateTable + CREATE_TABLE_POSITION);
                    #endregion Find first position of create table.

                    #region Find final position after create table.
                    positionExactOfCreateTable = 0;
                    positionExactOfCreateTable = metadata.IndexOf(WITH_SPACE_POSITION);

                    metadata = metadata.Substring(CREATE_TABLE_START_POSITION, positionExactOfCreateTable);
                    #endregion Find final position after create table.

                    metadata = _funcStrings.RemoveAllWhiteSpace(metadata);

                    metadata = metadata.ToUpper();
                }
                catch (Exception)
                {
                    metadata = string.Empty;
                }

                tableList?.Add(metadata ?? string.Empty);
            }
        }
    }
}