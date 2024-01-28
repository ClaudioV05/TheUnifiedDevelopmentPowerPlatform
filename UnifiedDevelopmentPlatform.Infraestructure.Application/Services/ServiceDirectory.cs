using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Directory.
    /// </summary>
    public class ServiceDirectory : IServiceDirectory
    {
        private string? _directory;
        private readonly IServiceXml _serviceXml;
        //private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceJson _serviceJson;
        private readonly IServiceLinq _serviceLinq;
        private readonly Queue<string> _queueDirectory;
        private readonly IServiceFuncString _serviceFuncStrings;

        public ServiceDirectory(IServiceXml serviceXml, /*IServiceLog serviceLog,*/ IServiceFile serviceFile, IServiceJson serviceJson, IServiceLinq serviceLinq, IServiceFuncString serviceFuncStrings)
        {
            _serviceXml = serviceXml;
            //_serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceJson = serviceJson;
            _serviceLinq = serviceLinq;
            _queueDirectory = new Queue<string>();
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UPDBuildDirectoryStandardOfSolution()
        {
            string path = string.Empty;
            string json = string.Empty;

            try
            {
                //_serviceLog.UDPLogReport(_serviceLog.UDPMensagem(MessageEnumerated.BuildDirectoryStandardOfSolution));

                _directory = this.UDPGetRootDirectory();

                if (_serviceFuncStrings.UDPNullOrEmpty(_directory ?? string.Empty))
                {
                    //_serviceLog.UDPLogReport(_serviceLog.UDPMensagem(MessageEnumerated.DirectoryRootIsEmpty));
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
                    path = $"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}{FileStandard.Configuration}{FileExtension.Json}";
                    _serviceFile.UDPCreateAndSaveFile(path);
                    json = _serviceJson.UDPSerializerJson(new JsonConfiguration { Path = $"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}" });
                    _serviceFile.UDPWriteAllText(path, json);
                    #endregion Configuration.

                    #region App.
                    path = $"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}{FileStandard.App}{FileExtension.Json}";
                    _serviceFile.UDPCreateAndSaveFile(path);
                    json = _serviceJson.UDPSerializerJson(new JsonApp { Path = $"{_directory}{DirectoryStandard.App}" });
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

        public void UPDCreateDirectoryProjectOfSolution()
        {
            string json = string.Empty;
            string path = string.Empty;
            JsonApp jsonApp;
            string[] directories = new string[] { DirectoryStandard.Backend, DirectoryStandard.Frontend };

            try
            {
                path = UDPGetRootPathFileInConfiguration($"{FileStandard.App}{FileExtension.Json}");
                json = _serviceFile.UDPReadAllText(path);
                jsonApp = (JsonApp)_serviceJson.UDPDesSerializerJsonToApp(json);

                _directory = jsonApp.Path;

                if (!_serviceFuncStrings.UDPNullOrEmpty(_directory ?? string.Empty))
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

        private string UDPGetRootDirectory()
        {
            Regex? regex = null;
            string? exeRootDirectory = string.Empty;
            string? rootDirectoryOfSolution = string.Empty;

            try
            {
                regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.UDPLower(Assembly.GetExecutingAssembly().Location);

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
            return $"{this.UDPGetRootDirectory()}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}{fileName}";
        }

        public string UDPGetRootPathFileInApp(string fileName)
        {
            return $"{this.UDPGetRootDirectory()}{DirectoryStandard.App}{DirectoryStandard.App}{DirectoryStandard.Json}{fileName}";
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
                if (!_serviceFuncStrings.UDPNullOrEmpty(rootDirectory ?? string.Empty))
                {
                    if (Directory.Exists($"{rootDirectory}{DirectoryStandard.App}"))
                    {
                        Directory.Delete($"{rootDirectory}{DirectoryStandard.App}", true);
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
                        if (_serviceFuncStrings.UDPNullOrEmpty(dir))
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

            /*List<string>? lstWithAppConfiguration = new List<string>();

            try
            {
                path = UDPGetRootPathFileInConfiguration(FileStandard.App);
                json = _serviceFile.UDPReadAllText(path);
                jsonApp = (JsonApp)_serviceJson.UDPDesSerializerJsonToApp(json);

                path = UDPGetRootPathFileInConfiguration(FileStandard.Configuration);
                json = _serviceFile.UDPReadAllText(path);
                jsonConfiguration = (JsonConfiguration)_serviceJson.UDPDesSerializerJsonToConfiguration(json);

                if (_serviceFuncStrings.UDPNullOrEmpty(jsonApp.Path ?? string.Empty) || _serviceFuncStrings.UDPNullOrEmpty(jsonConfiguration.Path ?? string.Empty))
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
                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.Xml}{Xml.FilenameApp}{FileExtension.Xml}", lstSectionAppAndConfiguration[0], lstWithAppConfiguration[0]);
                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.Xml}{Xml.FilenameConfiguration}{FileExtension.Xml}", lstSectionAppAndConfiguration[1], lstWithAppConfiguration[1]);

                        _serviceXml.UPDTreeXmlSave($"{lstWithAppConfiguration[1]}{DirectoryStandard.Xml}{Xml.FilenameDirectory}{FileExtension.Xml}", Xml.SectionDirectoriesName, lstWithoutAppConfiguration);
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }*/
        }

        #region Standard Path.

        /// <summary>
        /// Create root path App of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathApp()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.App}");
        }

        /// <summary>
        /// Create root path Configuration of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathConfiguration()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}");
        }

        /// <summary>
        /// Create root path JSON of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathJson()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Json}");
        }

        /// <summary>
        /// Create root path XML of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateRootPathXml()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Xml}");
        }

        private void UDPCreateRootPathLog()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.App}{DirectoryStandard.Configuration}{DirectoryStandard.Log}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}{DirectoryApplication.Services}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}{DirectoryDomain.Entities}");
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
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}");
            }
        }

        #endregion Infrastructure.

        #endregion Private Methods.
    }
}