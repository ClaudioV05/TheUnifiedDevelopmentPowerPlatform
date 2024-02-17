using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Forms;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service forms.
    /// </summary>
    public class ServiceForm : IServiceForm
    {
        private readonly IServiceEnumerated _serviceEnumerated;

        /// <summary>
        /// The constructor of service form.
        /// </summary>
        /// <param name="serviceEnumerated"></param>
        public ServiceForm(IServiceEnumerated serviceEnumerated)
        {
            _serviceEnumerated = serviceEnumerated;
        }

        public List<Forms> UDPSelectParametersTheKindsOfForms()
        {
            List<Forms> listItems = new List<Forms>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedForm)) != null && Enum.GetValues(typeof(EnumeratedForm)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedForm)).Length; i++)
                    {
                        listItems.Add(new Forms()
                        {
                            Id = (long)(EnumeratedForm)i,
                            IdEnumeration = (EnumeratedForm)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedForm), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedForm)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}