using System.ComponentModel;
using System.Reflection;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Enumerated.
    /// </summary>
    public class ServiceEnumerated : IServiceEnumerated
    {
        /// <summary>
        /// The constructor of Service Enumerated.
        /// </summary>
        public ServiceEnumerated() { }

        public string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public List<Enum> ListOfEnumerated(Enum MyEnum)
        {
            try
            {
                return Enum.GetNames(typeof(Enum)).Cast<Enum>().ToList();
            }
            catch (InvalidCastException)
            {
                return new List<Enum>();
            }
        }
    }
}