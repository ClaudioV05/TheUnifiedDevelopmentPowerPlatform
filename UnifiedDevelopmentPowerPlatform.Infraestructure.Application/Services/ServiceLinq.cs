using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service linq.
/// </summary>
public class ServiceLinq : IServiceLinq
{
    private readonly IServiceFuncString _serviceFuncStrings;

    /// <summary>
    /// The constructor of service linq.
    /// </summary>
    public ServiceLinq(IServiceFuncString serviceFuncStrings)
    {
        _serviceFuncStrings = serviceFuncStrings;
    }

    public string UDPPSelectRootPathConfiguration(List<string> listItem)
    {
        listItem = this.UDPListLowerToDefault(listItem);
        listItem = this.UDPListOrderByForDefault(listItem);
        return listItem.Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.Configuration.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
    }

    public string UDPPSelectRootPathApp(List<string> listItem)
    {
        listItem = this.UDPListLowerToDefault(listItem);
        listItem = this.UDPListOrderByForDefault(listItem);
        return listItem.Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.App.Replace("\\", string.Empty)))).FirstOrDefault() ?? string.Empty;
    }

    public List<string>? UDPPSelectSectionStandard(List<string> listItem)
    {
        return listItem.Select(element => _serviceFuncStrings.UDPPSelectSection(element))
                       .Where(element => !_serviceFuncStrings.UDPPNullOrEmpty(element) && element.Length > 0)
                       .ToList();
    }

    public List<string>? UDPPSelectSectionFrontend(List<string> listItem)
    {
        return listItem.Select(element => _serviceFuncStrings.UDPPSelectSection(element))
                       .Where(element => !_serviceFuncStrings.UDPPNullOrEmpty(element) && element.Length > 0 && element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.Frontend.Replace("\\", string.Empty))))
                       .ToList();
    }

    public List<string>? UDPPSelectSectionBackend(List<string> listItem)
    {
        return listItem.Select(element => _serviceFuncStrings.UDPPSelectSection(element))
                       .Where(element => !_serviceFuncStrings.UDPPNullOrEmpty(element) && element.Length > 0)
                       .Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.Backend.Replace("\\", string.Empty))))
                       .Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryPresentation.Presentation.Replace("\\", string.Empty))))
                       .Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryApplication.Application.Replace("\\", string.Empty))))
                       .Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryDomain.Domain.Replace("\\", string.Empty))))
                       .Where(element => element.Contains(_serviceFuncStrings.UDPPLower(DirectoryInfrastructure.Infrastructure.Replace("\\", string.Empty))))
                       .ToList();
    }

    public List<string>? UDPPSelectRootPathWithAppConfiguration(List<string> listItem)
    {
        string[] directories = new string[2];

        listItem = this.UDPListLowerToDefault(listItem);
        listItem = this.UDPListOrderByForDefault(listItem);

        directories[0] = UDPPSelectRootPathApp(listItem);
        directories[1] = UDPPSelectRootPathConfiguration(listItem);

        return directories.ToList();
    }

    public List<string>? UDPPSelectRootPathWithoutAppConfiguration(List<string> listItem)
    {
        listItem = this.UDPListLowerToDefault(listItem);
        listItem = this.UDPListOrderByForDefault(listItem);
        return listItem.Where(element => !element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.App.Replace("\\", string.Empty))) || !element.Contains(_serviceFuncStrings.UDPPLower(DirectoryStandard.Configuration.Replace("\\", string.Empty)))).Skip(1).ToList();
    }

    public List<string> UDPPDistinct(List<string> listItem)
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
        return listItem.Select(element => _serviceFuncStrings.UDPPLower(element)).ToList();
    }

    #endregion Methods.
}