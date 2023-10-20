using AppSolution.Infraestructure.Application.Interfaces;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServicesFile : IServicesFile
    {
        public void LinesGenerate(IEnumerable<string> informations, string path)
        {
            File.WriteAllLines(path, informations);
        }

        public IEnumerable<string> LinesRead(string path)
        {
            return File.ReadLines(path);
        }
    }
}