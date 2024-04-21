using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceDevelopmentEnvironments.
    /// </summary>
    public interface IServiceDevelopmentEnvironments
    {
        /// <summary>
        /// Select parameters the kinds of development enviroment.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return the complete list of development enviroment.</returns>
        List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment();

        /// <summary>
        /// Save identifier to the development enviroments from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(MetadataOwner metadata);

        /// <summary>
        /// Get the data type from table in script metadata.
        /// </summary>
        /// <param name="type"></param>
        /// /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <return>The string with the data type</return>
        string UDPGetDataTypeFromTableInScriptMetadata(string type);
    }
}