using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Symbol;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata Fields.
    /// </summary>
    public class ServiceMetadataField : IServiceMetadataField
    {
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of Service Metadata Fields.
        /// </summary>
        /// <param name="serviceFuncString"></param>
        public ServiceMetadataField(IServiceFuncString serviceFuncString)
        {
            _serviceFuncString = serviceFuncString;
        }

        public string UDPGetFieldName(string text)
        {
            int firstPositionWithSpace = 0;
            string field = _serviceFuncString.Empty;

            field = _serviceFuncString.UDPLower(text);
            firstPositionWithSpace = field.IndexOf(Symbols.HorizontalTab);
            field = field.Substring(0, firstPositionWithSpace);
            field = _serviceFuncString.UDPRemoveSpecialCaracter(field);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(field));
        }

        public string UDPGetTypeFieldName(string text)
        {
            int firstPositionWithSpace = 0;
            string typeField = _serviceFuncString.Empty;

            typeField = _serviceFuncString.UDPLower(text);
            typeField = _serviceFuncString.UDPReplace(typeField, Symbols.Comma, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNot, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNullValue, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNotNullValue, _serviceFuncString.Empty);
            firstPositionWithSpace = typeField.IndexOf(Symbols.HorizontalTab);
            typeField = typeField.Substring(firstPositionWithSpace, System.Math.Abs(firstPositionWithSpace - typeField.Length));
            typeField = _serviceFuncString.UDPRemoveSpecialCaracter(typeField);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(typeField));
        }

        public bool UDPFieldIsNotNull(string text)
        {
            return _serviceFuncString.UDPContains(text, SqlConfiguration.KeyNotNullValue);
        }

        public List<string> UDPMetadataTableAndAllFields(MetadataOwner? metadata)
        {
            throw new NotImplementedException();
        }
    }
}