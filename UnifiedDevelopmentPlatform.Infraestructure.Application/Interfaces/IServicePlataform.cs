namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service plataform.
    /// </summary>
    public interface IServicePlataform
    {
        /// <summary>
        /// Make validation if platform is Windows.
        /// </summary>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UPDPlataformIsWindows();

        /// <summary>
        /// Environment add a new line.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>String with caracter \n.</returns>
        string UDPEnvironmentAddNewLine();

        /// <summary>
        /// Get variable of Environment.
        /// </summary>
        /// <param name="variable"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Text with name of environment.</returns>
        string UPDGetEnvironmentVariable(string variable);

        /// <summary>
        /// Get variable of OS version.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Text with name of OS version.</returns>
        string UPDGetOperationalSystemVersion();

        /// <summary>
        /// Get list of variable of Environment.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List of text with name of environment.</returns>
        List<string> UPDGetListEnvironmentVariables();
    }
}