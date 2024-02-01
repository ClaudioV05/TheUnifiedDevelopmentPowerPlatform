using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service forms.
    /// </summary>
    public interface IServiceForm
    {
        /// <summary>
        /// Return the list with all of forms.
        /// </summary>
        /// <returns></returns>
        List<Forms> FormsList();
    }
}