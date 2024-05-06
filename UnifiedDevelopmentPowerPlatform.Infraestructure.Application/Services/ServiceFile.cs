using System.IO;
using System.Text;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service file.
/// </summary>
public class ServiceFile : IServiceFile
{
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceFuncString _serviceFuncString;
    private readonly FileStreamOptions _fileStreamOptions = new FileStreamOptions()
    {
        Access = FileAccess.Read,
        Share = FileShare.ReadWrite,
        Mode = FileMode.OpenOrCreate
    };

    /// <summary>
    /// The constructor of service file.
    /// </summary>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceFuncString"></param>
    public ServiceFile(IServiceDirectory serviceDirectory,
                       IServiceFuncString serviceFuncString)
    {
        _serviceDirectory = serviceDirectory;
        _serviceFuncString = serviceFuncString;
    }

    public bool UDPPFileExists(string? path)
    {
        return File.Exists(path);
    }

    public string UDPPReadAllText(string path)
    {
        return File.ReadAllText(path, Encoding.UTF8);
    }

    public IEnumerable<string>? UDPPReadAllLines(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8);
    }

    public void UDPPWriteAllText(string path, string contents)
    {
        File.WriteAllText(path, contents, Encoding.UTF8);
    }

    public void UDPPCreateAndSaveFile(string path)
    {
        using (FileStream fileStream = File.Create(path)) { };
    }

    public void UDPPCreateAndSaveFileWithStreamWrite(string path)
    {
        using (StreamWriter streamWriter = File.CreateText(path)) { };
    }

    public void UDPPAppendAllText(string path, string content)
    {
        File.AppendAllText(path, content);
    }

    public FileStream UDPPOpenRead(string path)
    {
        using FileStream file = File.OpenRead(path);
        return file;
    }

    public string UDPPGetFileName(string path)
    {
        try
        {
            return Path.GetFileName(path);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public int UDPPCountLines(string fileName)
    {
        var lineCount = 0;

        try
        {
            if (!this.UDPPFileExists(fileName))
            {
                throw new FileNotFoundException($"File not found");
            }

            using StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open), Encoding.UTF8);

            while (reader.ReadLine() is not null)
            {
                lineCount++;
            }

            return lineCount;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string UDPPToCreateDataFile(DirectoryRootType section, string fileName)
    {
        try
        {
            string file = $"{_serviceDirectory.UDPPObtainDirectory(section)}{fileName}";
            this.UDPPCreateAndSaveFileWithStreamWrite(file);
            return this.UDPPFileExists(file) ? file : _serviceFuncString.Empty;
        }
        catch (Exception)
        {
            return _serviceFuncString.Empty;
        }
    }

    public string UDPPGetDataFileFromDirectoryConfiguration(string section, string file)
    {
        string data = _serviceFuncString.Empty;

        try
        {
            string directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);

            if (this.UDPPFileExists($"{directoryConfiguration}{section}{file}"))
            {
                data = this.UDPPReadAllText($"{directoryConfiguration}{section}{file}");
            }

            return data;
        }
        catch (Exception)
        {
            return _serviceFuncString.Empty;
        }
    }

    public bool UDPPIsFileInUseGeneric(FileInfo file)
    {
        try
        {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            return false;
        }
        catch (IOException)
        {
            return true;
        }
    }

    public bool UDPPIsFileInUse(FileInfo file)
    {
        try
        {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            return false;
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            return true;
        }
    }
}