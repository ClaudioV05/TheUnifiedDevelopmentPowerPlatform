using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceSearchLinq : IServiceSearchLinq
    {
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public ServiceSearchLinq(IServiceFuncStrings serviceFuncStrings)
        {
            _serviceFuncStrings = serviceFuncStrings;
        }

        public string GetPathConfiguration(List<string> items)
        {
            return items.Select(element => _serviceFuncStrings.Lower(element))
                        .Where(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty))))
                        .FirstOrDefault() ?? string.Empty;
        }

        public List<string>? SelectAllPathFromDirectory(List<string> items, string defaultDirectory)
        {
            return items.Select(element => _serviceFuncStrings.Lower(element))
                        .Where(element => element.Contains(_serviceFuncStrings.Lower(defaultDirectory.Replace("\\", string.Empty))) || element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty))))
                        .OrderByDescending(element => element.Contains(_serviceFuncStrings.Lower(DirectoryStandard.CONFIGURATION.Replace("\\", string.Empty))))
                        .ToList() ?? null;
        }
    }
}