using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service directory.
/// </summary>
public class ServiceDirectory : IServiceDirectory
{
    private readonly List<string> _listDirectory;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// Constructor of service directory.
    /// </summary>
    /// <param name="serviceFuncString"></param>
    public ServiceDirectory(IServiceFuncString serviceFuncString)
    {
        _listDirectory = new List<string>();
        _serviceFuncString = serviceFuncString;
    }

    public void UDPPCreateDirectoriesDefault()
    {
        try
        {
            DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();

            this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");

            if (Enum.GetValues(typeof(DirectoryRootType)) != null && Enum.GetValues(typeof(DirectoryRootType)).Length > 0)
            {
                for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
                {
                    if ((DirectoryRootType)i == DirectoryRootType.App || (DirectoryRootType)i == DirectoryRootType.Configuration || (DirectoryRootType)i == DirectoryRootType.Log)
                    {
                        this.UDPAddAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{this.UDPObtainDirectoryRoot((DirectoryRootType)i)}");
                    }
                }
            }

            this.UDPCreateAllRootDirectory();
        }
        catch (Exception)
        {
            this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");
            throw;
        }
    }

    public void UDPPCreateDirectoriesFromArchitecture(EnumeratedArchitecturePatterns enumeratedArchitecturePatterns)
    {
        try
        {
            DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();

            switch (enumeratedArchitecturePatterns)
            {
                case EnumeratedArchitecturePatterns.NotDefined:
                    break;
                case EnumeratedArchitecturePatterns.Ddd:
                    this.UDPCreateDirectoriesToDomainDrivenDesign(DirectoryRoot.DirectoryRootPath);
                    break;
                case EnumeratedArchitecturePatterns.MediatRCqrs:
                    this.UDPCreateDirectoriesToMediatr(DirectoryRoot.DirectoryRootPath);
                    break;
                case EnumeratedArchitecturePatterns.Mvc:
                    this.UDPCreateDirectoriesToModelViewController(DirectoryRoot.DirectoryRootPath);
                    break;
                default:
                    break;
            }

            this.UDPCreateAllRootDirectory();
        }
        catch (IOException)
        {
            this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");
            throw new IOException();
        }
    }

    public bool UDPPDirectoryExists(string absolutePath)
    {
        return Directory.Exists(absolutePath);
    }

    public string UDPPObtainDirectory(DirectoryRootType directoryRootType)
    {
        try
        {
            DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();
            return $"{DirectoryRoot.DirectoryRootPath}{this.UDPObtainDirectoryRoot(directoryRootType)}";
        }
        catch (Exception)
        {
            return _serviceFuncString.Empty;
        }
    }

    public long UDPPGetMetricsOfTheTotalSizeOfDirectory(DirectoryInfo directory)
    {
        if (directory is null || !directory.Exists)
        {
            throw new DirectoryNotFoundException("Directory does not exist.");
        }

        long size = 0;

        try
        {
            Parallel.ForEach(directory.EnumerateFiles(MetaCharacterSymbols.Asterisk, SearchOption.AllDirectories), fileInfo =>
            {
                try
                {
                    Interlocked.Add(ref size, fileInfo.Length);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException($"Unauthorized access to {fileInfo.FullName}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error processing {fileInfo.FullName} | Error {ex.Message} ");
                }
            });
        }
        catch (UnauthorizedAccessException)
        {
            throw new Exception($"Unauthorized access to {directory.FullName}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error processing {directory.FullName} | Error {ex.Message} ");
        }

        return size;
    }

    #region Private methods.

    private string UDPGetRootDirectory()
    {
        try
        {
            Regex? regex = new(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentpowerplatform.presentation.api)");
            string? exeRootDirectory = _serviceFuncString.UDPPLower(Assembly.GetExecutingAssembly().Location);

            return regex.IsMatch(exeRootDirectory) ? regex.Match(exeRootDirectory).Value : _serviceFuncString.Empty;
        }
        catch (IOException)
        {
            return _serviceFuncString.Empty;
        }
    }

    private string UDPObtainDirectoryRoot(DirectoryRootType directoryRootType)
    {
        return directoryRootType switch
        {
            DirectoryRootType.App => DirectoryRoot.App,
            DirectoryRootType.Backend => DirectoryRoot.Backend,
            DirectoryRootType.Frontend => DirectoryRoot.Frontend,
            DirectoryRootType.Configuration => DirectoryRoot.Configuration,
            DirectoryRootType.Log => DirectoryRoot.Log,
            DirectoryRootType.BackendPresentation => DirectoryRoot.BackendPresentation,
            DirectoryRootType.BackendPresentationProperties => DirectoryRoot.BackendPresentationProperties,
            DirectoryRootType.BackendPresentationControllers => DirectoryRoot.BackendPresentationControllers,
            DirectoryRootType.BackendPresentationExtensions => DirectoryRoot.BackendPresentationExtensions,
            DirectoryRootType.BackendPresentationFilters => DirectoryRoot.BackendPresentationFilters,
            DirectoryRootType.BackendPresentationModels => DirectoryRoot.BackendPresentationModels,
            DirectoryRootType.BackendPresentationSwagger => DirectoryRoot.BackendPresentationSwagger,
            DirectoryRootType.FrontendPresentation => DirectoryRoot.FrontendPresentation,
            DirectoryRootType.FrontendPresentationProperties => DirectoryRoot.FrontendPresentationProperties,
            DirectoryRootType.FrontendPresentationControllers => DirectoryRoot.FrontendPresentationControllers,
            DirectoryRootType.FrontendPresentationExtensions => DirectoryRoot.FrontendPresentationExtensions,
            DirectoryRootType.FrontendPresentationFilters => DirectoryRoot.FrontendPresentationFilters,
            DirectoryRootType.FrontendPresentationModels => DirectoryRoot.FrontendPresentationModels,
            DirectoryRootType.FrontendPresentationSwagger => DirectoryRoot.FrontendPresentationSwagger,
            DirectoryRootType.BackendApplication => DirectoryRoot.BackendApplication,
            DirectoryRootType.BackendApplicationInterfaces => DirectoryRoot.BackendApplicationInterfaces,
            DirectoryRootType.BackendApplicationServices => DirectoryRoot.BackendApplicationServices,
            DirectoryRootType.FrontendApplication => DirectoryRoot.FrontendApplication,
            DirectoryRootType.FrontendApplicationInterfaces => DirectoryRoot.FrontendApplicationInterfaces,
            DirectoryRootType.FrontendApplicationServices => DirectoryRoot.FrontendApplicationServices,
            DirectoryRootType.BackendDomain => DirectoryRoot.BackendDomain,
            DirectoryRootType.BackendDomainInterfaces => DirectoryRoot.BackendDomainInterfaces,
            DirectoryRootType.BackendDomainEntities => DirectoryRoot.BackendDomainEntities,
            DirectoryRootType.FrontendDomain => DirectoryRoot.FrontendDomain,
            DirectoryRootType.FrontendDomainInterfaces => DirectoryRoot.FrontendDomainInterfaces,
            DirectoryRootType.FrontendDomainEntities => DirectoryRoot.FrontendDomainEntities,
            DirectoryRootType.BackendInfrastructure => DirectoryRoot.BackendInfrastructure,
            DirectoryRootType.BackendInfrastructureCrossCutting => DirectoryRoot.BackendInfrastructureCrossCutting,
            DirectoryRootType.BackendInfrastructureData => DirectoryRoot.BackendInfrastructureData,
            DirectoryRootType.FrontendInfrastructure => DirectoryRoot.FrontendInfrastructure,
            DirectoryRootType.FrontendInfrastructureCrossCutting => DirectoryRoot.FrontendInfrastructureCrossCutting,
            DirectoryRootType.FrontendInfrastructureData => DirectoryRoot.FrontendInfrastructureData,
            _ => _serviceFuncString.Empty
        };
    }

    private void UDPDeleteAllRootDirectory(string absolutePath)
    {
        try
        {
            if (this.UDPPDirectoryExists(absolutePath))
            {
                Directory.Delete(absolutePath, true);
            }
        }
        catch (Exception) { }
    }

    private void UDPAddAllRootDirectory(string absolutePath) => _listDirectory.Add(absolutePath);

    private void UDPCreateAllRootDirectory() => _listDirectory.ForEach(dir => Directory.CreateDirectory(dir));

    private void UDPCreateDirectoriesToDomainDrivenDesign(string absolutePath)
    {
        for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
        {
            if ((DirectoryRootType)i is DirectoryRootType.Backend || (DirectoryRootType)i is DirectoryRootType.Frontend)
            {
                continue;
            }

            if ((DirectoryRootType)i is not DirectoryRootType.App || (DirectoryRootType)i is not DirectoryRootType.Configuration || (DirectoryRootType)i is not DirectoryRootType.Log)
            {
                this.UDPAddAllRootDirectory($"{absolutePath}{this.UDPObtainDirectoryRoot((DirectoryRootType)i)}");
            }
        }
    }

    private void UDPCreateDirectoriesToModelViewController(string absolutePath)
    {

    }

    private void UDPCreateDirectoriesToMediatr(string absolutePath)
    {

    }

    #endregion Private methods.
}