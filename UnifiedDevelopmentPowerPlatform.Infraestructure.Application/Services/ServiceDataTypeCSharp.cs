﻿using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service data type c-sharp.
    /// </summary>
    public class ServiceDataTypeCSharp : IServiceDataTypeCSharp
    {
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service data type c-sharp.
        /// </summary>
        /// <param name="serviceFuncString" />
        public ServiceDataTypeCSharp(IServiceFuncString serviceFuncString)
        {
            _serviceFuncString = serviceFuncString;
        }

        public bool UDPByIndexEnumTypeIsDefined(int index)
        {
            return Enum.IsDefined(typeof(AnsiSql.DataType), index);
        }

        public CSharp.DataType UDPGetAsEnumeratedTheEnumType(int index)
        {
            return (CSharp.DataType)index;
        }

        public int UDPReturnIndexFromTheListOfDataTypes(string dataType)
        {
            string type = _serviceFuncString.Empty;

            try
            {
                type = dataType;
                type = _serviceFuncString.UDPLower(type);
                type = _serviceFuncString.UDPOnlyLetter(type);

                return Enum.GetNames(typeof(CSharp.DataType))
                           .ToList()
                           .FindIndex(element => _serviceFuncString.UDPContains(_serviceFuncString.UDPLower(element), type));
            }
            catch (Exception)
            {
                return Convert.ToInt32("0");
            }
        }

        public string UDPGetAsStringTheEnumType(CSharp.DataType dataType)
        {
            return Enum.GetName(typeof(CSharp.DataType), dataType) ?? _serviceFuncString.Empty;
        }
    }
}