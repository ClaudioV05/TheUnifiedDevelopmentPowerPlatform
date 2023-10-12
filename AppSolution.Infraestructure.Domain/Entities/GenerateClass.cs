using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    [ComplexType]
    public class GenerateClass
    {
        /// <summary>
        /// Script of Metadata.
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// Databases.
        /// </summary>
        public Databases? Databases { get; set; }

        /// <summary>
        /// DevelopmentEnvironment.
        /// </summary>
        public DevEnvironment? DevEnvironment { get; set; }

        /// <summary>
        /// Fields.
        /// </summary>
        public Fields? Fields { get; set; }

        /// <summary>
        /// Forms.
        /// </summary>
        public Forms? Forms { get; set; }

        /// <summary>
        /// Tables.
        /// </summary>
        public Tables? Tables { get; set; }

        public GenerateClass()
        {
            try
            {
                Databases = new Databases();
                DevEnvironment = new DevEnvironment();
                Fields = new Fields();
                Forms = new Forms();
                Tables = new Tables();
            }
            catch (Exception)
            {
                throw new Exception("Creation with erro in " + this.ToString());
            }
        }
    }
}