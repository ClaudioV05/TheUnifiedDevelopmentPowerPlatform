using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceMetadataField.
    /// </summary>
    public interface IServiceMetadataField
    {
        /// <summary>
        /// Return all tables name and all fields.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List with names and fields of table.</returns>
        List<string> UDPMetadataTableAndAllFields(MetadataOwner? metadata);

        /// <summary>
        /// Get the field name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The field name</returns>
        string UDPGetFieldName(string text);

        /// <summary>
        /// Get the type of field name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The type of field name</returns>
        string UDPGetTypeFieldName(string text);

        /// <summary>
        /// Identify whether the field is null.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPFieldIsNotNull(string text);
    }
}