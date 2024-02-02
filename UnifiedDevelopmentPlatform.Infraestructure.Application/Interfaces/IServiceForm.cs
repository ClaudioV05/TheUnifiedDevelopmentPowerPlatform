using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service forms.
    /// </summary>
    public interface IServiceForm
    {
        /// <summary>
        /// Return the full list of all forms.
        /// </summary>
        /// <returns>List of forms</returns>
        List<Forms> UDPObtainTheListOfForms();
    }
}