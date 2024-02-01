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
        /// <summary>
        /// The constructor of service form.
        /// </summary>
        public ServiceForm()
        {

        }

        public List<Forms> FormsList()
        {
            List<Forms> listItems = new List<Forms>();

            try
            {
                if (Enum.GetValues(typeof(EnumForm)) != null && Enum.GetValues(typeof(EnumForm)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumForm)).Length; i++)
                    {
                        listItems.Add(new Forms() { IdEnumeration = (EnumForm)i, NameEnumeration = Enum.GetName(typeof(EnumForm), i) });
                    }

                    listItems = listItems.OrderBy(item => item.IdEnumeration).ToList();
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}