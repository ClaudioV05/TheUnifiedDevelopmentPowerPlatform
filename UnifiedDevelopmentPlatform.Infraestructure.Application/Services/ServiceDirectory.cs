﻿using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.AppSetting;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        private string? _directory;
        private readonly IServiceFile _serviceFile;
        private readonly Queue<string> _queueDirectory;
        private readonly IServiceFuncStrings _serviceFuncStrings;
        private readonly IServiceAppSettings _serviceAppSettings;
        private readonly IServiceLinq _serviceLanguageIntegratedQuery;
        private readonly IServiceXml _serviceExtensibleMarkupLanguage;

        public ServiceDirectory(IServiceFile serviceFile, IServiceFuncStrings serviceFuncStrings, IServiceAppSettings serviceAppSettings, IServiceXml serviceExtensibleMarkupLanguage, IServiceLinq serviceLanguageIntegratedQuery)
        {
            _queueDirectory = new Queue<string>();
            _serviceFile = serviceFile;
            _serviceFuncStrings = serviceFuncStrings;
            _serviceAppSettings = serviceAppSettings;
            _serviceExtensibleMarkupLanguage = serviceExtensibleMarkupLanguage;
            _serviceLanguageIntegratedQuery = serviceLanguageIntegratedQuery;
        }

        public void UPDCreateDirectoryProjectOfSolution()
        {
            string[] directories = new string[] { DirectoryStandard.BACK_END, DirectoryStandard.FRONT_END };

            try
            {
                _directory = "here get the appsettings the information.";

                if (!_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
                    this.CreateRootPathBackend();

                    this.CreateRootPathFrontend();

                    this.CreateRootPathPresentation(directories);

                    this.CreateRootPathApplication(directories);

                    this.CreateRootPathDomain(directories);

                    this.CreateRootPathInfrastructure(directories);

                    this.UDPCreateAllRootPath(_queueDirectory);

                    this.UDPFilterAndSavePaths(_queueDirectory);
                }
            }
            catch (IOException)
            {
                this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw new IOException();
            }
        }

        public void UPDCreateDirectoryStandardOfSolution()
        {
            try
            {
                _directory = this.UDPGetRootDirectoryExecutableOfSolution();

                if (!_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
                    this.UDPDeleteAllRootDirectoryOfSolution(_directory);

                    this.UDPCreateRootPathApp();

                    this.UDPCreateRootPathConfiguration();

                    this.UDPCreateAllRootPath(_queueDirectory);

                    _serviceFile.UDPCreateAndSaveInitialFile($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{FileConfiguration.UDP_APPSETTINGS}");

                    var path = this.UDPLoadFilesDirectory(AppContext.BaseDirectory, AppSetting.FILE_NAME);

                    _serviceAppSettings.UPDAddAppSettings(path, AppSetting.KEY_DIRECTORY, /* HERE TO PASS JSON*/);
                }
            }
            catch (Exception)
            {
                this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw;
            }
        }

        public string UDPLoadFilesDirectory(string pathOne, string pathTwo)
        {
            return Path.Combine(pathOne, pathTwo);
        }

        #region Private Methods.

        /// <summary>
        /// Delete all root directory of solution.
        /// </summary>
        /// <returns></returns>
        private bool UDPDeleteAllRootDirectoryOfSolution(string? rootDirectory)
        {
            try
            {
                if (!_serviceFuncStrings.NullOrEmpty(rootDirectory ?? string.Empty))
                {
                    if (Directory.Exists($"{rootDirectory}{DirectoryStandard.APP}"))
                    {
                        Directory.Delete($"{rootDirectory}{DirectoryStandard.APP}", true);
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Obtain the root directory executable of solution.
        /// </summary>
        /// <returns>The root directory executable of solution.</returns>
        private string? UDPGetRootDirectoryExecutableOfSolution()
        {
            string? rootDirectoryOfSolution = string.Empty;

            try
            {
                string? exeRootDirectory = Assembly.GetExecutingAssembly().Location;
                Regex regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.Lower(exeRootDirectory);

                if (regex.IsMatch(exeRootDirectory ?? string.Empty))
                {
                    rootDirectoryOfSolution = regex.Match(exeRootDirectory ?? string.Empty).Value;
                }

                return rootDirectoryOfSolution;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Create all root path of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateAllRootPath(Queue<string> queueDirectory)
        {
            try
            {
                if (queueDirectory != null && queueDirectory.Count > 0)
                {
                    foreach (var dir in _queueDirectory)
                    {
                        Directory.CreateDirectory(dir ?? string.Empty);
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        /// <summary>
        /// Filter and save all paths with name of directories.
        /// </summary>
        /// <returns></returns>
        private void UDPFilterAndSavePaths(Queue<string> queueDirectory)
        {
            string directoryDefaultToSave = string.Empty;

            try
            {
                List<string>? lstWithoutAppConfiguration = _serviceLanguageIntegratedQuery.UDPSelectRootPathWithoutAppConfiguration(queueDirectory.ToList());

                List<string>? lstWithAppConfiguration = _serviceLanguageIntegratedQuery.UDPSelectRootPathWithAppConfiguration(queueDirectory.ToList());
                List<string>? lstSectionAppAndConfiguration = _serviceLanguageIntegratedQuery.UDPSelectSectionStandard(lstWithAppConfiguration);

                if (lstWithoutAppConfiguration is null || lstWithAppConfiguration is null || lstSectionAppAndConfiguration is null)
                {
                    throw new Exception();
                }

                _serviceExtensibleMarkupLanguage.UPDTreeXmlSaveConfigurationFile(lstWithAppConfiguration[1], lstWithAppConfiguration);
                _serviceExtensibleMarkupLanguage.UPDTreeXmlSaveDirectoriesFile(lstWithAppConfiguration[1], lstWithoutAppConfiguration);
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        #region Standard Path.

        /// <summary>
        /// Create root path app of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathApp()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}");
        }

        /// <summary>
        /// Create root path configuration of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathConfiguration()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}");
        }

        /// <summary>
        /// Create root path back end of solution.
        /// </summary>
        /// <returns></returns>
        private void CreateRootPathBackend()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.BACK_END}");
        }

        /// <summary>
        /// Create root path front end of solution.
        /// </summary>
        /// <returns></returns>
        private void CreateRootPathFrontend()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.FRONT_END}");
        }

        #endregion Standard Path.

        #region Presentation.

        /// <summary>
        /// Create root path presentation of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathPresentation(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.PROPERTIES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.CONTROLLERS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.EXTENSIONS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.FILTERS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.MODELS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.SWAGGER}");
            }
        }

        #endregion Presentation.

        #region Application.

        /// <summary>
        /// Create root path application of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathApplication(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryApplication.APPLICATION}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.SERVICES}");
            }
        }

        #endregion Application.

        #region Domain.

        /// <summary>
        /// Create root path domain of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathDomain(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryDomain.DOMAIN}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.ENTITIES}");
            }
        }

        #endregion Domain.

        #region Infrastructure.

        /// <summary>
        /// Create root path infrastructure of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathInfrastructure(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.CROSSCUTTING}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.DATA}");
            }
        }

        #endregion Infrastructure.

        #endregion Private Methods.
    }
}