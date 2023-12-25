using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (LINQ Language Integrated Query).
    /// </summary>
    public class ServiceLinq : IServiceLinq
    {
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public ServiceLinq(IServiceFuncStrings serviceFuncStrings)
        {
            _serviceFuncStrings = serviceFuncStrings;
        }

        public string UDPSelectRootPathConfiguration(List<string> listItem)
        {
            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public string UDPSelectRootPathApp(List<string> listItem)
        {
            listItem = this.UDPListLowerToDefault(listItem);
            listItem = this.UDPListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.APP.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public List<string>? UDPSelectSectionStandard(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0)
                           .ToList();
        }

        public List<string>? UDPSelectSectionFrontend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0 && element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.FRONT_END.Replace("\\", string.Empty))))
                           .ToList();
        }

        public List<string>? UDPSelectSectionBackend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.UDPSelectSection(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0)
                           .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.BACK_END.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryPresentation.PRESENTATION.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryApplication.APPLICATION.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryDomain.DOMAIN.Replace("\\", string.Empty))))
                           .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryInfrastructure.INFRASTRUCTURE.Replace("\\", string.Empty))))
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
            return listItem.Where(element => !element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.APP.Replace("\\", string.Empty))) || !element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty)))).Skip(1).ToList();
        }

        #region Methods.

        private List<string> UDPListOrderByForDefault(List<string> listItem)
        {
            return listItem.OrderBy(element => element).ToList();
        }

        private List<string> UDPListLowerToDefault(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.Lower(element)).ToList();
        }

        #endregion Methods.
    }
}