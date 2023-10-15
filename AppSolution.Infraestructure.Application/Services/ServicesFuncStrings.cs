using AppSolution.Infraestructure.Application.Interfaces;
using System.Text;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServicesFuncStrings : IServicesFuncStrings
    {
        public string RemoveSpecialCaracter(string text)
        {
            try
            {
                List<string> specialCaracter = new List<string>()
                {
                    "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°",
                    "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?","[", "]", "{", "}", "=", "+", "§" ,"´",
                    "`", "^", "~", "\r", "\n"
                };

                specialCaracter.ForEach(t => text = text.Replace(t, " "));
                return text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string RemoveAllWhiteSpace(string text)
        {
            try
            {
                return String.Concat(text.Where(t => !Char.IsWhiteSpace(t)));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string CodifyToBase64(string data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(data);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string DecodeToBase64(string data)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                return ASCIIEncoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}