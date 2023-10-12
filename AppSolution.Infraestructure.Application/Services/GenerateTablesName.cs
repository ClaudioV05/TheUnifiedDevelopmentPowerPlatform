using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Services
{
    public class GenerateTablesName : IGenerateTablesName
    {
        const int CREATE_TABLE_POSITION = 14;
        const int CREATE_TABLE_START_POSITION = 0;
        const string WITH_SPACE = " ";
        const string CREATE_TABLE_WITH_SPACE = "create table ";
        private readonly IFuncStrings _funcStrings;
        private readonly ICrypto _crypto;

        public GenerateTablesName(IFuncStrings funcStrings, ICrypto crypto)
        {
            _funcStrings = funcStrings;
            _crypto = crypto;
        }

        public IEnumerable<string> TablesName(GenerateClass generateClass)
        {
            IEnumerable<string> tables = null;
            try
            {
                tables = ReturnTablesName(generateClass.Metadata);
            }
            catch (Exception)
            {
                tables?.Append(string.Empty);
            }

            return tables;
        }

        public IEnumerable<string> ReturnTablesName(string? metadata)
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
                        RetornaNomeDaTabela(lineCreateTable, ref tableList);
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

        private void RetornaNomeDaTabela(string metadata, ref List<string> tableList)
        {
            if (!string.IsNullOrEmpty(metadata) && metadata.IndexOf(CREATE_TABLE_WITH_SPACE) != -1)
            {
                try
                {
                    metadata = _funcStrings.RemoveSpecialCaracter(metadata);

                    #region Find first position of create table.
                    var specifiedPosition = 0;
                    specifiedPosition = metadata.IndexOf(CREATE_TABLE_WITH_SPACE);

                    if (specifiedPosition >= 0)
                        metadata = metadata.Substring(specifiedPosition + CREATE_TABLE_POSITION);
                    #endregion Find first position of create table.

                    #region Find final position after create table.
                    specifiedPosition = 0;
                    specifiedPosition = metadata.IndexOf(WITH_SPACE);

                    if (specifiedPosition >= 0)
                        metadata = metadata.Substring(CREATE_TABLE_START_POSITION, specifiedPosition);
                    #endregion Find final position after create table.

                    metadata = _funcStrings.RemoveAllWhiteSpace(metadata);

                    metadata = metadata.ToUpper();
                }
                catch (Exception)
                {
                    metadata = string.Empty;
                }

                tableList?.Add(!string.IsNullOrEmpty(metadata) ? metadata : string.Empty);
            }
        }
    }
}