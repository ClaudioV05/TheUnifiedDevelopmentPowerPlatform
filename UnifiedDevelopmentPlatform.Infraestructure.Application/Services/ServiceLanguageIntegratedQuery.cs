using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceLanguageIntegratedQuery : IServiceLanguageIntegratedQuery
    {
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public ServiceLanguageIntegratedQuery(IServiceFuncStrings serviceFuncStrings)
        {
            _serviceFuncStrings = serviceFuncStrings;
        }

        public string UDPSelectRootPathConfiguration(List<string> listItem)
        {
            listItem = this.ListLowerToDefault(listItem);
            listItem = this.ListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public string UDPSelectRootPathApp(List<string> listItem)
        {
            listItem = this.ListLowerToDefault(listItem);
            listItem = this.ListOrderByForDefault(listItem);
            return listItem.Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.APP.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
        }

        public List<string>? UDPSelectSectionStandard(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.SelectSectionStandard(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0)
                           .ToList();
        }

        public List<string>? UDPSelectSectionFrontend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.SelectSectionStandard(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0)
                           .ToList();
        }

        public List<string>? UDPSelectSectionBackend(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.SelectSectionStandard(element))
                           .Where(element => !_serviceFuncStrings.NullOrEmpty(element) && element.Length > 0)
                           .ToList();
        }

        public List<string>? UDPSelectRootPathWithAppConfiguration(List<string> listItem)
        {
            string[] directories = new string[2];

            listItem = this.ListLowerToDefault(listItem);
            listItem = this.ListOrderByForDefault(listItem);

            directories[0] = SelectRootPathApp(listItem);
            directories[1] = SelectRootPathConfiguration(listItem);

            return directories.ToList();
        }

        public List<string>? UDPSelectRootPathWithoutAppConfiguration(List<string> listItem)
        {
            listItem = this.ListLowerToDefault(listItem);
            listItem = this.ListOrderByForDefault(listItem);
            return listItem.Where(element => !element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.APP.Replace("\\", string.Empty))) || !element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty)))).Skip(1).ToList();
        }

        #region Methods.

        private List<string> ListOrderByForDefault(List<string> listItem)
        {
            return listItem.OrderBy(element => element).ToList();
        }

        private List<string> ListLowerToDefault(List<string> listItem)
        {
            return listItem.Select(element => _serviceFuncStrings.Lower(element)).ToList();
        }

        #endregion Methods.
    }
}