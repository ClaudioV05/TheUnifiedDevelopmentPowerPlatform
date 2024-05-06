using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service file.
/// </summary>
public interface IServiceFile
{
    /// <summary>
    /// Verify if file exist.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return true otherwise false.</returns>
    bool UDPPFileExists(string? path);

    /// <summary>
    /// Read all text.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>String with the data.</returns>
    string UDPPReadAllText(string path);

    /// <summary>
    /// Reading lines from files.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return in IEnumerable of string.</returns>
    IEnumerable<string>? UDPPReadAllLines(string path);

    /// <summary>
    /// Create all lines and save in file.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="contents"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPWriteAllText(string path, string contents);

    /// <summary>
    /// Create and save initial file with class File.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPCreateAndSaveFile(string path);

    /// <summary>
    /// Create and save file whit Class StreamWrite.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPCreateAndSaveFileWithStreamWrite(string path);

    /// <summary>
    /// Open and read all text.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>FileStream with the data.</returns>
    FileStream UDPPOpenRead(string path);

    /// <summary>
    /// Append all text in existing file.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPAppendAllText(string path, string content);

    /// <summary>
    /// Get the file name.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPGetFileName(string path);

    /// <summary>
    /// Count lines using StreamReader.
    /// </summary>
    /// <param name="fileName"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The number of lines.</returns>
    int UDPPCountLines(string fileName);

    /// <summary>
    /// To data file.
    /// </summary>
    /// <param name="section"></param>
    /// <param name="fileName"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>A file.</returns>
    string UDPPToCreateDataFile(DirectoryRootType section, string fileName);

    /// <summary>
    /// Get data file from directory configuration.
    /// </summary>
    /// <param name="section"></param>
    /// <param name="file"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Content from file.</returns>
    string UDPPGetDataFileFromDirectoryConfiguration(string section, string file);

    /// <summary>
    /// Method will check if the file is in use generic.
    /// </summary>
    /// <param name="file"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return true otherwise false.</returns>
    bool UDPPIsFileInUseGeneric(FileInfo file);

    /// <summary>
    /// Method will check if the file is in use.
    /// </summary>
    /// <param name="file"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return true otherwise false.</returns>
    bool UDPPIsFileInUse(FileInfo file);
}