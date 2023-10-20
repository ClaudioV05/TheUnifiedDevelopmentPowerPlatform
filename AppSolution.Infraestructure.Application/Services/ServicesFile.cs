using AppSolution.Infraestructure.Application.Interfaces;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServicesFile : IServicesFile
    {
        public void LinesGenerate(IEnumerable<string> informations, string path)
        {
            File.WriteAllLines(path, informations);
        }

        public IEnumerable<string>? LinesRead(string path)
        {
            IEnumerable<string>? returnList = null;

            if (File.Exists(path)) 
            { 
                returnList = File.ReadAllLines(path);
            }

            return returnList;
        }
    }
}