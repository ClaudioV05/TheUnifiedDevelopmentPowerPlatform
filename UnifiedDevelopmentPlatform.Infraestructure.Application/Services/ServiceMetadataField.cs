using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// ServiceMetadataField.
    /// </summary>
    public class ServiceMetadataField : IServiceMetadataField
    {
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of ServiceMetadataField.
        /// </summary>
        /// <param name="serviceFuncString"></param>
        public ServiceMetadataField(IServiceFuncString serviceFuncString)
        {
            _serviceFuncString = serviceFuncString;
        }

        public string UDPGetTheFieldName(string text)
        {
            int firstPositionWithSpace = 0;
            string field = _serviceFuncString.Empty;

            field = _serviceFuncString.UDPLower(text);
            firstPositionWithSpace = field.IndexOf(MetaCharacterSymbols.HorizontalTab);
            field = field.Substring(0, firstPositionWithSpace);
            field = _serviceFuncString.UDPRemoveSpecialCaracter(field);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(field));
        }

        public string UDPGetTheTypeOfFieldName(string text)
        {
            int firstPositionWithSpace = 0;
            string typeField = _serviceFuncString.Empty;

            typeField = _serviceFuncString.UDPLower(text);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.Comma, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNot, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNullValue, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNotNullValue, _serviceFuncString.Empty);
            firstPositionWithSpace = typeField.IndexOf(MetaCharacterSymbols.HorizontalTab);
            typeField = typeField.Substring(firstPositionWithSpace, System.Math.Abs(firstPositionWithSpace - typeField.Length));
            typeField = _serviceFuncString.UDPRemoveSpecialCaracter(typeField);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(typeField));
        }

        public string UDPGetThePrimaryKeyFieldName(string text)
        {
            string field = _serviceFuncString.Empty;

            field = _serviceFuncString.UDPReplace(text, SqlConfiguration.KeyPrimaryKey, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.LeftParenthese, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.RightParenthese, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.SingleQuote, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.DoubleQuote, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPRemoveAnyWhiteSpace(field);
            return _serviceFuncString.UDPUpper(field);
        }

        public bool UDPTheFieldIsNotNull(string text)
        {
            return _serviceFuncString.UDPContains(text, SqlConfiguration.KeyNotNullValue);
        }

        public void UDPLoadTheFieldAtTable(ref List<Tables> listTables, int idTable, string text)
        {
            listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Add(new Fields()
            {
                IdTables = idTable,
                Name = this.UDPGetTheFieldName(text),
                IsNull = this.UDPTheFieldIsNotNull(text),
                IsPrimaryKey = false,
                TypeField = this.UDPGetTheTypeOfFieldName(text)
            });
        }

        public void UDPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string[]? listOfFieldsPrimaryKey)
        {
            if (listTables is not null && listTables.Any(element => element.Id.Equals(idTable)))
            {
                if (listOfFieldsPrimaryKey is not null && listOfFieldsPrimaryKey.Any())
                {
                    for (int i = 0; i < listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Count; i++)
                    {
                        for (int j = 0; j < listOfFieldsPrimaryKey.Length; j++)
                        {
                            if (listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Where(element => element.Name.Contains(listOfFieldsPrimaryKey[j])).Any())
                            {
                                listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Where(element => element.Name.Contains(listOfFieldsPrimaryKey[j])).FirstOrDefault().IsPrimaryKey = true;
                            }
                        }
                    }
                }
            }
        }
    }
}