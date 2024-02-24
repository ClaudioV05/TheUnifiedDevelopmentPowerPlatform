﻿using System.Reflection;
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

        public string UDPObtainDirectory(DirectoryRootType directoryRootType)
        {
            DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();
            return $"{DirectoryRoot.DirectoryRootPath}{this.UDPObtainDirectoryRoot(directoryRootType)}";
        }

        public void UPDBuildDirectoryStandardOfSolution()
        {
            try
            {
                DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();

                this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");

                if (Enum.GetValues(typeof(DirectoryRootType)) != null && Enum.GetValues(typeof(DirectoryRootType)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
                    {
                        if ((DirectoryRootType)i == DirectoryRootType.App || (DirectoryRootType)i == DirectoryRootType.Configuration || (DirectoryRootType)i == DirectoryRootType.Json || (DirectoryRootType)i == DirectoryRootType.Log || (DirectoryRootType)i == DirectoryRootType.Xml)
                        {
                            this.UDPLoadDirectory($"{DirectoryRoot.DirectoryRootPath}{this.UDPObtainDirectoryRoot((DirectoryRootType)i)}");
                        }
                    }
                }

                this.UDPCreateDirectory();
            }
            catch (Exception)
            {
                this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");
                throw;
            }
        }

        public void UPDCreateDirectoryProjectOfSolution()
        {
            try
            {
                DirectoryRoot.DirectoryRootPath = this.UDPGetRootDirectory();

                if (Enum.GetValues(typeof(DirectoryRootType)) != null && Enum.GetValues(typeof(DirectoryRootType)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(DirectoryRootType)).Length; i++)
                    {
                        if ((DirectoryRootType)i == DirectoryRootType.Backend || (DirectoryRootType)i == DirectoryRootType.Frontend)
                        {
                            continue;
                        }

                        if ((DirectoryRootType)i != DirectoryRootType.App || (DirectoryRootType)i != DirectoryRootType.Configuration || (DirectoryRootType)i != DirectoryRootType.Json || (DirectoryRootType)i != DirectoryRootType.Log || (DirectoryRootType)i != DirectoryRootType.Xml)
                        {
                            this.UDPLoadDirectory($"{DirectoryRoot.DirectoryRootPath}{this.UDPObtainDirectoryRoot((DirectoryRootType)i)}");
                        }
                    }
                }

                this.UDPCreateDirectory();
            }
            catch (IOException)
            {
                this.UDPDeleteAllRootDirectory($"{DirectoryRoot.DirectoryRootPath}{DirectoryRoot.App}");
                throw new IOException();
            }
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
                    for (int i = 0; i <= _listDirectory.Count; i++)
                    {
                        if (!_serviceFuncStrings.UDPNullOrEmpty(_listDirectory[i]))
                        {
                            Directory.CreateDirectory(_listDirectory[i]);
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        private bool UDPDeleteAllRootDirectory(string rootPath)
        {
            try
            {
                if (Directory.Exists(rootPath))
                {
                    Directory.Delete(rootPath, true);
                }
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        private string UDPObtainDirectoryRoot(DirectoryRootType directoryRootType) => directoryRootType switch
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
    }
}