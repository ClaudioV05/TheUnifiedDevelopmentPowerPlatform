using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceLinq.
    /// </summary>
    public interface IServiceLinq
    {
        /// <summary>
        /// Select root path configuration.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return root path configuration.</returns>
        string UDPSelectRootPathConfiguration(List<string> listItem);

        /// <summary>
        /// Select root path app.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return root path app.</returns>
        string UDPSelectRootPathApp(List<string> listItem);

        /// <summary>
        /// Select section standard.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List contains the name of Standard.</returns>
        List<string>? UDPSelectSectionStandard(List<string> listItem);

        /// <summary>
        /// Select section front end.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List contains the name of front end directories.</returns>
        List<string>? UDPSelectSectionFrontend(List<string> listItem);

        /// <summary>
        /// Select section back end.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List contains the name of back end directories.</returns>
        List<string>? UDPSelectSectionBackend(List<string> listItem);

        /// <summary>
        /// Select root path with app configuration.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List contains the directories app and config.</returns>
        List<string>? UDPSelectRootPathWithAppConfiguration(List<string> listItem);

        /// <summary>
        /// Select root path without app and configuration.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>All paths without App and configuration.</returns>
        List<string>? UDPSelectRootPathWithoutAppConfiguration(List<string> listItem);

        /// <summary>
        /// Distinct.
        /// </summary>
        /// <param name="listItem"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Returns distinct elements from a sequence.</returns>
        List<string> UDPDistinct(List<string> listItem);
    }
}