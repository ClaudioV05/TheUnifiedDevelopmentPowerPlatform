namespace AppSolution.Application.Interfaces
{
    public interface IServiceFile
    {
        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="information"></param>
        void LinesGenerate(IEnumerable<string> informations, string rootDirectory);

        /// <summary>
        /// Reading lines from files and return in array of string.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns></returns>
        IEnumerable<string>? LinesRead(string rootDirectory);
    }
}