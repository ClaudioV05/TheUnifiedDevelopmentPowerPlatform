using AppSolution.Application.Interfaces;

namespace AppSolution.Application.Services
{
    public class ServiceValidation : IServiceValidation
    {
        public bool ValidateBase64(string? text)
        {
            // Credit: oybek https://stackoverflow.com/users/794764/oybek

            bool returnValidation = true;

            if (string.IsNullOrEmpty(text) || text.Length % 4 != 0 || text.Contains(" ") || text.Contains("\t") || text.Contains("\r") || text.Contains("\n"))
            {
                returnValidation = false;
            }

            try
            {
                Convert.FromBase64String(text);
            }
            catch (Exception)
            {
                returnValidation = false;
            }

            return returnValidation;
        }
    }
}