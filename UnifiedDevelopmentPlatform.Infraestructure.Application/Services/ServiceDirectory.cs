using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (Directory).
    /// </summary>
    public class ServiceDirectory : IServiceDirectory
    {
        private string? _directory;
        private readonly IServiceXml _serviceXml;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceJson _serviceJson;
        private readonly IServiceLinq _serviceLinq;
        private readonly Queue<string> _queueDirectory;
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public ServiceDirectory(IServiceXml serviceXml, IServiceFile serviceFile, IServiceJson serviceJson, IServiceLinq serviceLinq, IServiceFuncStrings serviceFuncStrings)
        {
            _serviceXml = serviceXml;
            _serviceFile = serviceFile;
            _serviceJson = serviceJson;
            _serviceLinq = serviceLinq;
            _queueDirectory = new Queue<string>();
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UPDCreateDirectoryProjectOfSolution()
        {
            JsonApp jsonApp;
            string data = string.Empty;
            string rootPathFilename = string.Empty;
            string[] directories = new string[] { DirectoryStandard.BACK_END, DirectoryStandard.FRONT_END };

            try
            {
                rootPathFilename = UDPGetRootPathFileInConfiguration(FileStandard.FILENAME_JSON_APP);
                data = _serviceFile.UDPReadAllText(rootPathFilename);
                jsonApp = (JsonApp)_serviceJson.UDPDesSerializerJsonToApp(data);

                _directory = jsonApp.Path;

                if (!_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
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
            string path = string.Empty;
            string json = string.Empty;

            try
            {
                _directory = this.UDPGetRootDirectory();

                if (_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
                    throw new Exception();
                }
                else
                {
                    this.UDPDeleteAllRootDirectoryOfSolution(_directory);

                    this.UDPCreateRootPathApp();

                    this.UDPCreateRootPathConfiguration();

                    this.UDPCreateAllRootPath(_queueDirectory);

                    #region Configuration.
                    path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{FileConfiguration.FILENAME_JSON_CONFIGURATION}";
                    _serviceFile.UDPCreateAndSaveInitialFile(path);
                    json = _serviceJson.UDPSerializerJson(new JsonConfiguration { Path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}" });
                    _serviceFile.UDPWriteAllText(path, json);
                    #endregion Configuration.

                    #region App.
                    path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{FileStandard.FILENAME_JSON_APP}";
                    _serviceFile.UDPCreateAndSaveInitialFile(path);
                    json = _serviceJson.UDPSerializerJson(new JsonApp { Path = $"{_directory}{DirectoryStandard.APP}" });
                    _serviceFile.UDPWriteAllText(path, json);
                    #endregion App.
                }
            }
            catch (Exception)
            {
                this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw;
            }
        }

        private string UDPGetRootDirectory()
        {
            Regex? regex = null;
            string? exeRootDirectory = string.Empty;
            string? rootDirectoryOfSolution = string.Empty;

            try
            {
                regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.Lower(Assembly.GetExecutingAssembly().Location);

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

        public string UDPGetRootPathFileInConfiguration(string fileName)
        {
            return $"{this.UDPGetRootDirectory()}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{fileName}";
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
        /// Create all root path of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateAllRootPath(Queue<string> queueDirectory)
        {
            try
            {
                if (queueDirectory != null && queueDirectory.Any())
                {
                    foreach (var dir in _queueDirectory)
                    {
                        if (_serviceFuncStrings.NullOrEmpty(dir))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Directory.CreateDirectory(dir ?? string.Empty);
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        /// <summary>
        /// Filter and save all paths with name of directories.
        /// </summary>
        /// <returns></returns>
        private void UDPFilterAndSavePaths(Queue<string> queueDirectory)
        {
            try
            {
                List<string>? lstWithoutAppConfiguration = _serviceLinq.UDPSelectRootPathWithoutAppConfiguration(queueDirectory.ToList());
                List<string>? lstWithAppConfiguration = _serviceLinq.UDPSelectRootPathWithAppConfiguration(queueDirectory.ToList());
                List<string>? lstSectionAppAndConfiguration = _serviceLinq.UDPSelectSectionStandard(lstWithAppConfiguration);

                if (lstWithoutAppConfiguration is null || lstWithAppConfiguration is null || lstSectionAppAndConfiguration is null)
                {
                    throw new Exception();
                }

                _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}\\{Xml.FILENAME_APP}.xml", lstSectionAppAndConfiguration[0], lstWithAppConfiguration[0]);
                _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}\\{Xml.FILENAME_CONFIGURATION}.xml", lstSectionAppAndConfiguration[1], lstWithAppConfiguration[1]);
                _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}\\{Xml.FILENAME_DIRECTORY}.xml", "directories", lstWithoutAppConfiguration);
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