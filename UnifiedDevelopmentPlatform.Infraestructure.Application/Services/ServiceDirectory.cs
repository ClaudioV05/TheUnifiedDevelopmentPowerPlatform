using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Directory.
    /// </summary>
    public class ServiceDirectory : IServiceDirectory
    {
        private readonly List<string> _listDirectory;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// Constructor of service directory.
        /// </summary>
        /// <param name="serviceFuncStrings"></param>
        public ServiceDirectory(IServiceFuncString serviceFuncStrings)
        {
            _listDirectory = new List<string>();
            _serviceFuncStrings = serviceFuncStrings;
        }

        public string UDPObtainDirectoryRoot(DirectoryRootType directoryRootType)
        {
            return directoryRootType switch
            {
                DirectoryRootType.App => DirectoryRoot.App,
                DirectoryRootType.Backend => DirectoryRoot.Backend,
                DirectoryRootType.Frontend => DirectoryRoot.Frontend,
                DirectoryRootType.Configuration => DirectoryRoot.Configuration,
                DirectoryRootType.Json => DirectoryRoot.Json,
                DirectoryRootType.Log => DirectoryRoot.Log,
                DirectoryRootType.Xml => DirectoryRoot.Xml,
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
                _ => _serviceFuncStrings.Empty
            };
        }

        public void UPDBuildDirectoryStandardOfSolution()
        {
            try
            {
                this.UDPLoadDirectoryRootPath(this.UDPGetRootDirectory());
                //this.UDPDeleteAllRootDirectoryOfSolution(_directory);

                if (Enum.GetValues(typeof(DirectoryRootType)) != null && Enum.GetValues(typeof(DirectoryRootType)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
                    {
                        if ((DirectoryRootType)i == DirectoryRootType.App ||
                            (DirectoryRootType)i == DirectoryRootType.Configuration ||
                            (DirectoryRootType)i == DirectoryRootType.Json ||
                            (DirectoryRootType)i == DirectoryRootType.Log ||
                            (DirectoryRootType)i == DirectoryRootType.Xml)
                        {
                            this.UDPLoadDirectory(this.UDPObtainDirectoryRoot((DirectoryRootType)i));
                        }
                    }
                }

                this.UDPCreateDirectory();
            }
            catch (Exception)
            {
                //this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw;
            }
        }

        public void UPDCreateDirectoryProjectOfSolution()
        {
            try
            {
                this.UDPLoadDirectoryRootPath(this.UDPGetRootDirectory());

                if (Enum.GetValues(typeof(DirectoryRootType)) != null && Enum.GetValues(typeof(DirectoryRootType)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
                    {
                        if ((DirectoryRootType)i != DirectoryRootType.App ||
                            (DirectoryRootType)i != DirectoryRootType.Configuration ||
                            (DirectoryRootType)i != DirectoryRootType.Json ||
                            (DirectoryRootType)i != DirectoryRootType.Log ||
                            (DirectoryRootType)i != DirectoryRootType.Xml)
                        {
                            this.UDPLoadDirectory(this.UDPObtainDirectoryRoot((DirectoryRootType)i));
                        }
                    }
                }

                this.UDPCreateDirectory();
            }
            catch (IOException)
            {
                //this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw new IOException();
            }
        }

        private string UDPGetRootDirectory()
        {
            Regex? regex = null;
            string? exeRootDirectory = _serviceFuncStrings.Empty;
            string? rootDirectoryOfSolution = _serviceFuncStrings.Empty;

            try
            {
                regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.UDPLower(Assembly.GetExecutingAssembly().Location);

                if (regex.IsMatch(exeRootDirectory ?? _serviceFuncStrings.Empty))
                {
                    rootDirectoryOfSolution = regex.Match(exeRootDirectory ?? _serviceFuncStrings.Empty).Value;
                }

                return rootDirectoryOfSolution;
            }
            catch (IOException)
            {
                return _serviceFuncStrings.Empty;
            }
        }

        private void UDPLoadDirectoryRootPath(string rootPath)
        {
            DirectoryRoot.DirectoryRootPath = rootPath;
        }

        private void UDPLoadDirectory(string rootPath)
        {
            _listDirectory.Add(rootPath);
        }

        private void UDPCreateDirectory()
        {
            try
            {
                if (_listDirectory != null && _listDirectory.Any())
                {
                    Parallel.ForEach(_listDirectory, directory =>
                    {
                        if (_serviceFuncStrings.UDPNullOrEmpty(directory))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Directory.CreateDirectory(directory);
                        }
                    });
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
    }
}