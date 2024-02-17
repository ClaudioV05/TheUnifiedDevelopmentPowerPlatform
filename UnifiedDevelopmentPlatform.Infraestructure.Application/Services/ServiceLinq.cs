using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Language Integrated Query - LINQ.
    /// </summary>
    public class ServiceLinq : IServiceLinq
    {
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Language Integrated Query - LINQ.
        /// </summary>
        public ServiceLinq(IServiceFuncString serviceFuncStrings)
        {
            _serviceFuncStrings = serviceFuncStrings;
        }

        public string UDPSelectRootPathConfiguration(List<string> listItem)
        {
            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.Configuration.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public string UDPSelectRootPathApp(List<string> listItem)
        {
            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.App.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public List<string>? UDPSelectSectionStandard(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.UDPNullOrEmpty(element) && element.Length > 0)
                           .ToList();
        }

        public List<string>? UDPSelectSectionFrontend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.UDPNullOrEmpty(element) && element.Length > 0 && element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.Frontend.Replace("\\", string.Empty))))
                           .ToList();
        }

        public List<string>? UDPSelectSectionBackend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.UDPNullOrEmpty(element) && element.Length > 0)
                           .Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.Backend.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryPresentation.Presentation.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryApplication.Application.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryDomain.Domain.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.UDPLower(DirectoryInfrastructure.Infrastructure.Replace("\\", string.Empty))))
                           .ToList();
        }

        public List<string>? UDPSelectRootPathWithAppConfiguration(List<string> listItem)
        {
            string[] directories = new string[2];

            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);

            directories[0] = UDPSelectRootPathApp(listItem);
            directories[1] = UDPSelectRootPathConfiguration(listItem);

            return directories.ToList();
        }

        public List<string>? UDPSelectRootPathWithoutAppConfiguration(List<string> listItem)
        {
            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);
            return listItem.Where(element => !element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.App.Replace("\\", string.Empty))) || !element.Contains(_serviceFuncStrings.UDPLower(DirectoryStandard.Configuration.Replace("\\", string.Empty)))).Skip(1).ToList();
        }

        public List<string> UDPDistinct(List<string> listItem)
        {
            return listItem.GroupBy(element => element).Select(d => d.First()).ToList();
        }

        #region Methods.

        private List<string> UDPListOrderByForDefault(List<string> listItem)
        {
            return listItem.OrderBy(element => element).ToList();
        }

        private List<string> UDPListLowerToDefault(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPLower(element)).ToList();
        }

        #endregion Methods.
    }
}