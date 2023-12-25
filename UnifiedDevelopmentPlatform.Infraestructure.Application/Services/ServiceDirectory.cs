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

        public ServiceDirectory(IServiceXml serviceXml,
                                IServiceFile serviceFile,
                                IServiceJson serviceJson,
                                IServiceLinq serviceLinq,
                                IServiceFuncStrings serviceFuncStrings)
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
            string json = string.Empty;
            string path = string.Empty;
            JsonApp jsonApp;
            string[] directories = new string[] { DirectoryStandard.BACK_END, DirectoryStandard.FRONT_END };

            try
            {
                path = UDPGetRootPathFileInConfiguration($"{FileStandard.FILENAME_APP}{FileExtension.JSON}");
                json = _serviceFile.UDPReadAllText(path);
                jsonApp = (JsonApp)_serviceJson.UDPDesSerializerJsonToApp(json);

                _directory = jsonApp.Path;

                if (!_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
                    if (_queueDirectory.Any())
                    {
                        _queueDirectory.Clear();
                    }

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
                    this.UDPCreateRootPathJson();
                    this.UDPCreateRootPathXml();
                    this.UDPCreateRootPathLog();

                    this.UDPCreateAllRootPath(_queueDirectory);

                    #region Configuration.
                    path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.JSON}{FileConfiguration.FILENAME_CONFIGURATION}{FileExtension.JSON}";
                    _serviceFile.UDPCreateAndSaveInitialFile(path);
                    json = _serviceJson.UDPSerializerJson(new JsonConfiguration { Path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}" });
                    _serviceFile.UDPWriteAllText(path, json);
                    #endregion Configuration.

                    #region App.
                    path = $"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.JSON}{FileStandard.FILENAME_APP}{FileExtension.JSON}";
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
            return $"{this.UDPGetRootDirectory()}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.JSON}{fileName}";
        }

        public string UDPGetRootPathFileInApp(string fileName)
        {
            return $"{this.UDPGetRootDirectory()}{DirectoryStandard.APP}{DirectoryStandard.APP}{DirectoryStandard.JSON}{fileName}";
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
            string json = string.Empty;
            string path = string.Empty;
            JsonApp jsonApp;
            JsonConfiguration jsonConfiguration;

            List<string>? lstWithAppConfiguration = new List<string>();

            try
            {
                path = UDPGetRootPathFileInConfiguration(FileStandard.FILENAME_APP);
                json = _serviceFile.UDPReadAllText(path);
                jsonApp = (JsonApp)_serviceJson.UDPDesSerializerJsonToApp(json);

                path = UDPGetRootPathFileInConfiguration(FileConfiguration.FILENAME_CONFIGURATION);
                json = _serviceFile.UDPReadAllText(path);
                jsonConfiguration = (JsonConfiguration)_serviceJson.UDPDesSerializerJsonToConfiguration(json);

                if (_serviceFuncStrings.NullOrEmpty(jsonApp.Path) || _serviceFuncStrings.NullOrEmpty(jsonConfiguration.Path))
                {
                    throw new Exception();
                }
                else
                {
                    lstWithAppConfiguration.Add(jsonApp.Path);
                    lstWithAppConfiguration.Add(jsonConfiguration.Path);

                    List<string>? lstWithoutAppConfiguration = _serviceLinq.UDPSelectRootPathWithoutAppConfiguration(queueDirectory.ToList());
                    List<string>? lstSectionAppAndConfiguration = _serviceLinq.UDPSelectSectionStandard(lstWithAppConfiguration);

                    if (lstWithoutAppConfiguration is null || lstWithAppConfiguration is null || lstSectionAppAndConfiguration is null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.XML}{Xml.FILENAME_APP}{FileExtension.XML}", lstSectionAppAndConfiguration[0], lstWithAppConfiguration[0]);
                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.XML}{Xml.FILENAME_CONFIGURATION}{FileExtension.XML}", lstSectionAppAndConfiguration[1], lstWithAppConfiguration[1]);

                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.XML}{Xml.FILENAME_DIRECTORY}{FileExtension.XML}", Xml.SECTION_DIRECTORIES_NAME, lstWithoutAppConfiguration);
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        #region Standard Path.

        /// <summary>
        /// Create root path App of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathApp()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}");
        }

        /// <summary>
        /// Create root path Configuration of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathConfiguration()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}");
        }

        /// <summary>
        /// Create root path JSON of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathJson()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.JSON}");
        }

        /// <summary>
        /// Create root path XML of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathXml()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.XML}");
        }

        private void UDPCreateRootPathLog()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}{DirectoryStandard.LOG}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.PROPERTIES}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.CONTROLLERS}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.EXTENSIONS}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.FILTERS}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.MODELS}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.SWAGGER}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.APPLICATION}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.SERVICES}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.DOMAIN}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.ENTITIES}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.CROSSCUTTING}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.DATA}");
            }
        }

        #endregion Infrastructure.

        #endregion Private Methods.
    }
}