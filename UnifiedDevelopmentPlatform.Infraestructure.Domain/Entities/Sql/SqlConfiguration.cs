namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql
{
    /// <summary>
    /// Structured Query Language - SQL Configuration
    /// </summary>
    public static class SqlConfiguration
    {
        /// <summary>
        /// Create table position.
        /// </summary>
        public static int CreateTablePosition { get; set; } = 13;

        /// <summary>
        /// Create table default position.
        /// </summary>
        public static int CreateTableDefaultPosition { get; set; } = 5;

        /// <summary>
        /// Create table with space.
        /// </summary>
        public static string CreateTableWithSpace { get; set; } = "create table ";
    }
}