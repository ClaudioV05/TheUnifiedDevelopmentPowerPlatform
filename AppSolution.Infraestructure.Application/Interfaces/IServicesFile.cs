namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesFile
    {
        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="information"></param>
        void LinesGenerate(IEnumerable<string> informations, string path);

        /// <summary>
        /// Reading lines from files and return in array of string.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<string>? LinesRead(string path);
    }
}